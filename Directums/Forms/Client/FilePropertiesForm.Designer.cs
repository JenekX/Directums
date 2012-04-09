namespace Directums.Client.Forms.Client
{
    partial class FilePropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ownerPicker = new Directums.Client.Controls.Client.UserPicker();
            this.tagsPicker = new Directums.Client.Controls.Client.TagsPicker();
            this.btnAccessRights = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.dpCreated = new System.Windows.Forms.DateTimePicker();
            this.tbExtension = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ownerPicker
            // 
            this.ownerPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerPicker.Location = new System.Drawing.Point(12, 258);
            this.ownerPicker.MaximumSize = new System.Drawing.Size(2000, 36);
            this.ownerPicker.MinimumSize = new System.Drawing.Size(200, 36);
            this.ownerPicker.Name = "ownerPicker";
            this.ownerPicker.ReadOnly = true;
            this.ownerPicker.Size = new System.Drawing.Size(257, 36);
            this.ownerPicker.TabIndex = 7;
            this.ownerPicker.Title = "Владелец:";
            this.ownerPicker.User = null;
            // 
            // tagsPicker
            // 
            this.tagsPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsPicker.IdFile = 0;
            this.tagsPicker.Location = new System.Drawing.Point(12, 216);
            this.tagsPicker.MaximumSize = new System.Drawing.Size(2000, 36);
            this.tagsPicker.MinimumSize = new System.Drawing.Size(200, 36);
            this.tagsPicker.Name = "tagsPicker";
            this.tagsPicker.ReadOnly = false;
            this.tagsPicker.Size = new System.Drawing.Size(257, 36);
            this.tagsPicker.TabIndex = 6;
            this.tagsPicker.Title = "Теги:";
            // 
            // btnAccessRights
            // 
            this.btnAccessRights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccessRights.Location = new System.Drawing.Point(12, 339);
            this.btnAccessRights.Name = "btnAccessRights";
            this.btnAccessRights.Size = new System.Drawing.Size(95, 23);
            this.btnAccessRights.TabIndex = 10;
            this.btnAccessRights.Text = "Права доступа";
            this.btnAccessRights.UseVisualStyleBackColor = true;
            this.btnAccessRights.Click += new System.EventHandler(this.btnAccessRights_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(12, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(172, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(172, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Наименование:";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(12, 64);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(257, 146);
            this.tbDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(12, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(257, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание:";
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.Location = new System.Drawing.Point(12, 297);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(257, 13);
            this.lblCreated.TabIndex = 8;
            this.lblCreated.Text = "Создан:";
            // 
            // dpCreated
            // 
            this.dpCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dpCreated.Enabled = false;
            this.dpCreated.Location = new System.Drawing.Point(12, 313);
            this.dpCreated.Name = "dpCreated";
            this.dpCreated.Size = new System.Drawing.Size(257, 20);
            this.dpCreated.TabIndex = 9;
            // 
            // tbExtension
            // 
            this.tbExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtension.Location = new System.Drawing.Point(190, 25);
            this.tbExtension.Name = "tbExtension";
            this.tbExtension.ReadOnly = true;
            this.tbExtension.Size = new System.Drawing.Size(79, 20);
            this.tbExtension.TabIndex = 3;
            // 
            // lblExtension
            // 
            this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtension.Location = new System.Drawing.Point(190, 9);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(79, 13);
            this.lblExtension.TabIndex = 2;
            this.lblExtension.Text = "Расширение:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(113, 339);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FilePropertiesForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(281, 374);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbExtension);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.dpCreated);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAccessRights);
            this.Controls.Add(this.tagsPicker);
            this.Controls.Add(this.ownerPicker);
            this.MinimumSize = new System.Drawing.Size(297, 412);
            this.Name = "FilePropertiesForm";
            this.Text = "Свойства документа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Client.UserPicker ownerPicker;
        private Controls.Client.TagsPicker tagsPicker;
        private System.Windows.Forms.Button btnAccessRights;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.DateTimePicker dpCreated;
        private System.Windows.Forms.TextBox tbExtension;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}