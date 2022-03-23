
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Interop;

namespace Polyathlon.Helpers;

internal class DirectoryHelper
{

    private static class WinApiHelper
    {
        private static class Import
        {
            public struct WINDOWPLACEMENT
            {
                public int length;

                public int flags;

                public ShowWindowCommands showCmd;

                public Point ptMinPosition;

                public Point ptMaxPosition;

                public Rectangle rcNormalPosition;
            }

            public enum ShowWindowCommands
            {
                Hide,
                Normal,
                ShowMinimized,
                ShowMaximized,
                ShowNoActivate,
                Show,
                Minimize,
                ShowMinNoActive,
                ShowNA,
                Restore,
                ShowDefault,
                ForceMinimize
            }

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        }

        [SecuritySafeCritical]
        public static bool SetForegroundWindow(IntPtr hwnd)
        {
            return Import.SetForegroundWindow(hwnd);
        }

        [SecuritySafeCritical]
        public static bool RestoreWindowAsync(IntPtr hwnd)
        {
            return Import.ShowWindowAsync(hwnd, IsMaxmimized(hwnd) ? 3 : 9);
        }

        [SecuritySafeCritical]
        public static bool IsMaxmimized(IntPtr hwnd)
        {
            Import.WINDOWPLACEMENT lpwndpl = default(Import.WINDOWPLACEMENT);
            lpwndpl.length = Marshal.SizeOf(lpwndpl);
            if (!Import.GetWindowPlacement(hwnd, ref lpwndpl))
            {
                return false;
            }

            return lpwndpl.showCmd == Import.ShowWindowCommands.ShowMaximized;
        }
    }
    public static IDisposable SingleInstanceApplicationGuard(string applicationName, out bool exit)
    {
        Mutex mutex = new(initiallyOwned: true, applicationName);
        if (mutex.WaitOne(0, exitContext: false))
        {
            exit = false;
        }
        else
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (Process process in processesByName)
            {
                if (process.Id != currentProcess.Id && process.MainWindowHandle != IntPtr.Zero)
                {
                    WinApiHelper.SetForegroundWindow(process.MainWindowHandle);
                    WinApiHelper.RestoreWindowAsync(process.MainWindowHandle);
                    break;
                }
            }

            exit = true;
        }

        return mutex;
    }
}
