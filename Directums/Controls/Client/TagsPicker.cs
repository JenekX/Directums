using System;
using System.Linq;
using System.Windows.Forms;
using Directums.Client.DirectumsService;
using Directums.Client.Classes;
using Directums.Client.Forms.Client;

namespace Directums.Client.Controls.Client
{
    public partial class TagsPicker : UserControl
    {
        private int idFile = 0;

        private void FillEdit()
        {
            if (idFile != 0 && Parent is DirectumsForm)
            {
                var tags = ((DirectumsForm)Parent).Config.Client.GetTags(idFile);
                if (tags != null)
                {
                    tbText.Text = string.Join(", ", tags.Select(x => x.Name));

                    return;
                }
            }

            tbText.Text = "";
        }

        public TagsPicker()
        {
            InitializeComponent();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (Parent is DirectumsForm)
            {
                bool result = TagsForm.Execute((DirectumsForm)Parent, idFile);
                if (result)
                {
                    FillEdit();
                }
            }
            else
            {
                DialogHelper.Error(this, "Функция недоступна.");
            }
        }

        public int IdFile
        {
            get
            {
                return idFile;
            }
            set
            {
                idFile = value;

                FillEdit();
            }
        }

        public string Title
        {
            get
            {
                return lblTags.Text;
            }
            set
            {
                lblTags.Text = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return !btnPick.Enabled;
            }
            set
            {
                btnPick.Enabled = !value;
            }
        }
    }
}