using System;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Admin
{
    public partial class UserEditForm : DirectumsForm
    {
        private User user = null;

        private bool[] valids = { true, true };

        private bool CheckLogin(bool request)
        {
            if (!RegexCheck.CheckLogin(tbLogin.Text))
            {
                lbLoginStatus.Text = "Логин заполнен некорректно";
                lbLoginStatus.Visible = true;

                valids[0] = false;
                return false;
            }

            if (request && tbLogin.Text != user.Login && !Config.Client.IsLoginEmpty(tbLogin.Text))
            {
                lbLoginStatus.Text = "Такой логин уже занят";
                lbLoginStatus.Visible = true;

                valids[0] = false;
                return false;
            }

            lbLoginStatus.Text = "";
            valids[0] = true;
            return true;
        }

        private bool CheckEmail(bool request)
        {
            if (!RegexCheck.CheckEmail(tbEmail.Text))
            {
                lbEmailStatus.Text = "Некорректный e-mail";
                lbLoginStatus.Visible = true;

                valids[1] = false;
                return false;
            }

            if (request && tbEmail.Text != user.Email && !Config.Client.IsEmailEmpty(tbEmail.Text))
            {
                lbEmailStatus.Text = "Такой e-mail уже занят";
                lbEmailStatus.Visible = true;
                
                valids[1] = false;
                return false;
            }

            lbEmailStatus.Text = "";
            valids[1] = true;
            return true;
        }

        private void FillForm()
        {
            tbLogin.Text = user.Login;
            tbEmail.Text = user.Email;

            lbInfo.Text = "Фамилия: " + (string.IsNullOrEmpty(user.Surname) ? "< не указана >" : user.Surname) + "\r\n" +
                "Имя: " + (string.IsNullOrEmpty(user.Name) ? "< не указано >" : user.Name) + "\r\n" +
                "Отчество: " + (string.IsNullOrEmpty(user.Patronymic) ? "< не указано >" : user.Patronymic) + "\r\n" +
                "Дата рождения: " + (user.BornDate.HasValue ? user.BornDate.Value.ToShortDateString() : "< не указана >");

            switch (user.Status)
            {
                case 0: rbStatus0.Checked = true; break;
                case 1: rbStatus1.Checked = true; break;
                case 2: rbStatus2.Checked = true; break;
            }
        }

        private void RefreshInterface()
        {
            btnOk.Enabled = valids[0] && valids[1];
        }

        private byte GetStatus()
        {
            if (rbStatus0.Checked)
            {
                return 0;
            }
            else if (rbStatus1.Checked)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public UserEditForm(DirectumsConfig config, User user) : base(config)
        {
            InitializeComponent();

            this.user = user;

            FillForm();
            RefreshInterface();
        }

        public static bool Execute(DirectumsForm ownerForm, User user)
        {
            UserEditForm form = new UserEditForm(ownerForm.Config, user);
            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (sender == tbLogin)
            {
                CheckLogin(false);
            }
            else if (sender == tbEmail)
            {
                CheckEmail(false);
            }

            RefreshInterface();
        }

        private void tbLogin_Leave(object sender, EventArgs e)
        {
            if (sender == tbLogin)
            {
                CheckLogin(true);
            }
            else if (sender == tbEmail)
            {
                CheckEmail(true);
            }

            RefreshInterface();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (DialogHelper.Confirmation(this, "Пароль будет сброшен на пустой. Продолжить?"))
            {
                Config.Client.ResetUserPassword(user.Id);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Config.Client.UpdateUser(user.Id, tbLogin.Text, tbEmail.Text, GetStatus());
        }
    }
}