using System;
using System.Windows.Forms;
using Directums.Classes;
using Directums.Client.Classes;

namespace Directums.Client.Forms.Admin
{
    public partial class UserFilterForm : DirectumsForm
    {
        private UserFilter filter = null;

        private void FillForm()
        {
            tbId.Text = filter.IdToStr();
            tbLogin.Text = filter.Login;
            tbEmail.Text = filter.Email;
            tbSurname.Text = filter.Surname;
            tbName.Text = filter.Name;
            tbPatronymic.Text = filter.Patronymic;

            cbStatus0.Checked = filter.Status[0];
            cbStatus1.Checked = filter.Status[1];
            cbStatus2.Checked = filter.Status[2];

            dpFrom.Checked = filter.BornDateFrom.HasValue;
            if (dpFrom.Checked)
            {
                dpFrom.Value = filter.BornDateFrom.Value;
            }

            dpTo.Checked = filter.BornDateTo.HasValue;
            if (dpTo.Checked)
            {
                dpTo.Value = filter.BornDateTo.Value;
            }
        }

        private void FillFilter()
        {
            filter.ParseId(tbId.Text);
            filter.Login = tbLogin.Text;
            filter.Email = tbEmail.Text;
            filter.Surname = tbSurname.Text;
            filter.Name = tbName.Text;
            filter.Patronymic = tbPatronymic.Text;

            filter.Status[0] = cbStatus0.Checked;
            filter.Status[1] = cbStatus1.Checked;
            filter.Status[2] = cbStatus2.Checked;

            if (dpFrom.Checked)
            {
                filter.BornDateFrom = dpFrom.Value;
            }
            else
            {
                filter.BornDateFrom = null;
            }

            if (dpTo.Checked)
            {
                filter.BornDateTo = dpTo.Value;
            }
            else
            {
                filter.BornDateTo = null;
            }
        }

        public UserFilterForm(DirectumsConfig config, UserFilter filter) : base(config)
        {
            InitializeComponent();

            this.filter = filter;
            FillForm();
        }

        public static bool Execute(DirectumsConfig config, UserFilter filter)
        {
            UserFilterForm form = new UserFilterForm(config, filter);
            return form.ShowDialog() == DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FillFilter();
        }
    }
}