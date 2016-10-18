using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common.Entities
{
    public class InboundReport
    {
        public string Id { get; set; }
        public string ref_value { get; set; }
        public string partner { get; set; }
        public string slArea { get; set; }
        public string pin { get; set; }
        public DateTime receiveTime { get; set; }
        public string ParseStatus { get; set; }
        public string PostFlux { get; set; }
        public string SEFLAG { get; set; }
        public string LotNo { get; set; }
        public DateTime AddTime { get; set; }
    }
}
