using System;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;

namespace Directums.Client
{
    public partial class LoginForm : DirectumsForm
    {
        private void RefreshInterface()
        {
            btnOK.Enabled = tbLogin.TextLength > 0 && tbPass.TextLength > 0;
        }

        public LoginForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();

            if (Config.IsAdmin)
            {
                lbSignUp.Visible = false;
            }

            RefreshInterface();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool connected = Config.Client.Connect(tbLogin.Text, HashHelper.StringHash(tbPass.Text));

            if (connected)
            {
                // Тут переход в главную форму
                DialogHelper.Information(this, "все чОтко!");
            }
            else
            {
                DialogHelper.Error(this, "Пользователь с таким логином и паролем не зарегистрирован в системе");
            }
        }

        private void lbSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signupForm = new SignUpForm(Config);
            signupForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }
    }
}