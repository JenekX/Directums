namespace Directums.Client.Forms.Admin
{
    partial class UserManagementForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lbPage = new System.Windows.Forms.Label();
            this.cmbPage = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatronymic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBornDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbUsers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "status-0");
            this.imageList.Images.SetKeyName(1, "status-1");
            this.imageList.Images.SetKeyName(2, "status-2");
            // 
            // lbPage
            // 
            this.lbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPage.Location = new System.Drawing.Point(575, 8);
            this.lbPage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(58, 21);
            this.lbPage.TabIndex = 9;
            this.lbPage.Text = "Страница:";
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPage
            // 
            this.cmbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPage.FormattingEnabled = true;
            this.cmbPage.Items.AddRange(new object[] {
            "0"});
            this.cmbPage.Location = new System.Drawing.Point(636, 8);
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.Size = new System.Drawing.Size(51, 21);
            this.cmbPage.TabIndex = 8;
            this.cmbPage.SelectionChangeCommitted += new System.EventHandler(this.cmbPage_SelectedIndexChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilter.Location = new System.Drawing.Point(174, 277);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(432, 23);
            this.lbFilter.TabIndex = 7;
            this.lbFilter.Text = "Фильтр: не используется";
            this.lbFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(93, 277);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(12, 277);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(612, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lvUsers
            // 
            this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderLogin,
            this.columnHeaderEmail,
            this.columnHeaderSurname,
            this.columnHeaderName,
            this.columnHeaderPatronymic,
            this.columnHeaderBornDate});
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.Location = new System.Drawing.Point(12, 33);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(675, 238);
            this.lvUsers.SmallImageList = this.imageList;
            this.lvUsers.TabIndex = 1;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.DoubleClick += new System.EventHandler(this.lvUsers_DoubleClick);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Код";
            this.columnHeaderId.Width = 40;
            // 
            // columnHeaderLogin
            // 
            this.columnHeaderLogin.Text = "Логин";
            this.columnHeaderLogin.Width = 85;
            // 
            // columnHeaderEmail
            // 
            this.columnHeaderEmail.Text = "E-mail";
            this.columnHeaderEmail.Width = 132;
            // 
            // columnHeaderSurname
            // 
            this.columnHeaderSurname.Text = "Фамилия";
            this.columnHeaderSurname.Width = 95;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Имя";
            this.columnHeaderName.Width = 89;
            // 
            // columnHeaderPatronymic
            // 
            this.columnHeaderPatronymic.Text = "Отчество";
            this.columnHeaderPatronymic.Width = 98;
            // 
            // columnHeaderBornDate
            // 
            this.columnHeaderBornDate.Text = "Дата рождения";
            this.columnHeaderBornDate.Width = 110;
            // 
            // lbUsers
            // 
            this.lbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsers.Location = new System.Drawing.Point(12, 8);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(557, 21);
            this.lbUsers.TabIndex = 0;
            this.lbUsers.Text = "Пользователи:";
            this.lbUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 312);
            this.Controls.Add(this.lbPage);
            this.Controls.Add(this.cmbPage);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.lbUsers);
            this.MinimumSize = new System.Drawing.Size(715, 250);
            this.Name = "UserManagementForm";
            this.Text = "Управление пользователями";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbUsers;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.ComboBox cmbPage;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderLogin;
        private System.Windows.Forms.ColumnHeader columnHeaderEmail;
        private System.Windows.Forms.ColumnHeader columnHeaderSurname;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPatronymic;
        private System.Windows.Forms.ColumnHeader columnHeaderBornDate;
        private System.Windows.Forms.ImageList imageList;
    }
}