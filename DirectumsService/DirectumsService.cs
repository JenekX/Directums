using System;
using System.Linq;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections;
using Directums.Classes;
using System.Linq.Expressions;
using Directums.Service.Classes;
using Directums.Classes.Core;
using System.IO;

namespace Directums.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DirectumsService : IDirectumsService
    {
        private static DirectumsServiceDataClassesDataContext context = new DirectumsServiceDataClassesDataContext();
        private static Dictionary<int, IDirectumsServiceCallback> connected = new Dictionary<int, IDirectumsServiceCallback>();
        
        private const int takeCount = 2;

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

        private int GetIdAllGroup()
        {
            return Convert.ToInt32(context.Options.Single(x => x.Name == "IdAllGroup").Value);
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
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);
            }

            connected.Add(user.Id, callback);

            return true;
        }

        public bool Disconnect()
        {
            IsAllowAction(AccessType.Authorized);

            if (connected.ContainsKey(user.Id))
            {
                connected.Remove(user.Id);

                try
                {
                    connected.ToList().ForEach(x => x.Value.UserDisconnected(user.Id));
                }
                catch (Exception e)
                {
                    LogManager.AddException(e);

                    return false;
                }

                user = null;
                callback = null;
            }

            return true;
        }

        public User GetCurrentUser()
        {
            IsAllowAction(AccessType.Authorized);

            try
            {
                return context.Users.SingleOrDefault(x => x.Id == user.Id);
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public Options GetOptions()
        {
            try
            {
                var options = context.Options.ToDictionary(x => x.Name, x => x.Value);

                var result = new Options()
                {
                    IdAllUsersGroup = Convert.ToInt32(options["IdAllGroup"])
                };

                return result;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public User[] UserList()
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var users = connected.Select(x => x.Key);
                var result = context.Users.Where(x => users.Contains(x.Id)).ToArray();

                return result;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool AddUser(string login, string email, string passwordHash)
        {
            try
            {
                Item item = new Item() { Type = Item.UserFolder, IdParent = null, IdFile = null, IdItem = null };
                User user = new User() { Login = login, Email = email, PasswordHash = passwordHash, Surname = "", Name = "", Patronymic = "", BornDate = null, Status = 0, Item = item, IsAdmin = false };
                Group group = context.Groups.Single(x => x.Id == GetIdAllGroup());
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
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        public bool IsLoginEmpty(string login)
        {
            try
            {
                return context.Users.Count(x => x.Login == login) == 0;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        public bool IsEmailEmpty(string email)
        {
            try
            {
                return context.Users.Count(x => x.Email == email) == 0;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
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
                catch (Exception e)
                {
                    LogManager.AddException(e);

                    return;
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

            try
            {
                var query = context.Users.Where(filterId).Where(filterLogin).Where(filterEmail).Where(filterSurname).Where(filterName).Where(filterPatronymic).
                    Where(filterStatus).Where(filterBornDateFrom).Where(filterBornDateTo);
                var result = new FindUsersResult()
                {
                    PageCount = Math.Max((int)Math.Ceiling((double)query.Count() / takeCount), 1),
                    Users = query.Skip((page - 1) * takeCount).Take(takeCount).ToArray()
                };

                return result;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool ResetUserPassword(int idUser)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null)
                {
                    // Попытка хака

                    return false;
                }

                user.PasswordHash = HashHelper.StringHash("");

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        public bool UpdateUser(int idUser, string login, string email, byte status)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null)
                {
                    // Попытка хака

                    return false;
                }

                if (user.CheckOnAdminEdit() && (user.Login == login || IsLoginEmpty(login)) && (user.Email == email || IsEmailEmpty(email)))
                {
                    user.Login = login;
                    user.Email = email;
                    user.Status = status;

                    context.SubmitChanges();

                    return true;
                }
                else
                {
                    // Попытка хака

                    return false;
                }
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
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
                Join(context.AccessRights, groups => groups.IdGroup, access => access.IdGroup, (groups, access) => new { IdFile = access.IdFile, AccType = access.Type, IdUser = access.IdUser }).
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
                .Join(context.Files, prevFile => prevFile.Id, file => file.Id, (prevFile, file) => new GetFilesResult((Int32)file.Id, file.Name, file.Extension.Name, (DateTime)file.Created)).ToArray();
        }

        public bool UpdateUserStatus(int idUser, byte status)
        {
            IsAllowAction(AccessType.Admin, AccessStatus.Active);

            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null || status != User.StatusInactive && status != User.StatusActive && status != User.StatusBlocked)
                {
                    // Попытка хака

                    return false;
                }

                user.Status = status;

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
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
                return context.Groups.Where(filterFunc).Select(x => new FindGroupsResult() { Group = x, UserCount = x.UserGroups.Count }).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);

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
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }

            return true;
        }

        public bool AddFile(String name, String ex, Int32 parent, byte[] b)
        {
            IsAllowAction(AccessType.Authorized);
            
            try
            {
                Extension extensionRecord = context.Extensions.FirstOrDefault(x => x.Name == ex);
                if (extensionRecord == null)
                {
                    extensionRecord = new Extension() { Name = ex };
                    context.Extensions.InsertOnSubmit(extensionRecord);
                }

                File file = new File() { Extension = extensionRecord, User = user, Name = name, Type = 0, Created = DateTime.Now, Description = "" };
                Item item = new Item() { File = file, Type = 0, IdParent = parent };
                FileVersion version = new FileVersion() { File = file, Number = 0, Created = DateTime.Now, Data = b };

                context.Files.InsertOnSubmit(file);
                context.Items.InsertOnSubmit(item);
                context.FileVersions.InsertOnSubmit(version);
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }

            return true;
        }

        public bool AddVersion(Int32 file, byte[] b)
        {
            IsAllowAction(AccessType.Authorized);

            try
            {
                var oldFile = context.FileVersions.FirstOrDefault(x => x.IdFile == file);
                if (oldFile != null)
                {
                    FileVersion version;

                    if ((oldFile.Number++) % 5 == 0)
                    {
                        version = new FileVersion() { IdFile = file, Number = ++oldFile.Number, Created = DateTime.Now, Data = b };
                    }
                    else
                    {
                        MemoryStream output = new MemoryStream();
                        version = new FileVersion() { IdFile = file, Number = ++oldFile.Number, Created = DateTime.Now, Data = BinaryPatchUtility.Create(oldFile.Data.ToArray(), b, output).ToArray() };
                    }

                    context.FileVersions.InsertOnSubmit(version);
                    context.SubmitChanges();
                }
                else
                {
                    //файл не загружен
                    return false;
                }
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }

            return true;
        }

        public GetAccessRightsResult[] GetAccessRights(int idFile)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || file.IdOwner != user.Id)
                {
                    // Хакерская атака

                    return null;
                }

                return file.AccessRights.Select(x => new GetAccessRightsResult() { IsUser = x.IdUser.HasValue, IdItem = x.IdUser.HasValue ? x.IdUser.Value : x.IdGroup.Value,
                    Name = x.IdUser.HasValue ? x.User.GetLoginWithName() : x.Group.Name, Type = x.Type }).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool SetAccessRights(int idFile, GetAccessRightsResult[] rights)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || file.IdOwner != user.Id)
                {
                    // Хакерская атака

                    return false;
                }

                var rightsToAdd = rights.ToList();

                foreach (var accessRight in file.AccessRights)
                {
                    var right = rights.SingleOrDefault(x => x.IsUser == accessRight.IdUser.HasValue && x.IdItem == (x.IsUser ? accessRight.IdUser : accessRight.IdGroup));
                    if (right != null)
                    {
                        rightsToAdd.Remove(right);
                    }
                    else
                    {
                        context.AccessRights.DeleteOnSubmit(accessRight);
                    }
                }

                foreach (var right in rightsToAdd)
                {
                    var accessRight = new AccessRight()
                    {
                        File = file,
                        IdUser = null,
                        IdGroup = null,
                        Type = right.Type
                    };

                    if (right.IsUser)
                    {
                        accessRight.IdUser = right.IdItem;
                    }
                    else
                    {
                        accessRight.IdGroup = right.IdItem;
                    }

                    context.AccessRights.InsertOnSubmit(accessRight);
                }

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        public Tag[] GetTags(int idFile)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null)
                {
                    // Хакерская атака

                    return null;
                }

                return file.FileTags.Select(x => x.Tag).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public string[] GetTagList()
        {
            try
            {
                return context.Tags.Select(x => x.Name).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool SetTags(int idFile, string[] tags)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || file.IdOwner != user.Id)
                {
                    // Хакерская атака

                    return false;
                }

                var tagsToAdd = tags.ToList();

                foreach (var fileTag in file.FileTags)
                {
                    if (tags.Contains(fileTag.Tag.Name))
                    {
                        tagsToAdd.Remove(fileTag.Tag.Name);
                    }
                    else
                    {
                        context.FileTags.DeleteOnSubmit(fileTag);
                    }
                }

                foreach (string tagName in tagsToAdd)
                {
                    Tag tag = context.Tags.SingleOrDefault(x => x.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagName };

                        context.Tags.InsertOnSubmit(tag);
                    }

                    var fileTag = new FileTag()
                    {
                        Tag = tag,
                        File = file
                    };

                    context.FileTags.InsertOnSubmit(fileTag);
                }

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        public GetFilePropertiesResult GetFileProperties(int idFile)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null)
                {
                    // Хакерская атака

                    return null;
                }

                var result = new GetFilePropertiesResult()
                {
                    Type = file.Type,
                    Name = file.Name,
                    Extension = file.Extension.Name,
                    Description = file.Description,
                    Owner = file.User,
                    Created = file.Created
                };

                return result;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool UpdateFileProperties(int idFile, string name, string description)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !RegexCheck.CheckFileName(file.Name))
                {
                    // Хакерская атака

                    return false;
                }

                file.Name = name;
                file.Description = description;

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }
    }
}