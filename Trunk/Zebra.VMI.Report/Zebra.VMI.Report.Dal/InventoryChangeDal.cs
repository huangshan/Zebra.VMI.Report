using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;

namespace Zebra.VMI.Report.Dal
{
    public class InventoryChangeDal
    {
        public DataSet Get(string strWhere, int topCount=0)
        {
            StringBuilder strSql = new StringBuilder();
            if (topCount > 0) strSql.Append("SELECT TOP " + topCount.ToString());
            else
                strSql.Append("SELECT");
            strSql.Append(@" [Id]
                                  ,[SUCODE]
                                  ,[SGCODE]
                                  ,[SGSTATUS]
                                  ,[SGAREA]
                                  ,[OPTIME]
                                  ,[REMAINQTY]
                                  ,[DIFFQTY]
                                  ,[BATCHNO]
                                  ,[OREMAINQTY]");
            strSql.Append(" FROM Flux_InventoryChange WITH (NOLOCK) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" order by OPTIME desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
