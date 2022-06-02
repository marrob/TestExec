using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.TestExec.AutoIgnoreService
{
    public partial class IgnoreService : ServiceBase
    {

        readonly TheIgnoreWorker _ignore = new TheIgnoreWorker();

        public IgnoreService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnStart():Begin");
                _ignore.Start();
            }
            catch (Exception ex)
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnStart():Exception" + ex.Message);
                throw ex;
            }
        }

        protected override void OnStop()
        {
            try
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnStop():Begin");
                _ignore.Stop();
            }
            catch (Exception ex)
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnStop():Exception" + ex.Message);
                throw ex;
            }
        }
        public void OnDebug()
        {
            try
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnDebug():Begin");
                _ignore.Start();
            }
            catch (Exception ex)
            {
                AppLog.Instance.WriteLine("IgnoreService.cs.OnDebug():Exception" + ex.Message);
                throw ex;
            }
        }

        protected override void OnShutdown()
        {
            AppLog.Instance.WriteLine("!!!IgnoreService.cs.OnShutdown():Begin");
            this.Stop();
            base.OnShutdown();
        }
    }
}
