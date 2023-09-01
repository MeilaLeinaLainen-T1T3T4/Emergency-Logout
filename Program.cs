using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

class Program
{
    static System.Timers.Timer timer;

    [DllImport("user32.dll")]
    public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

    static void Main()
    {
        timer = new System.Timers.Timer(5000);
        timer.Elapsed += TimerElapsed;
        timer.Start();

        Console.WriteLine("Emergency Logout\n Logging everyone out!");
        Console.ReadLine();
    }

    private static void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Timer elapsed at: " + DateTime.Now);
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
