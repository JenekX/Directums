using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Client
{
    public partial class EditProfileForm : DirectumsForm
    {
        private User user = null;

        private bool[] valids = {true, true, true};

        public EditProfileForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static bool Execute(DirectumsForm ownerForm)
        {
            EditProfileForm form = new EditProfileForm(ownerForm.Config);
            form.Initialize();
 
            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        public void Initialize()
        {
            this.user = Config.User;

            FillForm();
            RefreshInterface();
        }

        private void RefreshInterface()
        {
            btnOK.Enabled = !valids.Contains(false);    
        }

        private void FillForm()
        {
            tbSurname.Text = user.Surname;
            tbName.Text = user.Name;
            tbPatronymic.Text = user.Patronymic;
            if (user.BornDate != null)
            {
                dtpBirthday.Value = (DateTime) (user.BornDate ?? DateTime.Now);
                dtpBirthday.Checked = true;
            }        
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!FullCheck())
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else
            {              
                Config.Client.UpdateProfile(tbSurname.Text, tbName.Text, tbPatronymic.Text, (dtpBirthday.Checked) ? (new DateTime?(dtpBirthday.Value)) : null, ((tbPass.Text.Length == 0) ? "" : HashHelper.StringHash(tbPass.Text)));
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool FullCheck()
        {
            return CheckFullName() && CheckPass() && CheckConfirmPass();
        }

        private bool CheckFullName()
        {
            valids[0] = true;
            lbStatusName.Visible = false;
            lbSurnameStatus.Visible = false;
            lbStatusPatronymic.Visible = false;

            if (!RegexCheck.CheckNames(tbSurname.Text) && tbSurname.Text.Length != 0)
            {
                lbSurnameStatus.Text = "Фамилия заполнена некорректно";
                lbSurnameStatus.Visible = true;

                valids[0] = false;
            }

            if (!RegexCheck.CheckNames(tbName.Text) && tbName.Text.Length != 0)
            {
                lbStatusName.Text = "Имя заполнено некорректно";
                lbStatusName.Visible = true;

                valids[0] = false;
            }

            if (!RegexCheck.CheckNames(tbPatronymic.Text) && tbPatronymic.Text.Length != 0)
            {
                lbStatusPatronymic.Text = "Отчество заполнено некорректно";
                lbStatusPatronymic.Visible = true;

                valids[0] = false;
            }

            return valids[0];
        }

        private bool CheckPass()
        {
            valids[1] = true;
            lbStatusPass.Visible = false;
            string passEntering = tbPass.Text;

            if (passEntering.Length == 0)
            {
                return true;
            }

            if (passEntering.Length < 3)
            {
                lbStatusPass.Text = "Некорректная длина пароля";
                valids[1] = false;
                return false;
            }

            if (RegexCheck.CheckLoginPass(passEntering))
            {
                lbStatusPass.Text = "В пароле присутствуют не корректные символы";
                valids[1] = false;
                return false;
            }

            if (passEntering.Length >= 3 && (RegexCheck.CheckDigits(passEntering) || RegexCheck.CheckLowLetter(passEntering) || RegexCheck.CheckUpLetters(passEntering)))
            {
                lbStatusPass.Text = "Хреновый пароль";
            }

            if (tbPass.Text.Length >= 5 &&
                (RegexCheck.CheckDigits(passEntering) && (RegexCheck.CheckLowLetter(passEntering) || RegexCheck.CheckUpLetters(passEntering)))
                || (RegexCheck.CheckLowLetter(passEntering) && RegexCheck.CheckUpLetters(passEntering)))
            {
                lbStatusPass.Text = "Нормально так";
            }

            if (tbPass.Text.Length > 7 && (RegexCheck.CheckDigits(passEntering) && RegexCheck.CheckLowLetter(passEntering) && RegexCheck.CheckUpLetters(passEntering)))
            {
                lbStatusPass.Text = "Заебись!!!!";
            }

            return valids[1];
        }

        private bool CheckConfirmPass()
        {
            lbStatusPassConfirm.Text = "";
            lbStatusPassConfirm.Visible = false;
            valids[2] = true;

            if (tbPass.Text != "" && tbPass.Text != tbConfirmPass.Text)
            {
                lbStatusPassConfirm.Text = "Подтверждение пароля некорректно";
                valids[2] = false;
            }

            return valids[2];
        }

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            if (sender == tbSurname || sender == tbName || sender == tbPatronymic)
            {
                CheckFullName();
            }
            else if (sender == tbPass)
            {
                CheckPass();
            }
            else if (sender == tbConfirmPass)
            {
                CheckConfirmPass();
            }

            RefreshInterface();
        }

    }
}
