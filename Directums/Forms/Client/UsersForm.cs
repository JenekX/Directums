using System;
using System.Windows.Forms;
using Directums.Classes;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using Directums.Client.Forms.Common;

namespace Directums.Client.Forms.Client
{
    public partial class UsersForm : DirectumsForm
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

        public UsersForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public void Initialize(bool isSelect)
        {
            this.isSelect = isSelect;

            if (isSelect)
            {
                btnSelect.Visible = true;
                Text = "Выбор пользователя";
            }

            UpdateFilterStatus();
            FillUsers(true);

            RefreshInterface();
        }

        public static void Execute(DirectumsForm ownerForm)
        {
            UsersForm form = new UsersForm(ownerForm.Config);
            form.Initialize(false);

            form.ShowDialog(ownerForm);
        }

        public static int ExecuteSelect(DirectumsForm ownerForm)
        {
            UsersForm form = new UsersForm(ownerForm.Config);
            form.Initialize(true);

            if (form.ShowDialog(ownerForm) == DialogResult.OK)
            {
                return form.GetSelectedUser().Id;
            }

            return 0;
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
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }
    }
}