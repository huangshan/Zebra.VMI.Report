using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Bll;

namespace Zebra.VMI.Report.Service
{
    public class Inbound
    {
        public void Run()
        {
            VMIInboundReportBll bll = new VMIInboundReportBll();
            bll.GetNewOrders();
            bll.UpdateReport();
        }
    }
}
