using System;
using System.Linq;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections;

namespace Directums.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DirectumsService : IDirectumsService
    {
        private static DirectumsServiceDataClassesDataContext context = new DirectumsServiceDataClassesDataContext();
        private static Dictionary<int, IDirectumsServiceCallback> connected = new Dictionary<int, IDirectumsServiceCallback>();

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

        public User[] UserList()
        {
            IsAllowAction(AccessType.Admin);

            var users = connected.Select(x => x.Key);
            var result = context.Users.Where(x => users.Contains(x.Id)).ToArray();

            return result;
        }

        public bool AddUser(string login, string passwordHash, string email)
        {
            // Валидация модели

            try
            {
                Item item = new Item() { Type = Item.ObjectRef, IdParent = null, IdFile = null, IdItem = null };
                User user = new User() { Login = login, PasswordHash = passwordHash, Email = email, Surname = "", Name = "", Patronymic = "", BornDate = null, Status = 0, Item = item, IsAdmin = false };

                context.Items.InsertOnSubmit(item);
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool IsLoginEmpty(string login)
        {
            return context.Users.Count(x => x.Login == login) == 0;
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
    }
}