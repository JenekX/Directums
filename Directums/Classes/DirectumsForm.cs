using System.Windows.Forms;

namespace Directums.Client.Classes
{
    public class DirectumsForm : Form
    {
        public DirectumsForm() : base()
        {
            Config = null;
        }

        public DirectumsForm(DirectumsConfig config) : base()
        {
            Config = config;
        }

        public DirectumsConfig Config { get; private set; }
    }
}