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

        private int idUser = 0;
        private bool isAdmin = false;
        private IDirectumsServiceCallback callback = null;

        private void IsAllowAction(AccessType needType)
        {
            if (needType == AccessType.Authorized && idUser == 0 || needType == AccessType.Admin && !isAdmin)
            {
                throw new AccessFailureException();
            }
        }

        public bool Connect(string login, string passwordHash)
        {
            if (idUser != 0)
            {
                return true;
            }

            User user = context.Users.FirstOrDefault(x => x.Login == login && x.PasswordHash == passwordHash);
            if (user == null)
            {
                return false;
            }

            this.idUser = user.Id;
            this.isAdmin = user.IsAdmin;
            this.callback = OperationContext.Current.GetCallbackChannel<IDirectumsServiceCallback>();

            try
            {
                connected.ToList().ForEach(x => x.Value.UserConnected(idUser));
            }
            catch
            {
                // Обработка исключения
            }

            connected.Add(idUser, callback);

            return true;
        }

        public void Disconnect()
        {
            IsAllowAction(AccessType.Authorized);

            if (connected.ContainsKey(idUser))
            {
                connected.Remove(idUser);

                try
                {
                    connected.ToList().ForEach(x => x.Value.UserDisconnected(idUser));
                }
                catch
                {
                    // Обработка исключения
                }
            }
        }

        public User GetCurrentUser()
        {
            IsAllowAction(AccessType.Authorized);

            return context.Users.SingleOrDefault(x => x.Id == idUser);
        }

        public User[] UserList()
        {
            IsAllowAction(AccessType.Admin);

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

                if (user.CheckOnRegister() && IsLoginEmpty(login) && IsEmailEmpty(email))
                {
                    context.Items.InsertOnSubmit(item);
                    context.Users.InsertOnSubmit(user);
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
            IsAllowAction(AccessType.Authorized);

            Message message = new Message() { IdUserFrom = idUser, IdUserFor = idUserFor, Text = text };

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
                    connected[idUserFor].NewMessageReceive(idUser, text);
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
            IsAllowAction(AccessType.Admin);

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
            IsAllowAction(AccessType.Admin);

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
            IsAllowAction(AccessType.Admin);

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
                    // Попытка хаxа

                    return;
                }
            }
            catch
            {
                // ошибка доступа к БД.
            }
        }

        public List<GetDirsResult> GetDirs()
        {
            //Получение доступных директорий конкретно для пользователя            
            var dirs = context.AccessRights.Where(x => x.IdUser == idUser).
                Join(context.Files, access => access.IdFile, file => file.Id, (access, file) => new { Id = file.Id, Name = file.Name, FileType = file.Type, AccType = access.Type }).
                Where(x => x.FileType == 1).
                Join(context.Items, file => file.Id, item => item.IdFile, (file, item) => new GetDirsResult((Int32)file.Id, file.Name, (Int32)item.IdParent, (Int32)item.Id, item.Type)).ToList();
            
            //Получение доступных директорий для группы пользователей, в которой состоит данные пользователь
            dirs.AddRange(context.UserGroups.Where(x => x.IdUser == idUser).
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
            var root = context.Users.FirstOrDefault(x => x.Id == idUser);
            
            if (root != null)
            {
                //GetFilesResult fileRoot = new GetFilesResult(-1, "Корневая папка пользователя", -1, root.IdRootFolder);
                dirs.Add(new GetDirsResult(-1, "Корневая папка пользователя", -1, root.IdRootFolder));   
            }

            return dirs;
        }

        public List<GetFilesResult> GetFiles(Int32 dirId)
        {
            return context.Items.Where(x => x.IdParent == dirId && x.Type == 0).
                Join(context.Files, item => item.IdFile, file => file.Id, (item, file) => new { Id = (Int32)file.Id, FileType = file.Type }).
                Where(x => x.FileType == 0)
                .Join(context.Files, prevFile => prevFile.Id, file => file.Id, (prevFile, file) => new GetFilesResult((Int32) file.Id, file.Name, file.Extension.Name, (DateTime) file.Created)).ToList(); 
        }
    }
}