using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Dal;

namespace Zebra.VMI.Report.Logging
{
    public class DBLogger
    {
        private static readonly string machineName;
        static DBLogger()
        {
            machineName = Environment.MachineName ?? string.Empty;
        }

        public static void Write(string referenceId, AppDomainName appDomain, EventCategory category, Exception ex)
        {
            try
            {
                var log = new Log { AppDomainName = appDomain.ToString(), Category = category.ToString(), MachineName = machineName, Message = ex.Message, ErrorMessage = ex.ToString(), TimeStamp = DateTime.Now, ReferenceId = referenceId };
                LogDal logDAL = new LogDal();
                logDAL.Add(log);
            }
            catch (Exception exception)
            {
                FileLogger.WriteLog(exception, "日志错误" + ex.Message);
            }
        }
        public static void Write(string referenceId, AppDomainName appDomain, EventCategory category, string message)
        {
            try
            {
                var log = new Log { AppDomainName = appDomain.ToString(), Category = category.ToString(), MachineName = machineName, Message = message, TimeStamp = DateTime.Now, ReferenceId = referenceId };
                LogDal logDAL = new LogDal();
                logDAL.Add(log);
            }
            catch (Exception ex)
            {
                FileLogger.WriteLog(ex, "日志错误" + ex.Message);
            }
        }
    }
}
