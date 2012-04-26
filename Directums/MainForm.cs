using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Directums.Classes.Core;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using Directums.Client.Forms.Client;
using IO = System.IO;
using System.IO;
using Directums.Client.Forms.Admin;
using System.Diagnostics;
using OSIcon;
using OSIcon.WinAPI;

namespace Directums.Client
{
    public partial class MainForm : DirectumsForm
    {
        private GetFoldersResult[] folders = null;

        public bool AllowChangeUser { get; private set; }

        private GetFoldersResult GetSelectedFolder()
        {
            return (GetFoldersResult)tvDirs.SelectedNode.Tag;
        }

        private GetFilesResult GetSelectedFile()
        {
            return lvFiles.SelectedItems.Count == 1 ? (GetFilesResult)lvFiles.SelectedItems[0].Tag : null;
        }

        private TreeNode AddToFoldersTreeView(TreeNode parentNode, GetFoldersResult folder)
        {
            TreeNode node = null;
            if (parentNode == null)
            {
                node = tvDirs.Nodes.Add(folder.Name);
            }
            else
            {
                node = parentNode.Nodes.Add(folder.Name);
            }

            string key = "";
            switch (folder.Type)
            {
                case GetFoldersResultType.Folder:
                    key = "folder";
                    break;
                case GetFoldersResultType.RootUserFolder:
                    node.Text = "Корневая папка " + Config.User.Login;
                    key = "root_folder";
                    break;
                case GetFoldersResultType.SharedFolder:
                    node.Text = "Общая папка";
                    key = "shared_folder";
                    break;
                case GetFoldersResultType.FolderRef:
                    key = "ref_folder";
                    break;
            }

            node.ImageKey = node.SelectedImageKey = key;
            node.Tag = folder;

            return node;
        }

        private void CreateNodes(IEnumerable<GetFoldersResult> childs, TreeNode root = null)
        {
            foreach (var child in childs)
            {
                var node = AddToFoldersTreeView(root, child);

                CreateNodes(folders.Where(x => x.IdParent == child.Id).OrderBy(x => x.Name), node);
            }
        }

        private void FillFolders()
        {
            tvDirs.Nodes.Clear();

            folders = Config.Client.GetFolders();

            var roots = folders.Where(x => x.IdParent == null).OrderBy(x => x.Type);
            CreateNodes(roots);
        }

        private string GetFileImageKey(GetFilesResult file)
        {
            string result = "";
            switch (file.Type)
            {
                case GetFilesResultType.Folder:
                    result = "folder";
                    break;
                case GetFilesResultType.FolderRef:
                    result = "ref_folder";
                    break;
                case GetFilesResultType.File:
                case GetFilesResultType.FileRef:
                    result = "file_" + file.IdFile.ToString() + (file.Type == GetFilesResultType.FileRef ? "_ref" : "");

                    if (!imageList.Images.ContainsKey(result))
                    {
                        Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                        Icon icon = IconReader.ExtractIconFromFileEx(file.Extension, IconReader.IconSize.Small, ref shfi);

                        if (file.Type == GetFilesResultType.FileRef)
                        {
                            icon = IconExtractor.MergeIcons(icon, Icon.FromHandle(((Bitmap)imageList.Images["ref"]).GetHicon()));
                        }

                        imageList.Images.Add(result, icon);
                    }
                    break;
            }

            return result;
        }

        private void AddToFilesListView(GetFilesResult file)
        {
            ListViewItem item = new ListViewItem(file.Name + file.Extension, GetFileImageKey(file));
            item.SubItems.Add(file.OwnerName);
            item.SubItems.Add(file.Created.ToString());
            item.Tag = file;

            lvFiles.Items.Add(item);
        }

        private void ShowFiles()
        {
            lvFiles.Items.Clear();

            var files = Config.Client.GetFiles(GetSelectedFolder().Id);
            foreach (GetFilesResult file in files)
            {
                AddToFilesListView(file);
            }
        }

        public MainForm(DirectumsConfig config) : base (config)
        {
            InitializeComponent();

            AllowChangeUser = false;

            FillFolders();
        }

