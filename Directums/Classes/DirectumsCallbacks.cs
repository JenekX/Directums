using System;
using System.Linq;
using Directums.Client.DirectumsService;
using Directums.Client.Forms.Client;
using System.Windows.Forms;
using System.Threading;

namespace Directums.Client.Classes
{
    public class DirectumsCallbacks : IDirectumsServiceCallback
    {
        private DirectumsConfig config = null;

        public DirectumsCallbacks(DirectumsConfig config)
        {
            this.config = config;
        }

        public void UserConnected(int idUser)
        {
        }

        public void UserDisconnected(int idUser)
        {
        }

        public void NewMessageReceive(int idUserFrom, string text)
        {
            var form = Application.OpenForms.OfType<MainForm>().SingleOrDefault();

            if (form == null)
            {
                return;
            }

            MethodInvoker callback = delegate()
            {
                EventHandler messageHandler = delegate(object sender, EventArgs e)
                {
                    var messagesForm = Application.OpenForms.OfType<MessagesForm>().SingleOrDefault();

                    if (messagesForm == null)
                    {
                        MessagesForm.Execute(form);
                    }
                };

                NotificationForm.ExecuteMessageAdded(form, messageHandler);
            };

            form.Invoke(callback);
        }
    }
}