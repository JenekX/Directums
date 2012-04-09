using System;
using System.Windows.Forms;
using Directums.Client.DirectumsService;
using Directums.Client.Classes;
using Directums.Client.Forms.Client;

namespace Directums.Client.Controls.Client
{
    public partial class UserPicker : UserControl
    {
        private User user = null;

        private void FillEdit()
        {
            if (user == null)
            {
                tbUser.Text = "";
                return;
            }

            tbUser.Text = user.GetLoginWithName();
        }

        public UserPicker()
        {
            InitializeComponent();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (Parent is DirectumsForm)
            {
                User result = UsersForm.ExecuteSelect((DirectumsForm)Parent);

                if (result != null)
                {
                    User = result;
                }
            }
            else
            {
                DialogHelper.Error(this, "Функция недоступна.");
            }
        }

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;

                FillEdit();
            }
        }

        public string Title
        {
            get
            {
                return lbUser.Text;
            }
            set
            {
                lbUser.Text = value;
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