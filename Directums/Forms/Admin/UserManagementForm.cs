using System;
using System.Windows.Forms;
using Directums.Classes;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using Directums.Client.Forms.Common;

namespace Directums.Client.Forms.Admin
{
    public partial class UserManagementForm : DirectumsForm
    {
        private bool isSelect = false;
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

        private User GetSelectedUser()
        {
            if (lvUsers.SelectedItems.Count != 1)
            {
                return null;
            }

            return (User)lvUsers.SelectedItems[0].Tag;
        }

        private void RefreshInterface()
        {
            var user = GetSelectedUser();
            btnSelect.Enabled = user != null && user.Status == 1;
        }

        private void RefreshMenu()
        {
            tsmSelect.Visible = tsmSeparator.Visible = isSelect;

            var user = GetSelectedUser();
            bool enabled = user != null;

            tsmSelect.Enabled = enabled && user.Status == 1;
            tsmEdit.Enabled = enabled;
            tsmStatus.Text = enabled && user.Status != 2 ? "Заблокировать" : "Активировать";
            tsmStatus.Enabled = enabled;
        }

        public UserManagementForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public void Initialize(bool isSelect, bool showNew)
        {
            this.isSelect = isSelect;

            if (isSelect)
            {
                btnSelect.Visible = true;
                Text = "Выбор пользователя";
            }

            if (showNew)
            {
                filter.Status[0] = true;
                filter.Status[1] = filter.Status[2] = false;
            }

            UpdateFilterStatus();
            FillUsers(true);

            RefreshInterface();
            RefreshMenu();
        }

        public static void Execute(DirectumsForm ownerForm, bool showNew = false)
        {
            UserManagementForm form = new UserManagementForm(ownerForm.Config);
            form.Initialize(false, showNew);

            form.ShowDialog(ownerForm);
        }

        public static User ExecuteSelect(DirectumsForm ownerForm)
        {
            UserManagementForm form = new UserManagementForm(ownerForm.Config);
            form.Initialize(true, false);

            if (form.ShowDialog(ownerForm) == DialogResult.OK)
            {
                return form.GetSelectedUser();
            }

            return null;
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
            if (isSelect)
            {
                btnSelect.PerformClick();
            }
            else
            {
                tsmEdit.PerformClick();
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }

        private void cmUsers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RefreshMenu();
        }

        private void tsmSelect_Click(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user != null && UserEditForm.Execute(this, user))
            {
                FillUsers(false);

                RefreshInterface();
            }
        }

        private void tsmStatus_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            byte newStatus = (byte)(user.Status == 2 ? 1 : 2);

            Config.Client.UpdateUserStatus(user.Id, newStatus);

            FillUsers(false);

            RefreshInterface();
        }
    }
}
