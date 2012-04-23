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
        private static Options options = null;
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

        private bool IsCanViewFile(File file, bool allowWrite)
        {
            if (user == null)
            {
                return false;
            }

            if (user.Id == file.IdOwner)
            {
                return true;
            }

            var rights = context.AccessRights.Where(x => x.IdFile == file.Id);

            if (rights.Count(x => x.IdUser.HasValue && x.IdUser == user.Id && (!allowWrite || x.Type == AccessRight.ReadWrite)) > 0)
            {
                return true;
            }

            var groups = context.UserGroups.Where(x => x.IdUser == user.Id).Select(x => x.IdGroup).Distinct();
            if (rights.Count(x => x.IdGroup.HasValue && groups.Contains(x.IdGroup.Value) && (!allowWrite || x.Type == AccessRight.ReadWrite)) > 0)
            {
                return true;
            }

            return false;
        }

        public DirectumsService()
        {
            options = GetOptions();
        }

        public Options GetOptions()
        {
            try
            {
                var options = context.Options.ToDictionary(x => x.Name, x => x.Value);

                var result = new Options()
                {
                    IdAllUsersGroup = Convert.ToInt32(options["IdAllGroup"]),
                    IdSharedFolder = context.Items.Single(x => x.Type == Item.SharedFolder).Id
                };

                return result;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
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
                user = context.Users.Single(x => x.Id == user.Id);

                return user;
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
                Group group = context.Groups.Single(x => x.Id == options.IdAllUsersGroup);
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

        public GetFoldersResult[] GetFolders()
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var ownedDirs = context.Files.Where(x => x.Type == File.TypeFolder && x.IdOwner == user.Id).Select(x => new { IdFile = x.Id, ReadOnly = false, Name = x.Name });

                var allowUserDirs = context.AccessRights.Where(x => x.IdUser == user.Id).Join(context.Files.Where(x => x.Type == File.TypeFolder), right => right.IdFile,
                    file => file.Id, (right, file) => new { IdFile = file.Id, ReadOnly = right.Type == 0, Name = file.Name });

                var allowGroupDirs = context.Groups.Where(x => x.UserGroups.Count(y => y.IdUser == user.Id) > 0).Join(context.AccessRights, group => group.Id, right => right.IdGroup,
                    (group, right) => right).Join(context.Files.Where(x => x.Type == File.TypeFolder), right => right.IdFile,
                    file => file.Id, (right, file) => new { IdFile = file.Id, ReadOnly = right.Type == 0, Name = file.Name });

                var dirs = ownedDirs.Union(allowUserDirs).Union(allowGroupDirs).Distinct();

                List<GetFoldersResult> result = new List<GetFoldersResult>();

                result.Add(new GetFoldersResult() { Type = GetFoldersResultType.SharedFolder, Id = options.IdSharedFolder });
                result.Add(new GetFoldersResult() { Type = GetFoldersResultType.RootUserFolder, Id = user.IdRootFolder });

                var foldersResult = context.Items.Where(x => x.Type == Item.FileOrFolder).Join(dirs, item => item.IdFile, dir => dir.IdFile, (item, dir) =>
                    new GetFoldersResult() { Type = GetFoldersResultType.Folder, Id = item.Id, IdParent = item.IdParent, IdFile = dir.IdFile, Name = dir.Name, ReadOnly = dir.ReadOnly });

                var refResult = context.Items.Where(x => x.Type == Item.ObjectRef).Join(foldersResult, item => item.IdItem, dir => dir.Id, (item, dir) =>
                    new GetFoldersResult() { Type = GetFoldersResultType.FolderRef, Id = item.Id, IdParent = item.IdParent, IdFile = dir.IdFile, Name = dir.Name, ReadOnly = dir.ReadOnly });

                result.AddRange(foldersResult);
                result.AddRange(refResult);

                return result.ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public GetFilesResult[] GetFiles(int idParent)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var parent = context.Items.SingleOrDefault(x => x.Id == idParent);
                if (parent == null)
                {
                    // Попытка хака

                    return null;
                }

                var files = context.Items.Where(x => x.Type == Item.FileOrFolder && x.IdParent == idParent).Join(context.Files, item => item.IdFile, file => file.Id,
                    (item, file) => new
                    {
                        Id = item.Id,
                        Type = file.Type == File.TypeFile ? GetFilesResultType.File : GetFilesResultType.Folder,
                        File = file
                    });

                var refs = context.Items.Where(x => x.Type == Item.ObjectRef && x.IdParent == idParent).Join(context.Items, item => item.IdItem, source => source.Id,
                    (item, source) => source).Join(context.Files, item => item.IdFile, file => file.Id,
                    (item, file) => new
                    {
                        Id = item.Id,
                        Type = file.Type == File.TypeFile ? GetFilesResultType.FileRef : GetFilesResultType.FolderRef,
                        File = file
                    });

                var result = new List<GetFilesResult>();

                var groups = context.UserGroups.Where(x => x.IdUser == user.Id).Select(x => x.IdGroup).Distinct();

                files = files.Union(refs);
                foreach (var file in files)
                {
                    bool readOnly = false;
                    bool allowAdd = file.File.IdOwner == user.Id;
                    if (!allowAdd)
                    {
                        var rights = file.File.AccessRights.FirstOrDefault(x => x.IdUser.HasValue && x.IdUser == user.Id);
                        if (rights == null)
                        {
                            rights = file.File.AccessRights.FirstOrDefault(x => x.IdGroup.HasValue && groups.Contains(x.IdGroup.Value));
                        }

                        if (rights != null)
                        {
                            readOnly = rights.Type == AccessRight.ReadOnly;
                            allowAdd = true;
                        }
                    }

                    if (allowAdd)
                    {
                        result.Add(new GetFilesResult()
                        {
                            Id = file.Id,
                            IdFile = file.File.Id,
                            Type = file.Type,
                            IdOwner = file.File.IdOwner,
                            OwnerName = file.File.User.GetLoginWithName(),
                            Name = file.File.Name,
                            Extension = file.File.Type == File.TypeFile ? file.File.Extension.Name : "",
                            Size = file.Type == GetFilesResultType.File || file.Type == GetFilesResultType.FileRef ? file.File.FileVersions.OrderByDescending(x => x.Number).First().Size : 0,
                            ReadOnly = readOnly,
                            Created = file.File.Created
                        });
                    }
                }

                return result.OrderBy(x => x.Type, new GetFilesResultTypeComparer()).ThenBy(x => x.Name).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
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

        // Extension с точкой. Файл создается с версией 1.
        public GetFilesResult AddFile(string fileName, string extension, int idParent, byte[] data)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            if (!RegexCheck.CheckFileName(fileName))
            {
                // Хакерская атака

                return null;
            }

            try
            {
                Extension extensionRecord = context.Extensions.FirstOrDefault(x => x.Name == extension);
                if (extensionRecord == null)
                {
                    extensionRecord = new Extension() { Name = extension };
                    context.Extensions.InsertOnSubmit(extensionRecord);
                }

                File file = new File() { Extension = extensionRecord, IdOwner = user.Id, Name = fileName, Type = File.TypeFile, Created = DateTime.Now, Description = "" };
                Item item = new Item() { File = file, Type = Item.FileOrFolder, IdParent = idParent };
                FileVersion version = new FileVersion() { File = file, IdOwner = user.Id, Number = 1, Description = "", Data = data, Size = data.Length, IsHidden = false, Created = DateTime.Now };

                context.Files.InsertOnSubmit(file);
                context.Items.InsertOnSubmit(item);
                context.FileVersions.InsertOnSubmit(version);
                context.SubmitChanges();

                return new GetFilesResult()
                {
                    Id = item.Id,
                    IdFile = file.Id,
                    Type = GetFilesResultType.File,
                    IdOwner = file.IdOwner,
                    OwnerName = user.GetLoginWithName(),
                    Name = fileName,
                    Extension = extension,
                    ReadOnly = false,
                    Created = file.Created
                };
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public GetFilesResult AddFolder(string folderName, int idParent)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            if (!RegexCheck.CheckFileName(folderName))
            {
                // Хакерская атака

                return null;
            }

            try
            {
                File folder = new File() { IdExtension = null, IdOwner = user.Id, Name = folderName, Type = File.TypeFolder, Created = DateTime.Now, Description = "" };
                Item item = new Item() { File = folder, Type = Item.FileOrFolder, IdParent = idParent };

                context.Files.InsertOnSubmit(folder);
                context.Items.InsertOnSubmit(item);
                context.SubmitChanges();

                return new GetFilesResult()
                {
                    Id = item.Id,
                    IdFile = folder.Id,
                    Type = GetFilesResultType.Folder,
                    IdOwner = folder.IdOwner,
                    OwnerName = user.GetLoginWithName(),
                    Name = folderName,
                    Extension = "",
                    ReadOnly = false,
                    Created = folder.Created
                };
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        // Версия имеет номер, начинающийся с 1. если 0, то получить последнюю версию
        public byte[] GetFile(int idFile, int version)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !IsCanViewFile(file, false))
                {
                    // Хакерская атака

                    return null;
                }

                int toVersion = version;
                if (toVersion == 0)
                {
                    toVersion = file.FileVersions.Max(x => x.Number);
                }
                else
                {
                    if (file.FileVersions.Count(x => x.Number == toVersion) == 0)
                    {
                        // Хакерская атака

                        return null;
                    }
                }

                var firstVersion = file.FileVersions.OrderBy(x => x.Number).First();
                var result = new MemoryStream(firstVersion.Data.ToArray());

                int fromVersion = toVersion >= 5 ? toVersion - toVersion % 5 : 1;

                if (toVersion >= 5)
                {
                    var middleVersion = file.FileVersions.Single(x => x.Number == fromVersion);

                    var tmp = new MemoryStream();
                    BinaryPatchUtility.Apply(result, () => new MemoryStream(middleVersion.Data.ToArray()), tmp);
                    result = tmp;
                }

                for (int i = fromVersion + 1; i <= toVersion; i++)
                {
                    var currentVersion = file.FileVersions.Single(x => x.Number == i);

                    var tmp = new MemoryStream();
                    BinaryPatchUtility.Apply(result, () => new MemoryStream(currentVersion.Data.ToArray()), tmp);
                    result = tmp;
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        // добавление новой версии на основе базовой. Если номер базовой версии = 0,
        // то будет будет создана версия на основе последней версии.
        public bool AddVersion(int idFile, int baseVersionNumber)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !IsCanViewFile(file, true))
                {
                    // Хакерская атака

                    return false;
                }

                int versionNumber = file.FileVersions.Max(x => x.Number) + 1;
                int oldNumber = versionNumber % 5 == 0 ? 1 : versionNumber - 1;

                MemoryStream output = new MemoryStream();

                var oldData = GetFile(idFile, oldNumber);
                var newData = GetFile(idFile, baseVersionNumber == 0 ? versionNumber - 1 : baseVersionNumber);

                BinaryPatchUtility.Create(oldData, newData, output);

                FileVersion version = new FileVersion() { IdFile = idFile, IdOwner = user.Id, Number = versionNumber, Description = "", Data = output.ToArray(), Size = newData.Length, IsHidden = false, Created = DateTime.Now };

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

        public bool UpdateVersion(int idFile, int versionNumber, byte[] data)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !IsCanViewFile(file, true))
                {
                    // Хакерская атака

                    return false;
                }

                int fromVersion = versionNumber;
                int maxVersion = file.FileVersions.Max(x => x.Number);
                if (fromVersion == 0)
                {
                    fromVersion = maxVersion;
                }
                else
                {
                    if (file.FileVersions.Count(x => x.Number == fromVersion) == 0)
                    {
                        // Хакерская атака

                        return false;
                    }
                }

                int toVersion = Math.Min(fromVersion + (5 - fromVersion % 5) - 1, maxVersion);

                List<byte[]> oldData = new List<byte[]>();
                oldData.Add(data);
                for (int i = fromVersion + 1; i <= toVersion; i++)
                {
                    oldData.Add(GetFile(file.Id, fromVersion));
                }

                for (int i = fromVersion; i <= toVersion; i++)
                {
                    var output = new MemoryStream();
                    byte[] tmpData = null;

                    if (i % 5 == 0)
                    {
                        tmpData = GetFile(file.Id, 1);
                    }
                    else
                    {
                        if (i == fromVersion)
                        {
                            tmpData = GetFile(file.Id, fromVersion - 1);
                        }
                        else
                        {
                            tmpData = oldData[i - fromVersion - 1];
                        }
                    }

                    BinaryPatchUtility.Create(tmpData, oldData[i - fromVersion], output);

                    var version = file.FileVersions.First(x => x.Number == i);
                    
                    version.Size = oldData[i - fromVersion].Length;
                    version.Data = output.ToArray();
                }

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
        }

        // Управлением свойствами версии может заниматься только ее автор.
        public bool UpdateVersionProperties(int idFile, int versionNumber, string description, bool isHidden)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !IsCanViewFile(file, true))
                {
                    // Хакерская атака

                    return false;
                }

                var version = file.FileVersions.SingleOrDefault(x => x.Number == versionNumber);
                if (version == null || version.IdOwner != user.Id)
                {
                    // Хакерская атака

                    return false;
                }

                version.Description = description;
                version.IsHidden = isHidden;

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return false;
            }
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

                return file.AccessRights.Select(x => new GetAccessRightsResult()
                {
                    IsUser = x.IdUser.HasValue,
                    IdItem = x.IdUser.HasValue ? x.IdUser.Value : x.IdGroup.Value,
                    Name = x.IdUser.HasValue ? x.User.GetLoginWithName() : x.Group.Name,
                    Type = x.Type
                }).ToArray();
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
                    Extension = file.Extension != null ? file.Extension.Name : "",
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

        public GetFileVersionsResult[] GetFileVersions(int idFile)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);

            try
            {
                var file = context.Files.SingleOrDefault(x => x.Id == idFile);
                if (file == null || !IsCanViewFile(file, false))
                {
                    // Хакерская атака

                    return null;
                }

                return file.FileVersions.Where(x => !x.IsHidden || x.IdOwner == user.Id).OrderBy(x => x.Number).Select(x => new GetFileVersionsResult()
                {
                    Id = x.Id,
                    Number = x.Number,
                    Description = x.Description,
                    Size = x.Size,
                    OwnerName = x.User.GetLoginWithName(),
                    Created = x.Created,
                    IsHidden = x.IsHidden
                }).ToArray();
            }
            catch (Exception e)
            {
                LogManager.AddException(e);

                return null;
            }
        }

        public bool UpdateProfile(int idUser, string surname, string name, string patronymic, DateTime? birthday, string passwordHash)
        {
            IsAllowAction(AccessType.Authorized, AccessStatus.Active);
            try
            {
                var user = context.Users.SingleOrDefault(x => x.Id == idUser);
                if (user == null)
                {
                    // Попытка хака

                    return false;
                }

                //Валидация данных от пользователя
                if ((passwordHash.Length == 32 || passwordHash.Length == 0) && (RegexCheck.CheckNames(surname) || surname.Length == 0) && (RegexCheck.CheckNames(name) || name.Length == 0) && (RegexCheck.CheckNames(patronymic) || patronymic.Length == 0))
                {
                    user.Surname = surname;
                    user.Name = name;
                    user.Patronymic = patronymic;

                    if (birthday != null)
                    {
                        user.BornDate = birthday;
                    }

                    if (passwordHash.Length != 0)
                    {
                        user.PasswordHash = passwordHash;
                    }

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
    }
}