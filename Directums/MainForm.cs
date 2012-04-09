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
using IO = System.IO;

namespace Directums.Client
{
    public partial class MainForm : DirectumsForm
    {
        private GetDirsResult[] dirs;

        public MainForm(DirectumsConfig config) : base (config)
        {
            InitializeComponent();
            
            //Получаем список все папок
            dirs = Config.Client.GetDirs();

            //Получаем все корни - корнем считается тот элемент, у которого поле IdParent == -1
            List<GetDirsResult> roots = dirs.Where(x => x.IdParent == -1).ToList();

            //Запускаем рекурсивную процедуру построения дерева каталогов            
            CreateNodes(roots);

            //Выбираем первый корень
            tvDirs.SelectedNode = tvDirs.Nodes[0];

            //Отображаем файлы для выбранный папки
            ShowFiles();
        }

        private void CreateNodes(List<GetDirsResult> childs, TreeNode root = null)
        {
            foreach (GetDirsResult child in childs)
            {
                if (root == null)
                {
                    //Создаем корни дерева и запускаем рекурсию
                    //List<GetFilesResult> childToCreate = dirs.Where(x => x.IdParent == child.IdItem).ToList();
                    TreeNode tn = tvDirs.Nodes.Add(child.Name);
                    tn.Tag = child.IdItem;

                    CreateNodes(dirs.Where(x => x.IdParent == child.IdItem).ToList(), tn);
                }
                else
                {
                    //Создаем подкаталоги
                    TreeNode tn = root.Nodes.Add(child.Name);
                    tn.Tag = child.IdItem;
                    CreateNodes(dirs.Where(x => x.IdParent == child.IdItem).ToList(), tn);
                }
            }
        }

        private void ShowFiles()
        {
            lvFiles.Clear();

            var files = Config.Client.GetFiles((Int32)tvDirs.SelectedNode.Tag);

            foreach (GetFilesResult fl in files)
            {
                ListViewItem lvItem = new ListViewItem(fl.Name + fl.Extension + " (" + fl.CreatedTime + ")");
                lvItem.Tag = fl.Id;
                lvFiles.Items.Add(lvItem);
            }
        }

        private void tvDirs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFiles();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новый документ", "Добавление нового файла документа", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (Config.Client.AddFile(IO.Path.GetFileNameWithoutExtension(openFile.SafeFileName), IO.Path.GetExtension(openFile.SafeFileName).ToLower(),
                        (Int32)tvDirs.SelectedNode.Tag, IO.File.ReadAllBytes(openFile.FileName)))
                    {
                        MessageBox.Show("Файл успешно добавлен");
                    }
                    ShowFiles();
                }
            }
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count != 0)
            {
                saveToolStripButton.Enabled = true;
            }
            else
            {
                saveToolStripButton.Enabled = false;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую версию документа", "Добавление нового файла документа", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                     if (Config.Client.AddVersion((Int32) lvFiles.SelectedItems[0].Tag, IO.File.ReadAllBytes(openFile.FileName)))
                     {
                         MessageBox.Show("Файл успешно обновлен");
                     }
                }
            }
        }

        private void lvFiles_Leave(object sender, EventArgs e)
        {
            saveToolStripButton.Enabled = false;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            Directums.Client.Forms.Client.UsersForm.Execute(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Directums.Client.Forms.Client.FilePropertiesForm.Execute(this);

            int idFile = (int)lvFiles.SelectedItems[0].Tag;

            Directums.Client.Forms.Client.FilePropertiesForm.Execute(this, idFile);
        }
    }
}
