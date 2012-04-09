using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Client
{
    public partial class FileAccessRightsForm : DirectumsForm
    {
        private Dictionary<byte, string> accessRightNames = null;
        private int idFile = 0;

        private void AddItem(GetAccessRightsResult right)
        {
            var item = lvRights.Items.Add("", right.IsUser ? 0 : 1);
            item.Tag = right;

            item.SubItems.Add(right.Name);
            item.SubItems.Add(accessRightNames[right.Type]);
        }

        private void UpdateItem(int index)
        {
            var item = lvRights.Items[index];
            var right = (GetAccessRightsResult)item.Tag;

            item.ImageIndex = right.IsUser ? 0 : 1;
            item.SubItems[1].Text = right.Name; 
            item.SubItems[2].Text = accessRightNames[right.Type];
        }

        private void FillForm()
        {
            var rights = Config.Client.GetAccessRights(idFile);

            lvRights.Items.Clear();
            foreach (var right in rights)
            {
                AddItem(right);
            }
        }

        private GetAccessRightsResult GetItem(int index)
        {
            return (GetAccessRightsResult)lvRights.Items[index].Tag;
        }

        private GetAccessRightsResult[] GetItems()
        {
            List<GetAccessRightsResult> result = new List<GetAccessRightsResult>();

            for (int i = 0; i < lvRights.Items.Count; i++)
            {
                result.Add(GetItem(i));
            }

            return result.ToArray();
        }

        private int GetSelectedIndex()
        {
            return lvRights.SelectedItems.Count == 1 ? lvRights.SelectedItems[0].Index : -1;
        }

        private GetAccessRightsResult GetSelectedItem()
        {
            int index = GetSelectedIndex();

            if (index != -1)
            {
                return GetItem(index);
            }

            return null;
        }

        private bool HasItem(bool isUser, int idItem)
        {
            for (int i = 0; i < lvRights.Items.Count; i++)
            {
                var item = GetItem(i);

                if (item.IsUser = isUser && item.IdItem == idItem)
                {
                    return true;
                }
            }

            return false;
        }

        private bool Initialize(int idFile)
        {
            this.idFile = idFile;

            FillForm();

            return true;
        }

        private void RefreshMenu()
        {
            tsmChooseRights.Enabled = tsmDelete.Enabled = GetSelectedIndex() != -1;
        }

        public FileAccessRightsForm(DirectumsConfig config) : base(config)
        {
            accessRightNames = new Dictionary<byte, string>();
            accessRightNames.Add(0, "Только чтение");
            accessRightNames.Add(1, "Чтение и запись");

            InitializeComponent();
        }

        public static bool Execute(DirectumsForm ownerForm, int idFile)
        {
            var form = new FileAccessRightsForm(ownerForm.Config);
            form.Initialize(idFile);

            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        private void cmRights_Opening(object sender, CancelEventArgs e)
        {
            RefreshMenu();
        }

        private void tsmAddUser_Click(object sender, EventArgs e)
        {
            User user = UsersForm.ExecuteSelect(this);
            if (user == null)
            {
                return;
            }

            if (HasItem(true, user.Id))
            {
                DialogHelper.Error(this, "Пользователь уже имеет права доступа");
                return;
            }

            var right = new GetAccessRightsResult() { IsUser = true, IdItem = user.Id, Name = user.GetLoginWithName(), Type = 0 };
            AddItem(right);
        }

        private void tsmAddGroup_Click(object sender, EventArgs e)
        {
            Group group = GroupsForm.ExecuteSelect(this);
            if (group == null)
            {
                return;
            }

            if (HasItem(true, group.Id))
            {
                DialogHelper.Error(this, "Группа уже имеет права доступа");
                return;
            }

            var right = new GetAccessRightsResult() { IsUser = false, IdItem = group.Id, Name = group.Name, Type = 0 };
            AddItem(right);
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            lvRights.Items.RemoveAt(index);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Config.Client.SetAccessRights(idFile, GetItems()))
            {
                DialogResult = DialogResult.None;
            }
        }

        private void lvRights_DoubleClick(object sender, EventArgs e)
        {
            var index = GetSelectedIndex();
            var item = GetSelectedItem();

            item.Type = (byte)(item.Type == 1 ? 2 : 1);
            UpdateItem(index);
        }
    }
}
