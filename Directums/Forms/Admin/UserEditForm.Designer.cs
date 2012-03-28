namespace Directums.Client.Forms.Admin
{
    partial class UserEditForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.rbStatus0 = new System.Windows.Forms.RadioButton();
            this.rbStatus1 = new System.Windows.Forms.RadioButton();
            this.rbStatus2 = new System.Windows.Forms.RadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbLoginStatus = new System.Windows.Forms.Label();
            this.lbEmailStatus = new System.Windows.Forms.Label();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(141, 282);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(222, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbLogin
            // 
            this.lbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogin.Location = new System.Drawing.Point(12, 9);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(56, 13);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "Логин:";
            // 
            // tbLogin
            // 
            this.tbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogin.Location = new System.Drawing.Point(12, 25);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(285, 20);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            this.tbLogin.Leave += new System.EventHandler(this.tbLogin_Leave);
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(12, 80);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(285, 20);
            this.tbEmail.TabIndex = 4;
            this.tbEmail.Leave += new System.EventHandler(this.tbLogin_Leave);
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmail.Location = new System.Drawing.Point(12, 64);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(285, 13);
            this.lbEmail.TabIndex = 3;
            this.lbEmail.Text = "E-mail:";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetPassword.Location = new System.Drawing.Point(12, 282);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(105, 23);
            this.btnResetPassword.TabIndex = 8;
            this.btnResetPassword.Text = "Сбросить пароль";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // rbStatus0
            // 
            this.rbStatus0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbStatus0.Checked = true;
            this.rbStatus0.Location = new System.Drawing.Point(6, 19);
            this.rbStatus0.Name = "rbStatus0";
            this.rbStatus0.Size = new System.Drawing.Size(273, 17);
            this.rbStatus0.TabIndex = 0;
            this.rbStatus0.TabStop = true;
            this.rbStatus0.Text = "Не активен";
            this.rbStatus0.UseVisualStyleBackColor = true;
            // 
            // rbStatus1
            // 
            this.rbStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbStatus1.Location = new System.Drawing.Point(6, 42);
            this.rbStatus1.Name = "rbStatus1";
            this.rbStatus1.Size = new System.Drawing.Size(273, 17);
            this.rbStatus1.TabIndex = 1;
            this.rbStatus1.Text = "Активен";
            this.rbStatus1.UseVisualStyleBackColor = true;
            // 
            // rbStatus2
            // 
            this.rbStatus2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbStatus2.Location = new System.Drawing.Point(6, 65);
            this.rbStatus2.Name = "rbStatus2";
            this.rbStatus2.Size = new System.Drawing.Size(273, 17);
            this.rbStatus2.TabIndex = 2;
            this.rbStatus2.Text = "Заблокирован";
            this.rbStatus2.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatus.Controls.Add(this.rbStatus0);
            this.gbStatus.Controls.Add(this.rbStatus1);
            this.gbStatus.Controls.Add(this.rbStatus2);
            this.gbStatus.Location = new System.Drawing.Point(12, 188);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(285, 88);
            this.gbStatus.TabIndex = 7;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Статус:";
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.Location = new System.Drawing.Point(12, 119);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(285, 66);
            this.lbInfo.TabIndex = 6;
            this.lbInfo.Text = "Фамилия:\r\nИмя:\r\nОтчество:\r\nДата рождения:";
            // 
            // lbLoginStatus
            // 
            this.lbLoginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLoginStatus.ForeColor = System.Drawing.Color.Red;
            this.lbLoginStatus.Location = new System.Drawing.Point(12, 48);
            this.lbLoginStatus.Name = "lbLoginStatus";
            this.lbLoginStatus.Size = new System.Drawing.Size(285, 13);
            this.lbLoginStatus.TabIndex = 2;
            this.lbLoginStatus.Text = "Статус логина";
            this.lbLoginStatus.Visible = false;
            // 
            // lbEmailStatus
            // 
            this.lbEmailStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmailStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmailStatus.ForeColor = System.Drawing.Color.Red;
            this.lbEmailStatus.Location = new System.Drawing.Point(12, 103);
            this.lbEmailStatus.Name = "lbEmailStatus";
            this.lbEmailStatus.Size = new System.Drawing.Size(285, 13);
            this.lbEmailStatus.TabIndex = 5;
            this.lbEmailStatus.Text = "Статус E-mail";
            this.lbEmailStatus.Visible = false;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 317);
            this.Controls.Add(this.lbEmailStatus);
            this.Controls.Add(this.lbLoginStatus);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserEditForm";
            this.Text = "Редактирование пользователя";
            this.gbStatus.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.RadioButton rbStatus0;
        private System.Windows.Forms.RadioButton rbStatus1;
        private System.Windows.Forms.RadioButton rbStatus2;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbLoginStatus;
        private System.Windows.Forms.Label lbEmailStatus;
    }
}