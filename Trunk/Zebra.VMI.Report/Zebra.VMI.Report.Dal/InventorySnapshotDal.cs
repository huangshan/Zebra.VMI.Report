using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;

namespace Zebra.VMI.Report.Dal
{
    public class InventorySnapshotDal
    {
        public DataSet Get(string strWhere, int topCount = 0)
        {
            StringBuilder strSql = new StringBuilder();
            if (topCount > 0) strSql.Append("SELECT TOP " + topCount.ToString());
            else
                strSql.Append("SELECT");
            strSql.Append(@" Id
                                  ,warehouseId
                                  ,itemId
                                  ,batchCode
                                  ,inventoryType
                                  ,quantity
                                  ,modifiedTime");
            strSql.Append(" FROM InventorySnapshot WITH (NOLOCK) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" order by modifiedTime desc");
            return EWMSReportQuery(strSql.ToString());
        }


        private DataSet EWMSReportQuery(string SQLString)
        {
            var ConnectionString = ConfigMgr.GetConnectionString("Zebra_eWMS_Report");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }
}