        public void Initialize()
        {
            Text = "Directums - " + Config.User.Login;

            tsmAdmin.Visible = Config.User.IsAdmin;

            var icons = IconReader.ExtractIconsFromFile("shell32.dll", false);
            Icon iconFolder = icons[4];
            Icon iconShared = icons[29];
            Icon iconRef = icons[30];
            Icon iconUser = icons[269];

            imageList.Images.Add("folder", iconFolder);
            imageList.Images.Add("user_folder", IconExtractor.MergeIcons(iconFolder, iconUser));
            imageList.Images.Add("shared_folder", IconExtractor.MergeIcons(iconFolder, iconShared));
            imageList.Images.Add("ref_folder", IconExtractor.MergeIcons(iconFolder, iconRef));
            imageList.Images.Add("ref", iconRef);

            if (Config.Client.IsHasNewMessages())
            {
                NotificationForm.ExecuteMessageAdded(this, tsmMessages_Click);
            }
        }

        private void tvDirs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvDirs.SelectedNode.Expand();

            ShowFiles();
        }

        private void tsmChangeUser_Click(object sender, EventArgs e)
        {
            AllowChangeUser = true;

            Close();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            AllowChangeUser = false;

            Close();
        }

        private void tsmAdminUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm.Execute(this);
        }

        private void tsmAdminGroups_Click(object sender, EventArgs e)
        {
            GroupManagementForm.Execute(this);
        }

        private void tsmFileProperties_Click(object sender, EventArgs e)
        {
            int idFile = GetSelectedFile().IdFile;

            if (FilePropertiesForm.Execute(this, idFile))
            {
                ShowFiles();
            }
        }

        private void tsmOpenDocument_Click(object sender, EventArgs e)
        {
            var file = GetSelectedFile();

            ExecuteFile(file.IdFile, 0, file.Name, file.Extension, false);
        }

        private void tsMenuAddDocument_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            int idParent = GetSelectedFolder().Id;
            string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            string extension = Path.GetExtension(openFileDialog.FileName);
            var data = IO.File.ReadAllBytes(openFileDialog.FileName);

            var result = Config.Client.AddFile(fileName, extension, idParent, data);
            if (result != null)
            {
                FilePropertiesForm.Execute(this, result.IdFile);

                ShowFiles();
            }
            else
            {
                DialogHelper.Error(this, "Во время добавления файла возникла ошибка");
            }
        }

        private void tsMenuAddVersion_Click(object sender, EventArgs e)
        {
            int idFile = GetSelectedFile().IdFile;

            bool result = Config.Client.AddVersion(idFile, 0);
            if (result)
            {
                tsmOpenDocument.PerformClick();
            }
            else
            {
                DialogHelper.Error(this, "Во время добавления версии файла возникла ошибка");
            }
        }

        private void tsMenuAddFolder_Click(object sender, EventArgs e)
        {
            int idFolder = GetSelectedFolder().Id;

            var file = Config.Client.AddFolder("Новая папка", idFolder);
            if (file != null)
            {
                var folder = new GetFoldersResult()
                {
                    Type = GetFoldersResultType.Folder,
                    Id = file.Id,
                    IdFile = file.IdFile,
                    IdParent = idFolder,
                    Name = file.Name,
                    ReadOnly = file.ReadOnly
                };

                AddToFoldersTreeView(tvDirs.SelectedNode, folder);

                AddToFilesListView(file);
            }
            else
            {
                DialogHelper.Error(this, "Во время добавления директории возникла ошибка");
            }
        }

        private void tsmRefresh_Click(object sender, EventArgs e)
        {
            FillFolders();
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            var file = GetSelectedFile();

            if (file.Type == GetFilesResultType.Folder || file.Type == GetFilesResultType.FolderRef)
            {
                // переход на уровень вниз
            }
            else
            {
                tsmOpenDocument.PerformClick();
            }
        }

        private void tsmMessages_Click(object sender, EventArgs e)
        {
            MessagesForm.Execute(this);
        }
    }
}