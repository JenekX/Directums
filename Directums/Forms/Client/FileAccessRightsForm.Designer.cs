namespace Directums.Client.Forms.Client
{
    partial class FileAccessRightsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAccessRightsForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvRights = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRights = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmRights = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChooseRights = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lbRights = new System.Windows.Forms.Label();
            this.cmRights.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(251, 177);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(332, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lvRights
            // 
            this.lvRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRights.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderName,
            this.columnHeaderRights});
            this.lvRights.ContextMenuStrip = this.cmRights;
            this.lvRights.FullRowSelect = true;
            this.lvRights.GridLines = true;
            this.lvRights.Location = new System.Drawing.Point(12, 33);
            this.lvRights.MultiSelect = false;
            this.lvRights.Name = "lvRights";
            this.lvRights.Size = new System.Drawing.Size(395, 138);
            this.lvRights.SmallImageList = this.imageList;
            this.lvRights.TabIndex = 1;
            this.lvRights.UseCompatibleStateImageBehavior = false;
            this.lvRights.View = System.Windows.Forms.View.Details;
            this.lvRights.DoubleClick += new System.EventHandler(this.lvRights_DoubleClick);
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "?";
            this.columnHeaderType.Width = 22;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Наименование";
            this.columnHeaderName.Width = 227;
            // 
            // columnHeaderRights
            // 
            this.columnHeaderRights.Text = "Права доступа";
            this.columnHeaderRights.Width = 124;
            // 
            // cmRights
            // 
            this.cmRights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddUser,
            this.tsmAddGroup,
            this.tsmChooseRights,
            this.tsmDelete});
            this.cmRights.Name = "cmRights";
            this.cmRights.Size = new System.Drawing.Size(205, 92);
            this.cmRights.Opening += new System.ComponentModel.CancelEventHandler(this.cmRights_Opening);
            // 
            // tsmAddUser
            // 
            this.tsmAddUser.Name = "tsmAddUser";
            this.tsmAddUser.Size = new System.Drawing.Size(204, 22);
            this.tsmAddUser.Text = "Добавить пользователя";
            this.tsmAddUser.Click += new System.EventHandler(this.tsmAddUser_Click);
            // 
            // tsmAddGroup
            // 
            this.tsmAddGroup.Name = "tsmAddGroup";
            this.tsmAddGroup.Size = new System.Drawing.Size(204, 22);
            this.tsmAddGroup.Text = "Добавить группу";
            this.tsmAddGroup.Click += new System.EventHandler(this.tsmAddGroup_Click);
            // 
            // tsmChooseRights
            // 
            this.tsmChooseRights.Name = "tsmChooseRights";
            this.tsmChooseRights.Size = new System.Drawing.Size(204, 22);
            this.tsmChooseRights.Text = "Изменить права";
            this.tsmChooseRights.Click += new System.EventHandler(this.lvRights_DoubleClick);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(204, 22);
            this.tsmDelete.Text = "Удалить";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "user");
            this.imageList.Images.SetKeyName(1, "group");
            // 
            // lbRights
            // 
            this.lbRights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRights.Location = new System.Drawing.Point(12, 9);
            this.lbRights.Name = "lbRights";
            this.lbRights.Size = new System.Drawing.Size(395, 21);
            this.lbRights.TabIndex = 0;
            this.lbRights.Text = "Имеют доступ:";
            this.lbRights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileAccessRightsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 212);
            this.Controls.Add(this.lvRights);
            this.Controls.Add(this.lbRights);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MinimumSize = new System.Drawing.Size(435, 250);
            this.Name = "FileAccessRightsForm";
            this.Text = "Права доступа к документу";
            this.cmRights.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvRights;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderRights;
        private System.Windows.Forms.Label lbRights;
        private System.Windows.Forms.ContextMenuStrip cmRights;
        private System.Windows.Forms.ToolStripMenuItem tsmAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmAddGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem tsmChooseRights;
    }
}