using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common
{
    public class InventorySnapshot
    {
        public int Id { get; set; }
        public string WarehouseId { get; set; }
        public string ItemId { get; set; }
        public string BatchCode { get; set; }
        public int InventoryType { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
