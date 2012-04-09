using System.Windows.Forms;

namespace Directums.Client.Forms.Common
{
    public partial class InputBox : Form
    {
        private void Initialize(string caption, string prompt, string value, int width)
        {
            Text = caption;
            lblPrompt.Text = prompt;
            tbPrompt.Text = value;
            Width = width;
        }

        public InputBox()
        {
            InitializeComponent();
        }

        public static string Execute(IWin32Window owner, string caption, string prompt, string value, int width = 400)
        {
            InputBox form = new InputBox();
            form.Initialize(caption, prompt, value, width);

            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.tbPrompt.Text;
            }
            
            return "";
        }
    }
}