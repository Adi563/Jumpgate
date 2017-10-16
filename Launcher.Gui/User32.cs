using System;

namespace Launcher.Gui
{
    public class User32
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}