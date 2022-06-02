using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.TestExec.AutoIgnoreService
{
    internal static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            AppLog.Instance.WriteLine("FirstLine");

#if DEBUG
            IgnoreService service = new IgnoreService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new IgnoreService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
