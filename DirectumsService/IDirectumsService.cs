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
        bool Connect(string login, string passwordHash);

        [OperationContract]
        bool Disconnect();

        [OperationContract]
        User GetCurrentUser();

        [OperationContract]
        Options GetOptions();

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
        GetDirsResult[] GetDirs();

        [OperationContract]
        GetFilesResult[] GetFiles(Int32 dirId);

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
        bool AddFile(String name, String ex, Int32 parent, byte[] b);

        [OperationContract]
        bool AddVersion(Int32 file, byte[] b);

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
    }
}
