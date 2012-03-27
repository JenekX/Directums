using System.Windows.Forms;

namespace Directums.Client.Classes
{
    public class DirectumsForm : Form
    {
        public DirectumsForm() : this(null)
        {
        }

        public DirectumsForm(DirectumsConfig config) : base()
        {
            Config = config;

            StartPosition = FormStartPosition.CenterParent;
        }

        public DirectumsConfig Config { get; private set; }
    }
}