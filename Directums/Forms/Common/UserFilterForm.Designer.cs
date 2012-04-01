namespace Directums.Client.Forms.Common
{
    partial class UserFilterForm
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
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbBornDate = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.cbStatus2 = new System.Windows.Forms.CheckBox();
            this.cbStatus1 = new System.Windows.Forms.CheckBox();
            this.cbStatus0 = new System.Windows.Forms.CheckBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.tbPatronymic = new System.Windows.Forms.TextBox();
            this.lbPatronymic = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbSurname = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(12, 25);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 20);
            this.tbId.TabIndex = 1;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(168, 131);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(19, 13);
            this.lbTo.TabIndex = 19;
            this.lbTo.Text = "по";
            this.lbTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(168, 105);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(13, 13);
            this.lbFrom.TabIndex = 17;
            this.lbFrom.Text = "с";
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBornDate
            // 
            this.lbBornDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBornDate.Location = new System.Drawing.Point(157, 87);
            this.lbBornDate.Name = "lbBornDate";
            this.lbBornDate.Size = new System.Drawing.Size(197, 13);
            this.lbBornDate.TabIndex = 16;
            this.lbBornDate.Text = "Дата рождения";
            // 
            // dpTo
            // 
            this.dpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dpTo.Location = new System.Drawing.Point(193, 129);
            this.dpTo.Name = "dpTo";
            this.dpTo.ShowCheckBox = true;
            this.dpTo.Size = new System.Drawing.Size(161, 20);
            this.dpTo.TabIndex = 20;
            // 
            // dpFrom
            // 
            this.dpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFrom.Location = new System.Drawing.Point(193, 103);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.ShowCheckBox = true;
            this.dpFrom.Size = new System.Drawing.Size(161, 20);
            this.dpFrom.TabIndex = 18;
            // 
            // cbStatus2
            // 
            this.cbStatus2.Location = new System.Drawing.Point(24, 139);
            this.cbStatus2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cbStatus2.Name = "cbStatus2";
            this.cbStatus2.Size = new System.Drawing.Size(104, 15);
            this.cbStatus2.TabIndex = 15;
            this.cbStatus2.Text = "Заблокированный";
            this.cbStatus2.UseVisualStyleBackColor = true;
            // 
            // cbStatus1
            // 
            this.cbStatus1.Location = new System.Drawing.Point(24, 121);
            this.cbStatus1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cbStatus1.Name = "cbStatus1";
            this.cbStatus1.Size = new System.Drawing.Size(104, 15);
            this.cbStatus1.TabIndex = 14;
            this.cbStatus1.Text = "Активный";
            this.cbStatus1.UseVisualStyleBackColor = true;
            // 
            // cbStatus0
            // 
            this.cbStatus0.Location = new System.Drawing.Point(24, 103);
            this.cbStatus0.Name = "cbStatus0";
            this.cbStatus0.Size = new System.Drawing.Size(104, 15);
            this.cbStatus0.TabIndex = 13;
            this.cbStatus0.Text = "Не активный";
            this.cbStatus0.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(12, 87);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(100, 13);
            this.lbStatus.TabIndex = 12;
            this.lbStatus.Text = "Статус";
            // 
            // lbId
            // 
            this.lbId.Location = new System.Drawing.Point(12, 9);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(100, 13);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "Код";
            // 
            // tbPatronymic
            // 
            this.tbPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPatronymic.Location = new System.Drawing.Point(224, 64);
            this.tbPatronymic.Name = "tbPatronymic";
            this.tbPatronymic.Size = new System.Drawing.Size(130, 20);
            this.tbPatronymic.TabIndex = 11;
            // 
            // lbPatronymic
            // 
            this.lbPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPatronymic.Location = new System.Drawing.Point(224, 48);
            this.lbPatronymic.Name = "lbPatronymic";
            this.lbPatronymic.Size = new System.Drawing.Size(130, 13);
            this.lbPatronymic.TabIndex = 10;
            this.lbPatronymic.Text = "Отчество";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(118, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 9;
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(118, 48);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(100, 13);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "Имя";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(12, 64);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 20);
            this.tbSurname.TabIndex = 7;
            // 
            // lbSurname
            // 
            this.lbSurname.Location = new System.Drawing.Point(12, 48);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(100, 13);
            this.lbSurname.TabIndex = 6;
            this.lbSurname.Text = "Фамилия";
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(224, 25);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(130, 20);
            this.tbEmail.TabIndex = 5;
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmail.Location = new System.Drawing.Point(224, 9);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(130, 13);
            this.lbEmail.TabIndex = 4;
            this.lbEmail.Text = "E-mail";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(118, 25);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 3;
            // 
            // lbLogin
            // 
            this.lbLogin.Location = new System.Drawing.Point(118, 9);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(100, 13);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Логин";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(198, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UserFilterForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 190);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.lbBornDate);
            this.Controls.Add(this.dpTo);
            this.Controls.Add(this.dpFrom);
            this.Controls.Add(this.cbStatus2);
            this.Controls.Add(this.cbStatus1);
            this.Controls.Add(this.cbStatus0);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.tbPatronymic);
            this.Controls.Add(this.lbPatronymic);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserFilterForm";
            this.Text = "Фильтр пользователей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbPatronymic;
        private System.Windows.Forms.Label lbPatronymic;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.CheckBox cbStatus0;
        private System.Windows.Forms.CheckBox cbStatus1;
        private System.Windows.Forms.CheckBox cbStatus2;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label lbBornDate;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.TextBox tbId;
    }
}