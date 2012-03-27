using System;
using Directums.Classes;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Admin
{
    public partial class UserManagementForm : DirectumsForm
    {
        private UserFilter filter = new UserFilter();

        private void FillUsers(bool resetPage)
        {
            int page = 1;

            if (!resetPage)
            {
                Int32.TryParse(cmbPage.Text, out page);
            }

            FindUsersResult result = Config.Client.FindUsers(page, filter);

            if (resetPage)
            {
                cmbPage.Items.Clear();
                for (int i = 1; i <= result.PageCount; i++)
                {
                    cmbPage.Items.Add(i);
                }

                cmbPage.SelectedIndex = 0;
            }

            lvUsers.Items.Clear();
            foreach (var user in result.Users)
            {
                var item = lvUsers.Items.Add(user.Id.ToString(), user.Status);

                item.Tag = user;
                item.SubItems.Add(user.Login);
                item.SubItems.Add(user.Email);
                item.SubItems.Add(user.Surname);
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Patronymic);
                item.SubItems.Add(user.BornDate.HasValue ? user.BornDate.Value.ToString() : "");
            }
        }

        private void UpdateFilterStatus()
        {
            if (filter.IsEmpty())
            {
                lbFilter.Text = "Фильтр: не используется";
            }
            else
            {
                lbFilter.Text = "Фильтр: используется";
            }
        }

        public UserManagementForm(DirectumsConfig config, bool showNew) : base(config)
        {
            InitializeComponent();

            if (showNew)
            {
                filter.Status[0] = true;
                filter.Status[1] = filter.Status[2] = false;
            }

            UpdateFilterStatus();
            FillUsers(true);
        }

        public static void Execute(DirectumsForm ownerForm, bool showNew = false)
        {
            UserManagementForm form = new UserManagementForm(ownerForm.Config, showNew);
            form.ShowDialog(ownerForm);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (UserFilterForm.Execute(Config, filter))
            {
                UpdateFilterStatus();
                FillUsers(true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            filter.Clear();

            UpdateFilterStatus();
            FillUsers(true);
        }

        private void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUsers(false);
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count != 1)
            {
                return;
            }
            
            var user = (User)lvUsers.SelectedItems[0].Tag;
            if (UserEditForm.Execute(this, user))
            {
                FillUsers(false);
            }
        }
    }
}
