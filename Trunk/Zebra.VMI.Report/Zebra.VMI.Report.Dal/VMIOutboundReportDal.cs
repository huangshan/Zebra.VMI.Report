using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;

namespace Zebra.VMI.Report.Dal
{
    public class VMIOutboundReportDal
    {
        public DataSet Get(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [Id]
                                  ,[RefValue]
                                  ,[ReceiveTime]
                                  ,[ParseStatus]
                                  ,[SendbackFlag]
                                  ,[slCode]
                                  ,[shipTitle]
                                  ,[slArea]
                                  ,[suPin]
                                  ,[suCode]
                                  ,[status]
                                  ,[intoDate]
                                  ,[slAAECode]
                                  ,[slDate]
                                  ,[slFlag]
                                  ,[NewOrder]
                                  ,[IsPacked]
                                  ,[PackedTime]
                                  ,[PackedWeight]
                                  ,[IsCz]
                                  ,[CzTime]
                                  ,[CzWeight]
                                  ,[ShipWeight]
                                  ,[RealWeight]
                                  ,[ChargeWeight]
                                  ,[IsPayment]
                                  ,[IsOutBound]
                                  ,[OutBoundTime]
                                  ,[OutBoundWeight]
                                  ,[AddTime]");
            strSql.Append(" FROM VMI_OutboundReport WITH (NOLOCK) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void GetNewOrders()
        {
            DbHelperSQL.ExecuteSql("EXEC GetNewOutboundOrders");
        }
        public void UpdateReport()
        {
            DbHelperSQL.ExecuteSql("EXEC UPDATEOUTBOUNDREPORT");
        }
    }
}
