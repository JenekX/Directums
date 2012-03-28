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

            string[] arguments = Environment.GetCommandLineArgs();
            IsAdmin = arguments.Count(x => x == "/admin" || x == "-admin") == 1;
        }

        public DirectumsServiceClient Client { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}