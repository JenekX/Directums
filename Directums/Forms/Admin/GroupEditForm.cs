using System;
using System.Linq;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using System.Collections.Generic;

namespace Directums.Client.Forms.Admin
{
    public partial class GroupEditForm : DirectumsForm
    {
        private FindGroupsResult group = null;
        private bool valid = false;

        private bool CheckName(bool request)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                lbNameStatus.Text = "Введите наименование группы";
                lbNameStatus.Visible = true;

                valid = false;
                return false;
            }

            if (request && tbName.Text != group.Name && !Config.Client.IsGroupNameEmpty(tbName.Text))
            {
                lbNameStatus.Text = "Группа с таким наименованием уже есть";
                lbNameStatus.Visible = true;

                valid = false;
                return false;
            }

            lbNameStatus.Text = "";

            valid = true;
            return true;
        }

        private bool FullCheck()
        {
            return CheckName(true);
        }

        private void AddItem(User user)
        {
            var item = lvUsers.Items.Add("", user.Status);
            item.Tag = user;

            item.SubItems.Add(user.Id.ToString());
            item.SubItems.Add(user.Login);
            item.SubItems.Add(user.Email);
        }

        private void UpdateItem(int index)
        {
            var item = lvUsers.Items[index];
            var user = (User)item.Tag;

            item.ImageIndex = user.Status;
            item.SubItems[2].Text = user.Login;
            item.SubItems[3].Text = user.Email;
        }

        private void FillForm()
        {
            if (group == null)
            {
                return;
            }

            var groupInfo = Config.Client.GetGroup(group.Id);

            tbName.Text = groupInfo.Group.Name;
            if (groupInfo.Group.Status)
            {
                rbStatus1.Checked = true;
            }
            else
            {
                rbStatus0.Checked = true;
            }

            lvUsers.Items.Clear();
            foreach (var user in groupInfo.Users)
            {
                AddItem(user);
            }
        }

        private int GetSelectedIndex()
        {
            return lvUsers.SelectedItems.Count > 0 ? lvUsers.SelectedItems[0].Index : -1;
        }

        private User GetSelectedUser()
        {
            if (GetSelectedIndex() == -1)
            {
                return null;
            }

            return (User)lvUsers.SelectedItems[0].Tag;
        }

        private int[] GetUserList()
        {
            var users = new List<int>();

            for (int i = 0; i < lvUsers.Items.Count; i++)
            {
                var user = (User)lvUsers.Items[i].Tag;

                users.Add(user.Id);
            }

            return users.ToArray();
        }

        private bool IsContainsUser(int idUser)
        {
            return GetUserList().Contains(idUser);
        }

        private void RefreshMenu()
        {
            bool enabled = GetSelectedIndex() != -1;

            tsmAdd.Enabled = group == null || group.Id != Config.Options.IdAllUsersGroup;
            tsmEdit.Enabled = enabled;
            tsmExclude.Enabled = tsmAdd.Enabled && enabled;
        }

        private void RefreshInterface()
        {
            tbName.Enabled = gbStatus.Enabled = group == null || group.Id != Config.Options.IdAllUsersGroup;

            btnOk.Enabled = valid;
        }

        public GroupEditForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public void Initialize(FindGroupsResult group)
        {
            this.group = group;

            if (group == null)
            {
                Text = "Добавление группы";
            }
            else
            {
                Text = "Редактирование группы";
            }

            FillForm();
            RefreshInterface();
        }

        public static bool Execute(DirectumsForm ownerForm, FindGroupsResult group = null)
        {
            GroupEditForm form = new GroupEditForm(ownerForm.Config);
            form.Initialize(group);

            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        private void cmUsers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RefreshMenu();
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            User user = UserManagementForm.ExecuteSelect(this);

            if (user == null)
            {
                return;
            }

            if (IsContainsUser(user.Id))
            {
                DialogHelper.Error(this, "Пользователь уже состоит в группе");

                return;
            }

            AddItem(user);
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            User user = GetSelectedUser();

            if (UserEditForm.Execute(this, user))
            {
                int index = GetSelectedIndex();

                UpdateItem(index);
            }
        }

        private void tsmExclude_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            lvUsers.Items.RemoveAt(index);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            CheckName(false);

            RefreshInterface();
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            CheckName(true);

            RefreshInterface();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!FullCheck())
            {
                DialogResult = DialogResult.None;
                return;
            }

            var users = GetUserList();
            bool result = true;

            if (group == null)
            {
                result = Config.Client.AddGroup(tbName.Text, rbStatus1.Checked, users);
            }
            else
            {
                result = Config.Client.UpdateGroup(group.Id, tbName.Text, rbStatus1.Checked, users);
            }

            if (!result)
            {
                DialogHelper.Error(this, "Возникла ошибка");

                DialogResult = DialogResult.None;
            }
        }
    }
}