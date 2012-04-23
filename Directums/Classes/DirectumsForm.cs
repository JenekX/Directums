using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System;

namespace Directums.Client.Classes
{
    public class DirectumsForm : Form
    {
        public DirectumsForm() : this(null)
        {
        }

        public DirectumsForm(DirectumsConfig config) : base()
        {
            Config = config;

            StartPosition = FormStartPosition.CenterParent;
        }

        public void ExecuteFile(int idFile, int versionNumber, string name, string extension, bool readOnly, EventHandler handler = null)
        {
            var fileData = Config.Client.GetFile(idFile, versionNumber);
            var fileName = Path.Combine(Path.GetTempPath(), name + extension);

            File.WriteAllBytes(fileName, fileData);

            if (readOnly)
            {
                File.SetAttributes(fileName, FileAttributes.ReadOnly);
            }

            Process process = new Process();

            process.StartInfo.FileName = fileName;
            process.EnableRaisingEvents = true;

            process.Exited += delegate(object obj, EventArgs args)
            {
                if (!readOnly)
                {
                    var data = File.ReadAllBytes(fileName);
                    
                    Config.Client.UpdateVersion(idFile, versionNumber, data);
                }

                if (handler != null)
                {
                    Invoke(new MethodInvoker(() => { handler(obj, args); }));
                }
            };

            process.Start();
        }

        public DirectumsConfig Config { get; private set; }
    }
}