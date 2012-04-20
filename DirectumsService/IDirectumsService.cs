using System;
using System.ServiceModel;
using Directums.Classes;
using Directums.Service.Classes;
using System.Collections.Generic;

namespace Directums.Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDirectumsServiceCallback))]
    public interface IDirectumsService
    {
        [OperationContract]
        Options GetOptions();

        [OperationContract]
        bool Connect(string login, string passwordHash);

        [OperationContract]
        bool Disconnect();

        [OperationContract]
        User GetCurrentUser();

        [OperationContract]
        User[] UserList();

        [OperationContract]
        bool AddUser(string login, string email, string passwordHash);

        [OperationContract]
        bool IsLoginEmpty(string login);

        [OperationContract]
        bool IsEmailEmpty(string email);

        [OperationContract(IsOneWay = true)]
        void AddMessage(int idUserFor, string text);

        [OperationContract]
        FindUsersResult FindUsers(int page, UserFilter filter);

        [OperationContract]
        bool ResetUserPassword(int idUser);

        [OperationContract]
        bool UpdateUser(int idUser, string login, string email, byte status);

        [OperationContract]
        GetFoldersResult[] GetFolders();

        [OperationContract]
        GetFilesResult[] GetFiles(int idParent);

        [OperationContract]
        bool UpdateUserStatus(int idUser, byte status);

        [OperationContract]
        FindGroupsResult[] FindGroups(string filter);

        [OperationContract]
        GetGroupResult GetGroup(int idGroup);

        [OperationContract]
        bool IsGroupNameEmpty(string name);

        [OperationContract]
        bool AddGroup(string name, bool status, int[] users);

        [OperationContract]
        bool UpdateGroup(int id, string name, bool status, int[] users);

        [OperationContract]
        bool ChangeGroupStatus(int idGroup);

        [OperationContract]
        int AddFile(string fileName, string extension, int idParent, byte[] data);

		[OperationContract]
		GetFilesResult AddFolder(string folderName, int idParent);

		[OperationContract]
        byte[] GetFile(int idFile, byte version);
		
        [OperationContract]
        bool AddVersion(int idFile);
        
        [OperationContract]
        bool UpdateVersion(int idFile, byte[] data);

        [OperationContract]
        GetAccessRightsResult[] GetAccessRights(int idFile);

        [OperationContract]
        bool SetAccessRights(int idFile, GetAccessRightsResult[] rights);

        [OperationContract]
        Tag[] GetTags(int idFile);

        [OperationContract]
        string[] GetTagList();

        [OperationContract]
        bool SetTags(int idFile, string[] tags);

        [OperationContract]
        GetFilePropertiesResult GetFileProperties(int idFile);

        [OperationContract]
        bool UpdateFileProperties(int idFile, string name, string description);

        [OperationContract]
        bool UpdateProfile(int idUser, string surname, string name, string patronymic, DateTime birthday,string passwordHash);
    }
}
