using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;

namespace Directums.Client.Forms.Client
{
    public partial class TagsForm : DirectumsForm
    {
        private int idFile = 0;

        private void FillForm()
        {
            lbTags.Items.Clear();

            var tags = Config.Client.GetTags(idFile);
            foreach (var tag in tags)
            {
                lbTags.Items.Add(tag.Name);
            }
        }

        private int GetSelectedIndex()
        {
            return lbTags.SelectedIndex;
        }

        private string GetSelectedTag()
        {
            int index = GetSelectedIndex();

            if (index != -1)
            {
                return (string)lbTags.Items[index];
            }

            return "";
        }

        private List<string> GetTags()
        {
            return lbTags.Items.Cast<string>().ToList();
        }

        private void RefreshMenu()
        {
            bool enabled = GetSelectedIndex() != -1;

            tsmEdit.Enabled = tsmDelete.Enabled = enabled;
        }

        private void Initialize(int idFile)
        {
            this.idFile = idFile;

            FillForm();

            RefreshMenu();
        }

        public TagsForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static bool Execute(DirectumsForm ownerForm, int idFile)
        {
            TagsForm form = new TagsForm(ownerForm.Config);
            form.Initialize(idFile);
            
            return form.ShowDialog(ownerForm) == DialogResult.OK;
        }

        private void cmTags_Opening(object sender, CancelEventArgs e)
        {
            RefreshMenu();
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            string tag = EditTagForm.Execute(this);
            
            if (tag.Length > 0 && GetTags().IndexOf(tag) == -1)
            {
                lbTags.Items.Add(tag);
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();
            string selTag = GetSelectedTag();

            string tag = EditTagForm.Execute(this, selTag);

            if (tag.Length > 0 && tag != selTag && GetTags().IndexOf(tag) == -1)
            {
                lbTags.Items[index] = tag;
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            lbTags.Items.RemoveAt(index);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool result = Config.Client.SetTags(idFile, GetTags().ToArray());

            if (!result)
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}