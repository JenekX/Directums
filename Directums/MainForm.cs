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
                lvFiles.Items.Add(fl.Name + "." + fl.Extension + " (" + fl.CreatedTime + ")");
            }
        }

        private void tvDirs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFiles();
        }
    }
}
