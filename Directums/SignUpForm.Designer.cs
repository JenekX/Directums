namespace Directums.Client
{
    partial class SignUpForm
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
            this.lbPass = new System.Windows.Forms.Label();
            this.lbConfirmPass = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbConfirmPass = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbInformation = new System.Windows.Forms.Label();
            this.lbPassStatus = new System.Windows.Forms.Label();
            this.lbLoginStatus = new System.Windows.Forms.Label();
            this.lbConfirmPassStatus = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbEmailStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(12, 81);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(49, 13);
            this.lbPass.TabIndex = 1;
            this.lbPass.Text = "Пароль*";
            // 
            // lbConfirmPass
            // 
            this.lbConfirmPass.AutoSize = true;
            this.lbConfirmPass.Location = new System.Drawing.Point(12, 119);
            this.lbConfirmPass.Name = "lbConfirmPass";
            this.lbConfirmPass.Size = new System.Drawing.Size(104, 13);
            this.lbConfirmPass.TabIndex = 2;
            this.lbConfirmPass.Text = "Повторите пароль*";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(12, 157);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(42, 13);
            this.lbEmail.TabIndex = 3;
            this.lbEmail.Text = "E-mail *";
            // 
            // tbLogin
            // 
            this.tbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogin.Location = new System.Drawing.Point(122, 40);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(238, 20);
            this.tbLogin.TabIndex = 6;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // tbPass
            // 
            this.tbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPass.Location = new System.Drawing.Point(122, 78);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(238, 20);
            this.tbPass.TabIndex = 7;
            this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            this.tbPass.Enter += new System.EventHandler(this.tbPass_Enter);
            this.tbPass.Leave += new System.EventHandler(this.tbPass_Leave);
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConfirmPass.Location = new System.Drawing.Point(122, 116);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.Size = new System.Drawing.Size(238, 20);
            this.tbConfirmPass.TabIndex = 8;
            this.tbConfirmPass.TextChanged += new System.EventHandler(this.tbConfirmPass_TextChanged);
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(122, 154);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(238, 20);
            this.tbEmail.TabIndex = 9;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(134, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 24);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Ок";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 24);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbInformation
            // 
            this.lbInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInformation.Location = new System.Drawing.Point(12, 9);
            this.lbInformation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(348, 20);
            this.lbInformation.TabIndex = 14;
            this.lbInformation.Text = "Регистрационная информация";
            this.lbInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPassStatus
            // 
            this.lbPassStatus.AutoSize = true;
            this.lbPassStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPassStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbPassStatus.Location = new System.Drawing.Point(120, 101);
            this.lbPassStatus.Name = "lbPassStatus";
            this.lbPassStatus.Size = new System.Drawing.Size(68, 12);
            this.lbPassStatus.TabIndex = 15;
            this.lbPassStatus.Text = "Статус пароля";
            // 
            // lbLoginStatus
            // 
            this.lbLoginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLoginStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbLoginStatus.Location = new System.Drawing.Point(120, 63);
            this.lbLoginStatus.Name = "lbLoginStatus";
            this.lbLoginStatus.Size = new System.Drawing.Size(66, 12);
            this.lbLoginStatus.TabIndex = 16;
            this.lbLoginStatus.Text = "Статус логина";
            // 
            // lbConfirmPassStatus
            // 
            this.lbConfirmPassStatus.AutoSize = true;
            this.lbConfirmPassStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbConfirmPassStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbConfirmPassStatus.Location = new System.Drawing.Point(120, 139);
            this.lbConfirmPassStatus.Name = "lbConfirmPassStatus";
            this.lbConfirmPassStatus.Size = new System.Drawing.Size(104, 12);
            this.lbConfirmPassStatus.TabIndex = 17;
            this.lbConfirmPassStatus.Text = "Статус повтора пароля";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(12, 43);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(42, 13);
            this.lbLogin.TabIndex = 1;
            this.lbLogin.Text = "Логин*";
            // 
            // lbEmailStatus
            // 
            this.lbEmailStatus.AutoSize = true;
            this.lbEmailStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmailStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbEmailStatus.Location = new System.Drawing.Point(120, 177);
            this.lbEmailStatus.Name = "lbEmailStatus";
            this.lbEmailStatus.Size = new System.Drawing.Size(63, 12);
            this.lbEmailStatus.TabIndex = 18;
            this.lbEmailStatus.Text = "Статус E-mail";
            // 
            // SignUpForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 235);
            this.ControlBox = false;
            this.Controls.Add(this.lbEmailStatus);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.lbConfirmPassStatus);
            this.Controls.Add(this.lbLoginStatus);
            this.Controls.Add(this.lbPassStatus);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbConfirmPass);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbConfirmPass);
            this.Controls.Add(this.lbPass);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Label lbConfirmPass;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbConfirmPass;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.Label lbPassStatus;
        private System.Windows.Forms.Label lbLoginStatus;
        private System.Windows.Forms.Label lbConfirmPassStatus;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbEmailStatus;
    }
}