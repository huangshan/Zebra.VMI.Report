using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Bll;

namespace Zebra.VMI.Report.Service
{
    public class Outbound
    {
        public void Run()
        {
            VMIOutboundReportBll bll = new VMIOutboundReportBll();
            bll.GetNewOrders();
            bll.UpdateReport();
        }
    }
}
