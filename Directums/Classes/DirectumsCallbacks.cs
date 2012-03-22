using System;
using Directums.Client.DirectumsService;

namespace Directums.Client.Classes
{
    public class DirectumsCallbacks : IDirectumsServiceCallback
    {
        public void UserConnected(int idUser)
        {
            throw new NotImplementedException();
        }

        public void UserDisconnected(int idUser)
        {
            throw new NotImplementedException();
        }

        public void NewMessageReceive(int idUserFrom, string text)
        {
            throw new NotImplementedException();
        }
    }
}