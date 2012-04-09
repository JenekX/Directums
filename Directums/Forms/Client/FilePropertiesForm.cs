using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using Directums.Classes.Core;

namespace Directums.Client.Forms.Client
{
    public partial class FilePropertiesForm : DirectumsForm
    {
        private int idFile = 0;

        private bool FillForm()
        {
            var properties = Config.Client.GetFileProperties(idFile);
            if (properties == null)
            {
                return false;
            }

            tbName.Text = properties.Name;
            tbExtension.Text = properties.Extension;
            tbDescription.Text = properties.Description;
            tagsPicker.IdFile = idFile;
            ownerPicker.User = properties.Owner;

            bool enabled = properties.Owner.Id == Config.User.Id;

            tbName.ReadOnly = tbDescription.ReadOnly = tagsPicker.ReadOnly = !enabled;
            btnAccessRights.Enabled = enabled;

            return true;
        }

        private bool Initialize(int idFile)
        {
            this.idFile = idFile;

            if (!FillForm())
            {
                return false;
            }

            RefreshInterface();
            return true;
        }

        private bool CheckForm()
        {
            return RegexCheck.CheckFileName(tbName.Text);
        }

        private void RefreshInterface()
        {
            btnOk.Enabled = CheckForm(); 
        }

        public FilePropertiesForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static bool Execute(DirectumsForm ownerForm, int idFile)
        {
            var form = new FilePropertiesForm(ownerForm.Config);
            if (!form.Initialize(idFile))
            {
                return false;
            }

            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            RefreshInterface();
        }

        private void btnAccessRights_Click(object sender, EventArgs e)
        {
            FileAccessRightsForm.Execute(this, idFile);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                if (Config.Client.UpdateFileProperties(idFile, tbName.Text, tbDescription.Text))
                {
                    return;
                }
            }

            DialogResult = DialogResult.None;
        }
    }
}
