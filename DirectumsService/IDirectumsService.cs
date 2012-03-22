using System;
using System.ServiceModel;

namespace Directums.Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDirectumsServiceCallback))]
    public interface IDirectumsService
    {
        [OperationContract]
        bool Connect(string login, string passwordHash);

        [OperationContract(IsOneWay = true)]
        void Disconnect();

        [OperationContract]
        User[] UserList();

        [OperationContract]
        bool AddUser(string login, string passwordHash, string email);

        [OperationContract]
        bool IsLoginEmpty(string login);

        [OperationContract(IsOneWay = true)]
        void AddMessage(int idUserFor, string text);
    }
}