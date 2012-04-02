using System;
using System.Linq;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using System.Collections.Generic;

namespace Directums.Client.Forms.Client
{
    public partial class GroupViewForm : DirectumsForm
    {
        private int idGroup;

        private void AddItem(User user)
        {
            var item = lvUsers.Items.Add("", user.Status);
            item.Tag = user;

            item.SubItems.Add(user.Id.ToString());
            item.SubItems.Add(user.Login);
            item.SubItems.Add(user.Email);
        }

        private void FillForm()
        {
            var groupInfo = Config.Client.GetGroup(idGroup);

            lbInfo.Text = "Наименование: " + groupInfo.Group.Name + "\r\n" +
                "Статус: " + (groupInfo.Group.Status ? "Активна" : "Заблокирована");
            
            lvUsers.Items.Clear();
            foreach (var user in groupInfo.Users)
            {
                AddItem(user);
            }
        }

        public GroupViewForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public void Initialize(int idGroup)
        {
            this.idGroup = idGroup;

            FillForm();
        }

        public static void Execute(DirectumsForm ownerForm, int idGroup = 0)
        {
            GroupViewForm form = new GroupViewForm(ownerForm.Config);
            form.Initialize(idGroup);

            form.ShowDialog(ownerForm);
        }
    }
}