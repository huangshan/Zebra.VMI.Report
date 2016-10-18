using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Common.Entities;

namespace Zebra.VMI.Report.Dal
{
    public class VMIInboundReportDal
    {
        public DataSet Get(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [Id]
                                  ,[ref_value]
                                  ,[partner]
                                  ,[slArea]
                                  ,[pin]
                                  ,[receiveTime]
                                  ,[ParseStatus]
                                  ,[PostFlux]
                                  ,[SEFLAG]
                                  ,[LotNo]
                                  ,[AddTime]");
            strSql.Append(" FROM VMI_InboundReport WITH (NOLOCK) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere + "order by receivetime desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void GetNewOrders()
        {
            DbHelperSQL.ExecuteSql("EXEC GetNewInboundOrders");
        }
        public void UpdateReport()
        {
            DbHelperSQL.ExecuteSql("EXEC UpdateInboundReport");
        }
    }
}
