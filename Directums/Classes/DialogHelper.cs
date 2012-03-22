using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Directums.Client.Classes
{
    public static class DialogHelper
    {
        public static void Error(IWin32Window owner, string text)
        {
            MessageBox.Show(owner, text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void Information(IWin32Window owner, string text)
        {
            MessageBox.Show(owner, text, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
