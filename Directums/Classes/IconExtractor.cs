using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Directums.Client.Classes
{
    public enum IconSize
    {
        Small,
        Large
    }
  
    public class IconExtractor
    {

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public IconExtractor()
        {
        }

        public System.Drawing.Icon Extract(string File, IconSize Size)
        {
            IntPtr hIcon;
            SHFILEINFO shinfo = new SHFILEINFO();

            if (Size == IconSize.Large)
            {
                hIcon = SHGetFileInfo(File, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            }
            else
            {
                hIcon = SHGetFileInfo(File, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            }

            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        public System.Drawing.Icon Extract(string File)
        {
            return this.Extract(File, IconSize.Small);
        }

        public static Icon MergeIcons(params Icon[] icons)
        {
            if (icons.Length == 0)
            {
                return null;
            }
            else if (icons.Length == 1)
            {
                return icons[0];
            }

            Bitmap result = new Bitmap(icons[0].Width, icons[0].Height);
            Graphics canvas = Graphics.FromImage(result);

            foreach (Icon icon in icons)
            {
                canvas.DrawIcon(icon, 0, 0);
            }

            canvas.Save();
            return Icon.FromHandle(result.GetHicon());
        }
    }
}