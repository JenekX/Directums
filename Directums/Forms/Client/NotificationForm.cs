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
using System.Runtime.InteropServices;
using Time = System.Timers;

namespace Directums.Client.Forms.Client
{
    public partial class NotificationForm : DirectumsForm
    {
        private const int SW_SHOWNOACTIVATE = 4; //неактивна
        private const int HWND_TOPMOST = -1; //поверх всех окон, включая топовые
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private Time.Timer NotificatonTimer = new Time.Timer();
        private Time.Timer PopUpTimer = new Time.Timer();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
      
        public NotificationForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ShowWindow();
        }

        public static void ExecuteMessageAdded(DirectumsForm ownerForm, EventHandler OnMessageAdded)
        {
            NotificationForm form = new NotificationForm(ownerForm.Config);
            
            form.pbNotificationIconMessage.Visible = true;
            form.lbText.Text = "У вас новое сообщение";

            form.Click += OnMessageAdded;
            form.pbNotificationIconMessage.Click += OnMessageAdded;
            form.lbText.Click += OnMessageAdded;
        }

        public static void ExecuteNewUsers(DirectumsForm ownerForm, EventHandler OnNewUsers)
        {
            NotificationForm form = new NotificationForm(ownerForm.Config);

            form.pbNotificationIconUser.Visible = true;
            form.lbText.Text = "Появились новые пользователи, ожидающие активации";

            form.Click += OnNewUsers;
            form.pbNotificationIconMessage.Click += OnNewUsers;
            form.lbText.Click += OnNewUsers;
        }

        public void ShowWindow()
        {
            ShowWindow(Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(Handle.ToInt32(), HWND_TOPMOST, Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height, Width, Height, SWP_NOACTIVATE);
            PopUpTimer.Elapsed += new Time.ElapsedEventHandler(PopUpForm);
            PopUpTimer.Interval = 10;
            PopUpTimer.Enabled = true;

            NotificatonTimer.Elapsed += new Time.ElapsedEventHandler(CloseForm);
            NotificatonTimer.Interval = Config.NotificationTime;
            NotificatonTimer.Enabled = true;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseForm(object source, Time.ElapsedEventArgs e)
        {
            this.Close();
        }

        private void PopUpForm(object source, Time.ElapsedEventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Height - Top < Height)
            {
                try
                {
                    SetWindowPos(Handle.ToInt32(), HWND_TOPMOST, Left, Top - 15, Width, Height, SWP_NOACTIVATE);
                }
                catch
                {
                    PopUpTimer.Enabled = false;
                }
            }
            else
            {
                PopUpTimer.Enabled = false;
            }
        }
    }
}
