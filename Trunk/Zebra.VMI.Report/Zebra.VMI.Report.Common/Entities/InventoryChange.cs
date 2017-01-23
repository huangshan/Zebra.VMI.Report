using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common
{
    public class InventoryChange
    {
        public string Id { get; set; }
        public string SuCode { get; set; }
        public string SgCode { get; set; }
        public string SgStatus { get; set; }
        public string SgArea { get; set; }
        public DateTime OpTime { get; set; }
        public int RemainQty { get; set; }
        public int DiffQty { get; set; }
        public string BatchNo { get; set; }
        public int ORemainQty { get; set; }
    }
}
