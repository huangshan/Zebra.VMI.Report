using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Logging;

namespace Zebra.VMI.Report.Service
{
    public class Scheduler
    {
        private Thread _outboundThread;
        private Thread _inboundThread;
        private int _sleepTime = 10;
        public Scheduler()
        {
            try
            {
                _sleepTime = Convert.ToInt32(ConfigMgr.GetSettingByName("SchedulerSleepTime"));
            }
            catch (Exception ex)
            {
                Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Error, ex);
            }
        }

        public void Start()
        {
            try
            {
                if (_outboundThread == null)
                {
                    var thread = new ThreadStart(OutboundReportMonitor);
                    _outboundThread = new Thread(thread);
                    _outboundThread.IsBackground = true;
                    _outboundThread.Start();
                }
                if (_inboundThread == null)
                {
                    var thread = new ThreadStart(InboundReportMonitor);
                    _inboundThread = new Thread(thread);
                    _inboundThread.IsBackground = true;
                    _inboundThread.Start();
                }                
            }
            catch (Exception ex)
            {
                Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Error, ex);
            }
        }
        public void Stop()
        {
            try
            {
                if (_outboundThread != null && _outboundThread.IsAlive)
                {
                    _outboundThread.Abort();
                }
                if (_inboundThread != null && _inboundThread.IsAlive)
                {
                    _inboundThread.Abort();
                }
            }
            catch (Exception ex)
            {
                Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Error, ex);
            }
        }

        private void OutboundReportMonitor()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(Convert.ToInt32(_sleepTime) * 1000);
                }
            }
            catch (Exception ex)
            {
                Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Error, ex);
            }
        }

        private void InboundReportMonitor()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(Convert.ToInt32(_sleepTime) * 1000);
                }
            }
            catch (Exception ex)
            {
                Logger.Write("ZebraVmiReport", AppDomainName.ZebraVmiReport, EventCategory.Error, ex);
            }
        }
    }
}
