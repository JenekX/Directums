using System;
using System.Windows.Forms;
using Directums.Client.Classes;

namespace Directums.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DirectumsConfig config = new DirectumsConfig();
            LoginForm form = new LoginForm(config);

            Application.Run(form);
        }
    }
}
