using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Konvolucio.TestExec.AutoIgnore
{
    internal class TheIgnoreWorker
    {

        readonly Timer _timer;
        int _ignoredWindowCount;
        string _windowCaption = "Microsoft Visual C++ Debug Library";

        public TheIgnoreWorker()
        {
            _timer = new Timer();
            _timer.Interval = 2000;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                IntPtr winhdl = Win32ApiUser32.FindWindowByCaption(IntPtr.Zero, _windowCaption);
                if (winhdl != IntPtr.Zero)
                {
                    _ignoredWindowCount++;
                    Win32ApiUser32.IgnoreWindow(_windowCaption);
                    AppLog.Instance.WriteLine("Ignored a " + _windowCaption);
                }
            }
            catch (Exception ex) 
            {
                AppLog.Instance.WriteLine("TheIgnoreWorker.Timer_Elapsed.Exception:" + ex.Message);
            }
           
        }

        public void Start()
        { 
            _timer.Start();
            AppLog.Instance.WriteLine("TheIgnoreWorker.Start");
        }

        public void Stop()
        {
            _timer.Stop();
            AppLog.Instance.WriteLine("Total Ingored Windows:" + _ignoredWindowCount.ToString());
            AppLog.Instance.WriteLine("TheIgnoreWorker.Stop");
        }
    }
}
