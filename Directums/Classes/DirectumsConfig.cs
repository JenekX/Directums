using System;
using System.Linq;
using System.ServiceModel;
using Directums.Client.DirectumsService;

namespace Directums.Client.Classes
{
    public class DirectumsConfig
    {
        public DirectumsConfig()
        {
            InstanceContext instanceContext = new InstanceContext(new DirectumsCallbacks());
            Client = new DirectumsServiceClient(instanceContext);

            User = null;
            Options = null;

            string[] arguments = Environment.GetCommandLineArgs();
            IsAdmin = arguments.Count(x => x == "/admin" || x == "-admin") == 1;
        }

        public bool Connect(string login, string passwordHash)
        {
            bool result = Client.Connect(login, passwordHash);

            if (result)
            {
                User = Client.GetCurrentUser();
                Options = Client.GetOptions();
            }
            else
            {
                User = null;
                Options = null;
            }

            return result;
        }

        public User RefreshUser()
        {
            User = Client.GetCurrentUser();

            return User;
        }

        public DirectumsServiceClient Client { get; private set; }
        public User User { get; private set; }
        public Options Options { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}