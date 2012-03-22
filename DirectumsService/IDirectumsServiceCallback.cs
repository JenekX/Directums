using System.ServiceModel;

namespace Directums.Service
{
    public interface IDirectumsServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void UserConnected(int idUser);

        [OperationContract(IsOneWay = true)]
        void UserDisconnected(int idUser);

        [OperationContract(IsOneWay = true)]
        void NewMessageReceive(int idUserFrom, string text);
    }
}