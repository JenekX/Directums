namespace Directums.Client.Forms.Client
{
    partial class EditProfileForm
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
            this.lbSurname = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbPatronymic = new System.Windows.Forms.Label();
            this.tbPatronymic = new System.Windows.Forms.TextBox();
            this.lbSurnameStatus = new System.Windows.Forms.Label();
            this.lbStatusName = new System.Windows.Forms.Label();
            this.lbStatusPatronymic = new System.Windows.Forms.Label();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.lbPass = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lbStatusPass = new System.Windows.Forms.Label();
            this.lbPassConfirm = new System.Windows.Forms.Label();
            this.tbConfirmPass = new System.Windows.Forms.TextBox();
            this.lbStatusPassConfirm = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSurname
            // 
            this.lbSurname.Location = new System.Drawing.Point(3, 8);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(75, 13);
            this.lbSurname.TabIndex = 0;
            this.lbSurname.Text = "Фамилия:";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(84, 5);
            this.tbSurname.MaxLength = 64;
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(234, 20);
            this.tbSurname.TabIndex = 1;
            this.tbSurname.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            this.tbSurname.Leave += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(3, 42);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(272, 16);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Имя:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(84, 39);
            this.tbName.MaxLength = 64;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(234, 20);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            this.tbName.Leave += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbPatronymic
            // 
            this.lbPatronymic.Location = new System.Drawing.Point(3, 76);
            this.lbPatronymic.Name = "lbPatronymic";
            this.lbPatronymic.Size = new System.Drawing.Size(60, 15);
            this.lbPatronymic.TabIndex = 4;
            this.lbPatronymic.Text = "Отчество:";
            // 
            // tbPatronymic
            // 
            this.tbPatronymic.Location = new System.Drawing.Point(84, 75);
            this.tbPatronymic.MaxLength = 64;
            this.tbPatronymic.Name = "tbPatronymic";
            this.tbPatronymic.Size = new System.Drawing.Size(234, 20);
            this.tbPatronymic.TabIndex = 5;
            this.tbPatronymic.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            this.tbPatronymic.Leave += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbSurnameStatus
            // 
            this.lbSurnameStatus.AllowDrop = true;
            this.lbSurnameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSurnameStatus.ForeColor = System.Drawing.Color.Red;
            this.lbSurnameStatus.Location = new System.Drawing.Point(81, 25);
            this.lbSurnameStatus.Name = "lbSurnameStatus";
            this.lbSurnameStatus.Size = new System.Drawing.Size(237, 14);
            this.lbSurnameStatus.TabIndex = 6;
            this.lbSurnameStatus.Text = "Статус фамилии";
            this.lbSurnameStatus.Visible = false;
            // 
            // lbStatusName
            // 
            this.lbStatusName.AutoSize = true;
            this.lbStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusName.ForeColor = System.Drawing.Color.Red;
            this.lbStatusName.Location = new System.Drawing.Point(81, 62);
            this.lbStatusName.Name = "lbStatusName";
            this.lbStatusName.Size = new System.Drawing.Size(88, 13);
            this.lbStatusName.TabIndex = 7;
            this.lbStatusName.Text = "Статус имени";
            this.lbStatusName.Visible = false;
            // 
            // lbStatusPatronymic
            // 
            this.lbStatusPatronymic.AutoSize = true;
            this.lbStatusPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusPatronymic.ForeColor = System.Drawing.Color.Red;
            this.lbStatusPatronymic.Location = new System.Drawing.Point(81, 98);
            this.lbStatusPatronymic.Name = "lbStatusPatronymic";
            this.lbStatusPatronymic.Size = new System.Drawing.Size(104, 13);
            this.lbStatusPatronymic.TabIndex = 8;
            this.lbStatusPatronymic.Text = "Статус отчества";
            this.lbStatusPatronymic.Visible = false;
            // 
            // lbBirthday
            // 
            this.lbBirthday.Location = new System.Drawing.Point(3, 110);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(72, 26);
            this.lbBirthday.TabIndex = 9;
            this.lbBirthday.Text = "Дата рождения:";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(84, 116);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(234, 20);
            this.dtpBirthday.TabIndex = 10;
            // 
            // lbPass
            // 
            this.lbPass.Location = new System.Drawing.Point(3, 158);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(75, 18);
            this.lbPass.TabIndex = 11;
            this.lbPass.Text = "Пароль:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(84, 158);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(234, 20);
            this.tbPass.TabIndex = 12;
            this.tbPass.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            this.tbPass.Leave += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbStatusPass
            // 
            this.lbStatusPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusPass.ForeColor = System.Drawing.Color.Red;
            this.lbStatusPass.Location = new System.Drawing.Point(81, 178);
            this.lbStatusPass.Name = "lbStatusPass";
            this.lbStatusPass.Size = new System.Drawing.Size(254, 16);
            this.lbStatusPass.TabIndex = 13;
            this.lbStatusPass.Text = "Статус пароля";
            this.lbStatusPass.Visible = false;
            // 
            // lbPassConfirm
            // 
            this.lbPassConfirm.Location = new System.Drawing.Point(3, 192);
            this.lbPassConfirm.Name = "lbPassConfirm";
            this.lbPassConfirm.Size = new System.Drawing.Size(75, 28);
            this.lbPassConfirm.TabIndex = 14;
            this.lbPassConfirm.Text = "Подтвердите пароль:";
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.Location = new System.Drawing.Point(84, 200);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.PasswordChar = '*';
            this.tbConfirmPass.Size = new System.Drawing.Size(234, 20);
            this.tbConfirmPass.TabIndex = 15;
            this.tbConfirmPass.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            this.tbConfirmPass.Leave += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbStatusPassConfirm
            // 
            this.lbStatusPassConfirm.AutoSize = true;
            this.lbStatusPassConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusPassConfirm.ForeColor = System.Drawing.Color.Red;
            this.lbStatusPassConfirm.Location = new System.Drawing.Point(81, 223);
            this.lbStatusPassConfirm.Name = "lbStatusPassConfirm";
            this.lbStatusPassConfirm.Size = new System.Drawing.Size(189, 13);
            this.lbStatusPassConfirm.TabIndex = 16;
            this.lbStatusPassConfirm.Text = "Статус подтверждения пароля";
            this.lbStatusPassConfirm.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(29, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 34);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 34);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditProfileForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(330, 304);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbStatusPassConfirm);
            this.Controls.Add(this.tbConfirmPass);
            this.Controls.Add(this.lbPassConfirm);
            this.Controls.Add(this.lbStatusPass);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.lbBirthday);
            this.Controls.Add(this.lbStatusPatronymic);
            this.Controls.Add(this.lbStatusName);
            this.Controls.Add(this.lbSurnameStatus);
            this.Controls.Add(this.tbPatronymic);
            this.Controls.Add(this.lbPatronymic);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.lbSurname);
            this.Name = "EditProfileForm";
            this.Text = "Редактирование профиля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbPatronymic;
        private System.Windows.Forms.TextBox tbPatronymic;
        private System.Windows.Forms.Label lbSurnameStatus;
        private System.Windows.Forms.Label lbStatusName;
        private System.Windows.Forms.Label lbStatusPatronymic;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lbStatusPass;
        private System.Windows.Forms.Label lbPassConfirm;
        private System.Windows.Forms.TextBox tbConfirmPass;
        private System.Windows.Forms.Label lbStatusPassConfirm;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}