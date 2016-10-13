using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common.Model
{
    public class FilterModel
    {
        public string ShipTitle { get; set; }
        public string SuCode { get; set; }
        public string AreaCode { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
