using System.Windows.Forms;
using Directums.Client.Classes;

namespace Directums.Client.Forms.Client
{
    public partial class EditTagForm : DirectumsForm
    {
        private void RefreshInterface()
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbTag.Text);
        }

        private void Initialize(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                Text = "Добавление тега";
            }
            else
            {
                Text = "Редактирование тега";

                tbTag.Text = tag;
            }

            tbTag.AutoCompleteCustomSource.AddRange(Config.Tags);

            RefreshInterface();
        }

        public EditTagForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static string Execute(DirectumsForm ownerForm, string tag = null)
        {
            var form = new EditTagForm(ownerForm.Config);
            form.Initialize(tag);

            if (form.ShowDialog(ownerForm) == DialogResult.OK)
            {
                return form.tbTag.Text.Trim();
            }

            return "";
        }

        private void tbTag_TextChanged(object sender, System.EventArgs e)
        {
            RefreshInterface();
        }
    }
}