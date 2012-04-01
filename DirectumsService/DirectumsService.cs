using System;
using System.Linq;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections;
using Directums.Classes;
using System.Linq.Expressions;
using Directums.Service.Classes;
using Directums.Classes.Core;

namespace Directums.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DirectumsService : IDirectumsService
    {
        private static DirectumsServiceDataClassesDataContext context = new DirectumsServiceDataClassesDataContext();
        private static Dictionary<int, IDirectumsServiceCallback> connected = new Dictionary<int, IDirectumsServiceCallback>();

        private const int takeCount = 2;
        private const int allGroupId = 1;

        private User user = null;
        private IDirectumsServiceCallback callback = null;

        private void IsAllowAction(AccessType needType, AccessStatus needStatus = AccessStatus.All)
        {
            byte status = user != null ? user.Status : byte.MaxValue;

            bool isInactive = (needStatus & AccessStatus.Inactive) == AccessStatus.Inactive;
            bool isActive = (needStatus & AccessStatus.Active) == AccessStatus.Active;
            bool isBlocked = (needStatus & AccessStatus.Blocked) == AccessStatus.Blocked;

            if (needType == AccessType.Authorized && user == null || needType == AccessType.Admin && (user == null || !user.IsAdmin) ||
                !(isInactive && status == User.StatusInactive || isActive && status == User.StatusActive || isBlocked && status == User.StatusBlocked))
            {
                throw new AccessFailureException();
            }
        }

        public bool Connect(string login, string passwordHash)
        {
            if (user != null)
            {
                return true;
            }

            try
            {
                user = context.Users.FirstOrDefault(x => x.Login == login && x.PasswordHash == passwordHash);
            }
            catch
            {
                // Ошибка запроса к БД

                return false;
            }

            if (user == null)
            {
                return false;
            }

            if (connected.ContainsKey(user.Id))
            {
                connected.Remove(user.Id);
            }

            callback = OperationContext.Current.GetCallbackChannel<IDirectumsServiceCallback>();

            try
            {
                connected.ToList().ForEach(x => x.Value.UserConnected(user.Id));
            }
            catch
            {
                // Обработка исключения
            }

            connected.Add(user.Id, callback);

            return true;
        }

        public void Disconnect()
        {
            IsAllowAction(AccessType.Authorized);

            if (connected.ContainsKey(user.Id))
            {
                connected.Remove(user.Id);

                try
                {
                    connected.ToList().ForEach(x => x.Value.UserDisconnected(user.Id));
                }
                catch
                {
                    // Обработка исключения
                }

                user = null;
                callback = null;
            }
        }

        public User GetCurrentUser()
        {
            IsAllowAction(AccessType.Authorized);

            return context.Users.SingleOrDefault(x => x.Id == user.Id);
        }

        public Options GetOptions()
        {
            var result = new Options()
            {
                IdAllUsersGroup = allGroupId
            };

            return result;
        }

        public User[] UserList()
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            var users = connected.Select(x => x.Key);
            var result = context.Users.Where(x => users.Contains(x.Id)).ToArray();

            return result;
        }

        public bool AddUser(string login, string email, string passwordHash)
        {
            try
            {
                Item item = new Item() { Type = Item.UserFolder, IdParent = null, IdFile = null, IdItem = null };
                User user = new User() { Login = login, Email = email, PasswordHash = passwordHash, Surname = "", Name = "", Patronymic = "", BornDate = null, Status = 0, Item = item, IsAdmin = false };
                Group group = context.Groups.Single(x => x.Id == allGroupId);
                UserGroup userGroup = new UserGroup() { Group = group, User = user };

                if (user.CheckOnRegister() && IsLoginEmpty(login) && IsEmailEmpty(email))
                {
                    context.Items.InsertOnSubmit(item);
                    context.Users.InsertOnSubmit(user);
                    context.UserGroups.InsertOnSubmit(userGroup);
                    context.SubmitChanges();

                    return true;
                }
                else
                {
                    // запись в лог о попытке хака

                    return false;
                }
            }
            catch
            {
                // Ошибка доступа к БД

                return false;
            }
        }

        public bool IsLoginEmpty(string login)
        {
            return context.Users.Count(x => x.Login == login) == 0;
        }

        public bool IsEmailEmpty(string email)
        {
            return context.Users.Count(x => x.Email == email) == 0;
        }
        
        public void AddMessage(int idUserFor, string text)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            Message message = new Message() { IdUserFrom = user.Id, IdUserFor = idUserFor, Text = text };

            try
            {
                context.Messages.InsertOnSubmit(message);
                context.SubmitChanges();
            }
            catch
            {
                // Запись в протокол о попытке хакерской атаки

                return;
            }

            if (connected.ContainsKey(idUserFor))
            {
                try
                {
                    connected[idUserFor].NewMessageReceive(user.Id, text);
                }
                catch
                {
                    // Обработка исключения
                }
            }
        }

        /**
         * Тут говнокод
         */
        public FindUsersResult FindUsers(int page, UserFilter filter)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            Expression<Func<User, bool>> filterId = x => true;
            Expression<Func<User, bool>> filterLogin = x => true;
            Expression<Func<User, bool>> filterEmail = x => true;
            Expression<Func<User, bool>> filterSurname = x => true;
            Expression<Func<User, bool>> filterName = x => true;
            Expression<Func<User, bool>> filterPatronymic = x => true;
            Expression<Func<User, bool>> filterStatus = x => true;
            Expression<Func<User, bool>> filterBornDateFrom = x => true;
            Expression<Func<User, bool>> filterBornDateTo = x => true;

            if (filter.Id.Count > 0)
            {
                filterId = x => filter.Id.Contains(x.Id);
            }

            if (!string.IsNullOrEmpty(filter.Login))
            {
                filterLogin = x => x.Login.Contains(filter.Login);
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                filterEmail = x => x.Email.Contains(filter.Email);
            }

            if (!string.IsNullOrEmpty(filter.Surname))
            {
                filterSurname = x => x.Surname.Contains(filter.Surname);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterName = x => x.Name.Contains(filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Patronymic))
            {
                filterPatronymic = x => x.Patronymic.Contains(filter.Patronymic);
            }

            if (filter.Status.Contains(true))
            {
                filterStatus = x => (filter.Status[0] ? x.Status == 0 : false) || (filter.Status[1] ? x.Status == 1 : false) || (filter.Status[2] ? x.Status == 2 : false);
            }

            if (filter.BornDateFrom.HasValue)
            {
                filterBornDateFrom = x => x.BornDate >= filter.BornDateFrom.Value;
            }

            if (filter.BornDateTo.HasValue)
            {
                filterBornDateTo = x => x.BornDate <= filter.BornDateTo.Value;
            }

            var query = context.Users.Where(filterId).Where(filterLogin).Where(filterEmail).Where(filterSurname).Where(filterName).Where(filterPatronymic).
                Where(filterStatus).Where(filterBornDateFrom).Where(filterBornDateTo);
            var result = new FindUsersResult()
            {
                PageCount = Math.Max((int)Math.Ceiling((double)query.Count() / takeCount), 1),
                Users = query.Skip((page - 1) * takeCount).Take(takeCount).ToArray()
            };

            return result;
        }

        public void ResetUserPassword(int idUser)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null)
                {
                    // Попытка хака

                    return;
                }

                user.PasswordHash = HashHelper.StringHash("");

                context.SubmitChanges();
            }
            catch
            {
                // ошибка доступа к БД.
            }
        }

        public void UpdateUser(int idUser, string login, string email, byte status)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null)
                {
                    // Попытка хака

                    return;
                }

                if (user.CheckOnAdminEdit() && (user.Login == login || IsLoginEmpty(login)) && (user.Email == email || IsEmailEmpty(email)))
                {
                    user.Login = login;
                    user.Email = email;
                    user.Status = status;

                    context.SubmitChanges();
                }
                else
                {
                    // Попытка хака

                    return;
                }
            }
            catch
            {
                // ошибка доступа к БД.
            }
        }

        public GetDirsResult[] GetDirs()
        {
            //Получение доступных директорий конкретно для пользователя            
            var dirs = context.AccessRights.Where(x => x.IdUser == user.Id).
                Join(context.Files, access => access.IdFile, file => file.Id, (access, file) => new { Id = file.Id, Name = file.Name, FileType = file.Type, AccType = access.Type }).
                Where(x => x.FileType == 1).
                Join(context.Items, file => file.Id, item => item.IdFile, (file, item) => new GetDirsResult((Int32)file.Id, file.Name, (Int32)item.IdParent, (Int32)item.Id, item.Type)).ToList();
            
            //Получение доступных директорий для группы пользователей, в которой состоит данные пользователь
            dirs.AddRange(context.UserGroups.Where(x => x.IdUser == user.Id).
                Join(context.AccessRights, groups => groups.IdGroup, access => access.IdGroup, (groups, access) => new {IdFile = access.IdFile, AccType = access.Type, IdUser = access.IdUser}).
                Where(x => x.IdUser == null).
                Join(context.Files, access => access.IdFile, file => file.Id, (access, file) => new { Id = file.Id, Name = file.Name, FileType = file.Type, AccType = access.AccType }).
                Where(x => x.FileType == 1).
                Join(context.Items, file => file.Id, item => item.IdFile, (file, item) => new GetDirsResult((Int32)file.Id, file.Name, (Int32)item.IdParent, (Int32)item.Id, item.Type)).ToList());
                        
            //Получение расшаренной папки всей конторы
            var shared = context.Items.FirstOrDefault(x => x.Type == 1);
            
            if (shared != null)
            {
                //GetFilesResult fileRoot = new GetFilesResult(-1, "Корневая папка пользователя", -1, root.IdRootFolder);
                dirs.Add(new GetDirsResult(-1, "Общая папка", -1, shared.Id));
            }

            //Получение корневой папки пользователя
            var root = context.Users.FirstOrDefault(x => x.Id == user.Id);
            
            if (root != null)
            {
                //GetFilesResult fileRoot = new GetFilesResult(-1, "Корневая папка пользователя", -1, root.IdRootFolder);
                dirs.Add(new GetDirsResult(-1, "Корневая папка пользователя", -1, root.IdRootFolder));   
            }

            return dirs.ToArray();
        }

        public GetFilesResult[] GetFiles(Int32 dirId)
        {
            return context.Items.Where(x => x.IdParent == dirId && x.Type == 0).
                Join(context.Files, item => item.IdFile, file => file.Id, (item, file) => new { Id = (Int32)file.Id, FileType = file.Type }).
                Where(x => x.FileType == 0)
                .Join(context.Files, prevFile => prevFile.Id, file => file.Id, (prevFile, file) => new GetFilesResult((Int32) file.Id, file.Name, file.Extension.Name, (DateTime) file.Created)).ToArray(); 
        }

        public void UpdateUserStatus(int idUser, byte status)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null || status != User.StatusInactive && status != User.StatusActive && status != User.StatusBlocked)
                {
                    // Попытка хака

                    return;
                }

                user.Status = status;

                context.SubmitChanges();
            }
            catch
            {
                // ошибка доступа к БД.
            }
        }

        public FindGroupsResult[] FindGroups(string filter)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            Expression<Func<Group, bool>> filterFunc = x => true;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filterFunc = x => x.Name.Contains(filter);
            }

            try
            {
                return context.Groups.Where(filterFunc).Select(x => new FindGroupsResult() { Id = x.Id, Name = x.Name, Status = x.Status, UserCount = x.UserGroups.Count }).ToArray();
            }
            catch
            {
                // Ошибка доступа к БД

                return null;
            }
        }

        public GetGroupResult GetGroup(int idGroup)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var group = context.Groups.SingleOrDefault(x => x.Id == idGroup);
                if (group == null)
                {
                    // Попытка хака

                    return null;
                }

                var result = new GetGroupResult()
                {
                    Group = group,
                    Users = group.UserGroups.Select(x => x.User).ToArray()
                };

                return result;
            }
            catch
            {
                // ошибка доступа к БД

                return null;
            }
        }

        public bool IsGroupNameEmpty(string name)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                return context.Groups.Count(x => x.Name == name) == 0;
            }
            catch
            {
                // ошибка доступа к БД

                return false;
            }
        }

        public bool AddGroup(string name, bool status, int[] users)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            var group = new Group()
            {
                Name = name,
                Status = status
            };

            foreach (int idUser in users)
            {
                var userGroup = new UserGroup()
                {
                    Group = group,
                    IdUser = idUser
                };

                context.UserGroups.InsertOnSubmit(userGroup);
            }

            context.Groups.InsertOnSubmit(group);

            try
            {
                context.SubmitChanges();
            }
            catch
            {
                // ошибка доступа к БД

                return false;
            }

            return true;
        }

        public bool UpdateGroup(int id, string name, bool status, int[] users)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            var group = context.Groups.SingleOrDefault(x => x.Id == id);
            if (group == null)
            {
                // Хакерская атака

                return false;
            }

            var usersToAdd = users.ToList();

            group.Name = name;
            group.Status = status;

            foreach (var userGroup in group.UserGroups)
            {
                if (users.Contains(userGroup.IdUser))
                {
                    usersToAdd.Remove(userGroup.IdUser);
                }
                else
                {
                    context.UserGroups.DeleteOnSubmit(userGroup);
                }
            }

            foreach (int idUser in usersToAdd)
            {
                var userGroup = new UserGroup()
                {
                    Group = group,
                    IdUser = idUser
                };

                context.UserGroups.InsertOnSubmit(userGroup);
            }

            try
            {
                context.SubmitChanges();
            }
            catch
            {
                // ошибка доступа к БД

                return false;
            }

            return true;
        }

        public bool ChangeGroupStatus(int idGroup)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var group = context.Groups.SingleOrDefault(x => x.Id == idGroup);
                if (group == null)
                {
                    // Хакерская атака

                    return false;
                }

                group.Status = !group.Status;

                context.SubmitChanges();
            }
            catch
            {
                // ошибка доступа к БД

                return false;
            }

            return true;
        }
    }
}
