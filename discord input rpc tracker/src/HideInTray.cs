using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TrayManager
{
    internal class HideInTray
    {
        static NotifyIcon notifyIcon = new NotifyIcon();
        static bool Visible = true;
        static bool FirstHide = true;

        public static void Track()
        {
            Thread thread = new Thread(StartTracking);
            thread.Start();
        }

        private static void StartTracking()
        {
            notifyIcon.Click += (s, e) =>
            {
                Visible = !Visible;
                SetConsoleWindowVisibility(Visible);

                if (Visible == false && FirstHide == true)
                {
                    FirstHide = false;

                    notifyIcon.ShowBalloonTip(5000, Application.ProductName, "Hidden to tray. To exit, right click the icon and click 'exit'. To unhide, click the icon.", ToolTipIcon.Info);
                }
            };

            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, (s, e) => { Environment.Exit(0); });
            notifyIcon.ContextMenuStrip = contextMenu;

            Application.Run();

            notifyIcon.Visible = false;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void SetConsoleWindowVisibility(bool visible)
        {
            IntPtr hWnd = FindWindow(null, Console.Title);
            if (hWnd != IntPtr.Zero)
            {
                if (visible) ShowWindow(hWnd, 1);
                else ShowWindow(hWnd, 0);
            }
        }
    }
}
