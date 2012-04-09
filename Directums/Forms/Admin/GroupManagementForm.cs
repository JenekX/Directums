using System;
using System.Windows.Forms;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Admin
{
    public partial class GroupManagementForm : DirectumsForm
    {
        private void FillGroups()
        {
            var groups = Config.Client.FindGroups(tbQuickFilter.Text);

            lvGroups.Items.Clear();
            foreach (var g in groups)
            {
                var item = lvGroups.Items.Add("", g.Group.Status ? 1 : 0);

                item.Tag = g;
                item.SubItems.Add(g.Group.Id.ToString());
                item.SubItems.Add(g.Group.Name);
                item.SubItems.Add(g.UserCount.ToString());
            }
        }

        private FindGroupsResult GetSelectedGroup()
        {
            if (lvGroups.SelectedItems.Count != 1)
            {
                return null;
            }
            
            return (FindGroupsResult)lvGroups.SelectedItems[0].Tag;
        }

        private void RefreshMenu()
        {
            var group = GetSelectedGroup();
            bool enabled = group != null;

            tsmEdit.Enabled = enabled;
            tsmChangeStatus.Text = enabled && group.Group.Status ? "Заблокировать" : "Активировать";
            tsmChangeStatus.Enabled = enabled;
        }

        public GroupManagementForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();

            FillGroups();
        }

        public static void Execute(DirectumsForm ownerForm)
        {
            GroupManagementForm form = new GroupManagementForm(ownerForm.Config);
            form.ShowDialog(ownerForm);
        }

        private void tbQuickFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && e.Modifiers == Keys.None)
            {
                FillGroups();
            }
        }

        private void tbQuickFilter_Leave(object sender, EventArgs e)
        {
            FillGroups();
        }

        private void cmGroups_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RefreshMenu();
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            if (GroupEditForm.Execute(this))
            {
                FillGroups();
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (GroupEditForm.Execute(this, GetSelectedGroup()))
            {
                FillGroups();
            }
        }

        private void tsmChangeStatus_Click(object sender, EventArgs e)
        {
            var group = GetSelectedGroup();

            if (Config.Client.ChangeGroupStatus(group.Group.Id))
            {
                FillGroups();
            }
        }
    }
}