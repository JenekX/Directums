namespace Directums.Client
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsdbAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMenuAddDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuAddVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.scWorkArea = new System.Windows.Forms.SplitContainer();
            this.tvDirs = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpenDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьВерсиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdminUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdminGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scWorkArea)).BeginInit();
            this.scWorkArea.Panel1.SuspendLayout();
            this.scWorkArea.Panel2.SuspendLayout();
            this.scWorkArea.SuspendLayout();
            this.filesContextMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAdd});
            this.tsMenu.Location = new System.Drawing.Point(0, 24);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(659, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsdbAdd
            // 
            this.tsdbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuAddFolder,
            this.tsMenuAddDocument,
            this.tsMenuAddVersion});
            this.tsdbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsdbAdd.Image")));
            this.tsdbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdbAdd.Name = "tsdbAdd";
            this.tsdbAdd.Size = new System.Drawing.Size(88, 22);
            this.tsdbAdd.Text = "Добавить";
            // 
            // tsMenuAddDocument
            // 
            this.tsMenuAddDocument.Name = "tsMenuAddDocument";
            this.tsMenuAddDocument.Size = new System.Drawing.Size(152, 22);
            this.tsMenuAddDocument.Text = "Документ";
            this.tsMenuAddDocument.Click += new System.EventHandler(this.tsMenuAddDocument_Click);
            // 
            // tsMenuAddVersion
            // 
            this.tsMenuAddVersion.Name = "tsMenuAddVersion";
            this.tsMenuAddVersion.Size = new System.Drawing.Size(152, 22);
            this.tsMenuAddVersion.Text = "Версия";
            this.tsMenuAddVersion.Click += new System.EventHandler(this.tsMenuAddVersion_Click);
            // 
            // tsMenuAddFolder
            // 
            this.tsMenuAddFolder.Name = "tsMenuAddFolder";
            this.tsMenuAddFolder.Size = new System.Drawing.Size(152, 22);
            this.tsMenuAddFolder.Text = "Директория";
            this.tsMenuAddFolder.Click += new System.EventHandler(this.tsMenuAddFolder_Click);
            // 
            // scWorkArea
            // 
            this.scWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scWorkArea.Location = new System.Drawing.Point(0, 49);
            this.scWorkArea.Name = "scWorkArea";
            // 
            // scWorkArea.Panel1
            // 
            this.scWorkArea.Panel1.Controls.Add(this.tvDirs);
            // 
            // scWorkArea.Panel2
            // 
            this.scWorkArea.Panel2.Controls.Add(this.lvFiles);
            this.scWorkArea.Size = new System.Drawing.Size(659, 367);
            this.scWorkArea.SplitterDistance = 219;
            this.scWorkArea.TabIndex = 1;
            // 
            // tvDirs
            // 
            this.tvDirs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirs.FullRowSelect = true;
            this.tvDirs.HideSelection = false;
            this.tvDirs.ImageIndex = 0;
            this.tvDirs.ImageList = this.imageList;
            this.tvDirs.Location = new System.Drawing.Point(0, 0);
            this.tvDirs.Name = "tvDirs";
            this.tvDirs.SelectedImageIndex = 0;
            this.tvDirs.Size = new System.Drawing.Size(219, 367);
            this.tvDirs.TabIndex = 0;
            this.tvDirs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirs_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "user_folder");
            this.imageList.Images.SetKeyName(1, "shared_folder");
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.cbOwner,
            this.cbCreated});
            this.lvFiles.ContextMenuStrip = this.filesContextMenu;
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.MinimumSize = new System.Drawing.Size(50, 50);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(436, 367);
            this.lvFiles.SmallImageList = this.imageList;
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Имя";
            this.chName.Width = 158;
            // 
            // cbOwner
            // 
            this.cbOwner.Text = "Владелец";
            this.cbOwner.Width = 141;
            // 
            // cbCreated
            // 
            this.cbCreated.Text = "Создан";
            this.cbCreated.Width = 111;
            // 
            // filesContextMenu
            // 
            this.filesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenDocument,
            this.tsmFileProperties,
            this.создатьВерсиюToolStripMenuItem});
            this.filesContextMenu.Name = "filesContextMenu";
            this.filesContextMenu.Size = new System.Drawing.Size(163, 70);
            // 
            // tsmOpenDocument
            // 
            this.tsmOpenDocument.Name = "tsmOpenDocument";
            this.tsmOpenDocument.Size = new System.Drawing.Size(162, 22);
            this.tsmOpenDocument.Text = "Открыть";
            this.tsmOpenDocument.Click += new System.EventHandler(this.tsmOpenDocument_Click);
            // 
            // tsmFileProperties
            // 
            this.tsmFileProperties.Name = "tsmFileProperties";
            this.tsmFileProperties.Size = new System.Drawing.Size(162, 22);
            this.tsmFileProperties.Text = "Свойства";
            this.tsmFileProperties.Click += new System.EventHandler(this.tsmFileProperties_Click);
            // 
            // создатьВерсиюToolStripMenuItem
            // 
            this.создатьВерсиюToolStripMenuItem.Name = "создатьВерсиюToolStripMenuItem";
            this.создатьВерсиюToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьВерсиюToolStripMenuItem.Text = "Создать версию";
            this.создатьВерсиюToolStripMenuItem.Click += new System.EventHandler(this.tsMenuAddVersion_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmView,
            this.tsmAdmin});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(659, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmChangeUser,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(48, 20);
            this.tsmFile.Text = "Файл";
            // 
            // tsmChangeUser
            // 
            this.tsmChangeUser.Name = "tsmChangeUser";
            this.tsmChangeUser.Size = new System.Drawing.Size(188, 22);
            this.tsmChangeUser.Text = "Смена пользователя";
            this.tsmChangeUser.Click += new System.EventHandler(this.tsmChangeUser_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(188, 22);
            this.tsmExit.Text = "Выход";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRefresh});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(39, 20);
            this.tsmView.Text = "Вид";
            // 
            // tsmRefresh
            // 
            this.tsmRefresh.Name = "tsmRefresh";
            this.tsmRefresh.Size = new System.Drawing.Size(128, 22);
            this.tsmRefresh.Text = "Обновить";
            this.tsmRefresh.Click += new System.EventHandler(this.tsmRefresh_Click);
            // 
            // tsmAdmin
            // 
            this.tsmAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdminUsers,
            this.tsmAdminGroups});
            this.tsmAdmin.Name = "tsmAdmin";
            this.tsmAdmin.Size = new System.Drawing.Size(134, 20);
            this.tsmAdmin.Text = "Администрирование";
            // 
            // tsmAdminUsers
            // 
            this.tsmAdminUsers.Name = "tsmAdminUsers";
            this.tsmAdminUsers.Size = new System.Drawing.Size(152, 22);
            this.tsmAdminUsers.Text = "Пользователи";
            this.tsmAdminUsers.Click += new System.EventHandler(this.tsmAdminUsers_Click);
            // 
            // tsmAdminGroups
            // 
            this.tsmAdminGroups.Name = "tsmAdminGroups";
            this.tsmAdminGroups.Size = new System.Drawing.Size(152, 22);
            this.tsmAdminGroups.Text = "Группы";
            this.tsmAdminGroups.Click += new System.EventHandler(this.tsmAdminGroups_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 416);
            this.Controls.Add(this.scWorkArea);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Directums";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.scWorkArea.Panel1.ResumeLayout(false);
            this.scWorkArea.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scWorkArea)).EndInit();
            this.scWorkArea.ResumeLayout(false);
            this.filesContextMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.SplitContainer scWorkArea;
        private System.Windows.Forms.TreeView tvDirs;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeUser;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmAdminUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmAdminGroups;
        private System.Windows.Forms.ContextMenuStrip filesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenDocument;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem tsmFileProperties;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ToolStripDropDownButton tsdbAdd;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAddDocument;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAddVersion;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAddFolder;
        private System.Windows.Forms.ToolStripMenuItem создатьВерсиюToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColumnHeader cbCreated;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmRefresh;
        private System.Windows.Forms.ColumnHeader cbOwner;
    }
}