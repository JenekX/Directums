using System;
using System.Windows.Forms;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Client
{
    public partial class GroupsForm : DirectumsForm
    {
        private bool isSelect = false;

        private void FillGroups()
        {
            var groups = Config.Client.FindGroups(tbQuickFilter.Text);

            lvGroups.Items.Clear();
            foreach (var group in groups)
            {
                var item = lvGroups.Items.Add("", group.Status ? 1 : 0);

                item.Tag = group;
                item.SubItems.Add(group.Id.ToString());
                item.SubItems.Add(group.Name);
                item.SubItems.Add(group.UserCount.ToString());
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

        private void RefreshInterface()
        {
            var group = GetSelectedGroup();
            btnSelect.Enabled = group != null && group.Status;
        }

        private void RefreshMenu()
        {
            var group = GetSelectedGroup();
            bool enabled = group != null;

            tsmSelect.Enabled = enabled && group.Status;
            tsmView.Enabled = enabled;
        }

        public GroupsForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public void Initialize(bool isSelect)
        {
            this.isSelect = isSelect;

            if (isSelect)
            {
                btnSelect.Visible = true;
                btnClose.Text = "Отмена";
                Text = "Выбор группы";
            }

            tsmSelect.Visible = tsmSeparator.Visible = isSelect; 

            FillGroups();

            RefreshInterface();
            RefreshMenu();
        }

        public static void Execute(DirectumsForm ownerForm)
        {
            GroupsForm form = new GroupsForm(ownerForm.Config);
            form.Initialize(false);

            form.ShowDialog(ownerForm);
        }

        public static int ExecuteSelect(DirectumsForm ownerForm)
        {
            GroupsForm form = new GroupsForm(ownerForm.Config);
            form.Initialize(true);

            if (form.ShowDialog(ownerForm) == DialogResult.OK)
            {
                return form.GetSelectedGroup().Id;
            }

            return 0;
        }

        private void tbQuickFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && e.Modifiers == Keys.None)
            {
                FillGroups();

                e.SuppressKeyPress = false;
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

        private void tsmSelect_Click(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void tsmView_Click(object sender, EventArgs e)
        {
            int idGroup = GetSelectedGroup().Id;

            GroupViewForm.Execute(this, idGroup); 
        }

        private void lvGroups_DoubleClick(object sender, EventArgs e)
        {
            if (isSelect)
            {
                btnSelect.PerformClick();
            }
            else
            {
                tsmView.PerformClick();
            }
        }

        private void lvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }
    }
}