using System.ServiceProcess;
using System.ServiceModel;

namespace Directums.Service
{
    public partial class ProjectService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public ProjectService()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            ServiceBase.Run(new ProjectService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(DirectumsService));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}