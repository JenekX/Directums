namespace Directums.Client.Forms.Admin
{
    partial class GroupManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupManagementForm));
            this.lbGroups = new System.Windows.Forms.Label();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUserCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lbQuickFilter = new System.Windows.Forms.Label();
            this.tbQuickFilter = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGroups
            // 
            this.lbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGroups.Location = new System.Drawing.Point(12, 9);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(402, 21);
            this.lbGroups.TabIndex = 0;
            this.lbGroups.Text = "Группы пользователей:";
            this.lbGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvGroups
            // 
            this.lvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStatus,
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderUserCount});
            this.lvGroups.ContextMenuStrip = this.cmGroups;
            this.lvGroups.FullRowSelect = true;
            this.lvGroups.Location = new System.Drawing.Point(15, 33);
            this.lvGroups.MultiSelect = false;
            this.lvGroups.Name = "lvGroups";
            this.lvGroups.Size = new System.Drawing.Size(399, 162);
            this.lvGroups.SmallImageList = this.imageList;
            this.lvGroups.TabIndex = 1;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.DoubleClick += new System.EventHandler(this.tsmEdit_Click);
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "?";
            this.columnHeaderStatus.Width = 22;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Код";
            this.columnHeaderId.Width = 45;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Наименование";
            this.columnHeaderName.Width = 227;
            // 
            // columnHeaderUserCount
            // 
            this.columnHeaderUserCount.Text = "Пользователей";
            this.columnHeaderUserCount.Width = 101;
            // 
            // cmGroups
            // 
            this.cmGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmEdit,
            this.tsmSeparator,
            this.tsmChangeStatus});
            this.cmGroups.Name = "cmGroups";
            this.cmGroups.Size = new System.Drawing.Size(159, 76);
            this.cmGroups.Opening += new System.ComponentModel.CancelEventHandler(this.cmGroups_Opening);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(158, 22);
            this.tsmAdd.Text = "Добавить";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(158, 22);
            this.tsmEdit.Text = "Редактировать";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmSeparator
            // 
            this.tsmSeparator.Name = "tsmSeparator";
            this.tsmSeparator.Size = new System.Drawing.Size(155, 6);
            // 
            // tsmChangeStatus
            // 
            this.tsmChangeStatus.Name = "tsmChangeStatus";
            this.tsmChangeStatus.Size = new System.Drawing.Size(158, 22);
            this.tsmChangeStatus.Text = "Заблокировать";
            this.tsmChangeStatus.Click += new System.EventHandler(this.tsmChangeStatus_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "status-0");
            this.imageList.Images.SetKeyName(1, "status-1");
            // 
            // lbQuickFilter
            // 
            this.lbQuickFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbQuickFilter.Location = new System.Drawing.Point(12, 201);
            this.lbQuickFilter.Name = "lbQuickFilter";
            this.lbQuickFilter.Size = new System.Drawing.Size(98, 20);
            this.lbQuickFilter.TabIndex = 2;
            this.lbQuickFilter.Text = "Быстрый фильтр:";
            this.lbQuickFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbQuickFilter
            // 
            this.tbQuickFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuickFilter.Location = new System.Drawing.Point(116, 201);
            this.tbQuickFilter.Name = "tbQuickFilter";
            this.tbQuickFilter.Size = new System.Drawing.Size(298, 20);
            this.tbQuickFilter.TabIndex = 3;
            this.tbQuickFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbQuickFilter_KeyUp);
            this.tbQuickFilter.Leave += new System.EventHandler(this.tbQuickFilter_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(339, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // GroupManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(426, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbQuickFilter);
            this.Controls.Add(this.lbQuickFilter);
            this.Controls.Add(this.lvGroups);
            this.Controls.Add(this.lbGroups);
            this.Name = "GroupManagementForm";
            this.Text = "Управление группами пользователей";
            this.cmGroups.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGroups;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderUserCount;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Label lbQuickFilter;
        private System.Windows.Forms.TextBox tbQuickFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cmGroups;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripSeparator tsmSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
    }
}