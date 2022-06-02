using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.TestExec.AutoIgnoreService
{
    public class Win32ApiUser32
    {
        public const int BM_CLICK = 0x00F5;
        public const int WM_COMMAND = 0x0111;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// A Button-hoz és a felirathoz használd a spyxx.exe-t
        /// "Microsoft Visual C++ Debug Library"
        /// </summary>
        /// <param name="windowCaption"></param>
        public static void IgnoreWindow(string windowCaption)
        {
            IntPtr wnd = FindWindowByCaption(IntPtr.Zero, windowCaption);
            if (wnd != IntPtr.Zero)
            {
                IntPtr ButtonHandle = FindWindowEx(wnd, IntPtr.Zero, "Button", "&Ignore");
                SendMessage(ButtonHandle, BM_CLICK, 0, 0);

            }
        }
    }
}