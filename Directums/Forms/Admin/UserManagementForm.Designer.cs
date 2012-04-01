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
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lbPage = new System.Windows.Forms.Label();
            this.cmbPage = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeaderLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatronymic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBornDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbUsers = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cmUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "?";
            this.columnHeaderStatus.Width = 22;
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
            this.lbFilter.Size = new System.Drawing.Size(351, 23);
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
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(612, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lvUsers
            // 
            this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStatus,
            this.columnHeaderLogin,
            this.columnHeaderEmail,
            this.columnHeaderSurname,
            this.columnHeaderName,
            this.columnHeaderPatronymic,
            this.columnHeaderBornDate});
            this.lvUsers.ContextMenuStrip = this.cmUsers;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.Location = new System.Drawing.Point(12, 33);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(675, 238);
            this.lvUsers.SmallImageList = this.imageList;
            this.lvUsers.TabIndex = 1;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            this.lvUsers.DoubleClick += new System.EventHandler(this.lvUsers_DoubleClick);
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
            // cmUsers
            // 
            this.cmUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSelect,
            this.tsmSeparator,
            this.tsmEdit,
            this.tsmStatus});
            this.cmUsers.Name = "cmGroups";
            this.cmUsers.Size = new System.Drawing.Size(159, 98);
            this.cmUsers.Opening += new System.ComponentModel.CancelEventHandler(this.cmUsers_Opening);
            // 
            // tsmSelect
            // 
            this.tsmSelect.Name = "tsmSelect";
            this.tsmSelect.Size = new System.Drawing.Size(158, 22);
            this.tsmSelect.Text = "Выбрать";
            this.tsmSelect.Click += new System.EventHandler(this.tsmSelect_Click);
            // 
            // tsmSeparator
            // 
            this.tsmSeparator.Name = "tsmSeparator";
            this.tsmSeparator.Size = new System.Drawing.Size(155, 6);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(158, 22);
            this.tsmEdit.Text = "Редактировать";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmStatus
            // 
            this.tsmStatus.Name = "tsmStatus";
            this.tsmStatus.Size = new System.Drawing.Size(158, 22);
            this.tsmStatus.Text = "Заблокировать";
            this.tsmStatus.Click += new System.EventHandler(this.tsmStatus_Click);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Код";
            this.columnHeaderId.Width = 40;
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
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Location = new System.Drawing.Point(531, 277);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(699, 312);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lbPage);
            this.Controls.Add(this.cmbPage);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.lbUsers);
            this.MinimumSize = new System.Drawing.Size(715, 250);
            this.Name = "UserManagementForm";
            this.Text = "Управление пользователями";
            this.cmUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbUsers;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Button btnCancel;
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
        private System.Windows.Forms.ContextMenuStrip cmUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmSelect;
        private System.Windows.Forms.ToolStripSeparator tsmSeparator;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
    }
}