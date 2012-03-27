using System;
using System.Linq;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client
{
    public partial class SignUpForm : DirectumsForm
    {
        private bool[] valids = { false, false, false, false };

        private bool CheckLogin(bool request)
        {
            lbLoginStatus.Text = "";
            valids[0] = true;

            if (RegexCheck.CheckLogin(tbLogin.Text))
            {
                if (request && !Config.Client.IsLoginEmpty(tbLogin.Text))
                {
                    lbLoginStatus.Text = "Такой логин уже занят";
                    valids[0] = false;
                }
            }
            else
            {
                lbLoginStatus.Text = "Логин заполнен некорректно";
                valids[0] = false;
            }

            return valids[0];
        }

        private bool CheckEmail(bool request)
        {
            lbEmailStatus.Text = "";
            valids[1] = true;

            if (RegexCheck.CheckEmail(tbEmail.Text))
            {
                if (request && !Config.Client.IsEmailEmpty(tbEmail.Text))
                {
                    lbEmailStatus.Text = "Такой e-mail уже занят";
                    valids[1] = false;
                }
            }
            else
            {
                lbEmailStatus.Text = "Некорректный e-mail";
                valids[1] = false;
            }

            return valids[1];
        }

        private bool CheckPassword()
        {
            valids[2] = true;
            string passEntering = tbPass.Text;

            if (passEntering.Length < 3)
            {
                lbPassStatus.Text = "Некорректная длина пароля";
                valids[2] = false;
                return false;
            }

            if (RegexCheck.CheckLoginPass(passEntering))
            {
                lbPassStatus.Text = "В пароле присутствуют не корректные символы";
                valids[2] = false;
                return false;
            }

            if (passEntering.Length >= 3 && (RegexCheck.CheckDigits(passEntering) || RegexCheck.CheckLowLetter(passEntering) || RegexCheck.CheckUpLetters(passEntering)))
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

            return valids[2];
        }

        private bool CheckConfirmPassword()
        {
            lbConfirmPassStatus.Text = "";
            valids[3] = true;

            if (tbPass.Text != "" && tbPass.Text != tbConfirmPass.Text)
            {
                lbConfirmPassStatus.Text = "Подтверждение пароля некорректно";
                valids[3] = false;
            }

            return valids[3];
        }

        private void RefreshInterface()
        {
            btnOK.Enabled = valids.Count(x => x) == valids.Length;
        }

        public SignUpForm(DirectumsConfig config)
            : base(config)
        {
            InitializeComponent();

            lbLoginStatus.Text = lbPassStatus.Text = lbConfirmPassStatus.Text = lbEmailStatus.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = Config.Client.AddUser(tbLogin.Text, tbEmail.Text, HashHelper.StringHash(tbPass.Text));
            if (result)
            {
                DialogHelper.Information(this, "Новый пользователь зарегистрирован. Вы может войти с указанным вами логином и паролем");
            }
            else
            {
                DialogHelper.Error(this, "Во время регистрации пользователя произошла ошибка");
                DialogResult = DialogResult.None;
            }
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
            else if (sender == tbPass || sender == tbConfirmPass)
            {
                CheckPassword();
                CheckConfirmPassword();
            }

            RefreshInterface();
        }
    }
}