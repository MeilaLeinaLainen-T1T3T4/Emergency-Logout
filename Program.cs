using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

    static void Main()
    {
        LogOutAllUsers();
        System.Threading.Thread.Sleep(3000);
        ForceShutdown();
    }

    static void LogOutAllUsers()
    {
        Process.Start("shutdown", "/l /f");
    }

    static void ForceShutdown()
    {
        ExitWindowsEx(0x00000008 | 0x00000004, 0);
    }
}