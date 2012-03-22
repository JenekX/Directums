using System;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;

namespace Directums.Client
{
    public partial class SignUpForm : DirectumsForm
    {
        public string Login;
        public string Pass;
        public string Email;

        public SignUpForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();

            lbLoginStatus.Text = "";
            lbPassStatus.Text = "";
            lbConfirmPassStatus.Text = "";
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            string passEntering = tbPass.Text;

            if (passEntering.Length < 3)
            {
                lbPassStatus.Text = "Некорректная длина пароля";
            }

            if (RegexCheck.CheckLoginPass(passEntering))
            {
                lbPassStatus.Text = "В пароле присутствуют не корректные символы";
                return;
            }

            if (passEntering.Length >= 3 &&
                (RegexCheck.CheckDigits(passEntering) || RegexCheck.CheckLowLetter(passEntering) || RegexCheck.CheckUpLetters(passEntering)))
            {
                lbPassStatus.Text = "Хреновый пароль";
            }

            if (tbPass.Text.Length >= 5 &&
                (RegexCheck.CheckDigits(passEntering) && (RegexCheck.CheckLowLetter(passEntering) || RegexCheck.CheckUpLetters(passEntering)))
                || (RegexCheck.CheckLowLetter(passEntering) && RegexCheck.CheckUpLetters(passEntering)))
            {
                lbPassStatus.Text = "Нормально так";
            }

            if (tbPass.Text.Length > 7 && (RegexCheck.CheckDigits(passEntering) && RegexCheck.CheckLowLetter(passEntering) && RegexCheck.CheckUpLetters(passEntering)))
            {
                lbPassStatus.Text = "Заебись!!!!";
            }

            btnOK.Enabled = IfOKAvailable();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isLoginEmpty = Config.Client.IsLoginEmpty(tbLogin.Text);
            if (!isLoginEmpty)
            {
                DialogHelper.Error(this, "Логин уже занят");
                DialogResult = DialogResult.None;

                return;
            }

            if (!IsCheckValues())
            {
                DialogResult = DialogResult.None;

                return;
            }

            bool result = Config.Client.AddUser(tbLogin.Text, HashHelper.StringHash(tbPass.Text), tbEmail.Text);
            if (result)
            {
                MessageBox.Show("good");
            }
            else
            {
                MessageBox.Show("failure");
            }
        }

        private bool IsCheckValues()
        {
            lbPassStatus.Text = "";
            lbConfirmPassStatus.Text = "";
            lbLoginStatus.Text = "";

            if (RegexCheck.CheckLoginPass(tbLogin.Text) || tbLogin.Text.Length == 0)
            {
                lbLoginStatus.Visible = true;
                lbLoginStatus.Text = "Логин заполнен некорректно";
            }

            if (RegexCheck.CheckLoginPass(tbPass.Text) || tbPass.Text.Length < 3)
            {
                lbPassStatus.Visible = true;
                lbPassStatus.Text = "Пароль заполнен некорректно";
            }

            if (tbPass.Text != tbConfirmPass.Text)
            {
                lbConfirmPassStatus.Visible = true;
                lbConfirmPassStatus.Text = "Подтверждение пароля некорректно";
            }

            return (lbPassStatus.Text == "") && (lbLoginStatus.Text == "") && (lbConfirmPassStatus.Text == "");
        }

        private void tbPass_Leave(object sender, EventArgs e)
        {
            lbPassStatus.Visible = false;
        }

        private void tbPass_Enter(object sender, EventArgs e)
        {
            lbPassStatus.Visible = true;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = IfOKAvailable();
        }

        private bool IfOKAvailable()
        {
            if ((tbLogin.Text != "") && (tbPass.Text != "") && (tbConfirmPass.Text != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tbConfirmPass_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = IfOKAvailable();
        }
    }
}
