using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Common
{
    public class Log
    {
        public string AppDomainName { get; set; }
        public string Category { get; set; }
        public string MachineName { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ReferenceId { get; set; }
    }
}
