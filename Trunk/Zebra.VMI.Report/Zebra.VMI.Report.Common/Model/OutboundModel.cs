using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common.Model
{
    public class OutboundModel
    {
        public string ShipTitle { get; set; }
        public string SlArea { get; set; }
        public string SuCode { get; set; }
        public DateTime IntoDate { get; set; }
        public string PreStatus { get; set; }
        public string NewOrder { get; set; }
        public string IsPacked { get; set; }
        public string IsCz { get; set; }
        public string IsPayment { get; set; }
        public string IsOutbound { get; set; }
        public string IsSend { get; set; }
    }
}
