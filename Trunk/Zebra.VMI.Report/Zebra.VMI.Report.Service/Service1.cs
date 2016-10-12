using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Logging;

namespace Zebra.VMI.Report.Service
{
    public partial class Service1 : ServiceBase
    {
        private Scheduler _scheduler;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_scheduler == null) _scheduler = new Scheduler();
            _scheduler.Start();
            Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Info, "VMI Report Service started " + DateTime.Now);
        }

        protected override void OnStop()
        {
            if (_scheduler != null)
                _scheduler.Stop();
            Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Info, "VMI Report Service stopped " + DateTime.Now);
        }
    }
}
