using System;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using System.Collections.Generic;

namespace Directums.Client
{
    public partial class LoginForm : DirectumsForm
    {
        private void RefreshInterface()
        {
            btnOK.Enabled = tbLogin.TextLength > 0;
        }

        private void Initialize()
        {
            if (Config.IsAdmin)
            {
                lbSignUp.Visible = false;
            }

            RefreshInterface();
        }

        public LoginForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static bool Execute(DirectumsConfig config)
        {
            LoginForm form = new LoginForm(config);
            form.Initialize();

            return form.ShowDialog() == DialogResult.OK;
        }

        private void lbSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm.Execute(this);
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool connected = Config.Connect(tbLogin.Text, HashHelper.StringHash(tbPass.Text));

            if (!connected)
            {
                DialogHelper.Error(this, "Пользователь с таким логином и паролем не зарегистрирован в системе");

                DialogResult = DialogResult.None;
            }
        }
    }
}