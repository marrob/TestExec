using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knv.TestExec.AutoIgnore
{
    class Program
    {
        static void Main(string[] args)
        {
            var tiw = new TheIgnoreWorker();
            tiw.Start();
           // Win32ApiUser32.HideConsole();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
