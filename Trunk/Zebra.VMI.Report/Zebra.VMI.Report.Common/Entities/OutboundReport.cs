using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common
{
    public class OutboundReport
    {
        public string Id { get; set; }
        public string slCode { get; set; }
        public string shipTitle { get; set; }
        public string slArea { get; set; }
        public string suPin { get; set; }
        public string suCode { get; set; }
        public string status { get; set; }
        public DateTime intoDate { get; set; }
        public string slAAECode { get; set; }
        public DateTime slDate { get; set; }
        public int slFlag { get; set; }
        public string NewOrder { get; set; }
        public string IsPacked { get; set; }
        public DateTime PackedTime { get; set; }
        public decimal PackedWeight { get; set; }
        public string IsCz { get; set; }
        public DateTime CzTime { get; set; }
        public decimal CzWeight { get; set; }
        public decimal ShipWeight { get; set; }
        public decimal RealWeight { get; set; }
        public decimal ChargeWeight { get; set; }
        public string IsPayment { get; set; }
        public string IsOutbound { get; set; }
        public DateTime OutboundTime { get; set; }
        public decimal OutboundWeight { get; set; }
        public DateTime AddTime { get; set; }
    }
}
