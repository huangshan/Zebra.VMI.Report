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
    public class LogDal
    {
        public bool Add(Log log)
        {
            string sqlString = @"INSERT INTO VMI_LOG (APPDOMAINNAME, CATEGORY, MACHINENAME, [MESSAGE], ERRORMESSAGE, [TIMESTAMP], [REFERENCEID] ) VALUES(@APPDOMAINNAME, @CATEGORY, @MACHINENAME, @MESSAGE, @ERRORMESSAGE, GETDATE(), @REFERENCEID);";
            SqlParameter[] parameters = {
                                        new SqlParameter("@APPDOMAINNAME", SqlDbType.VarChar,50),
                                        new SqlParameter("@CATEGORY", SqlDbType.VarChar,50),
                                        new SqlParameter("@MACHINENAME", SqlDbType.VarChar,50),
                                        new SqlParameter("@MESSAGE", SqlDbType.VarChar,2000),
                                        new SqlParameter("@ERRORMESSAGE", SqlDbType.VarChar, -1),
                                        new SqlParameter("@REFERENCEID", SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = log.AppDomainName;
            parameters[1].Value = log.Category;
            parameters[2].Value = log.MachineName;
            parameters[3].Value = log.Message;
            parameters[4].Value = log.ErrorMessage;
            parameters[5].Value = log.ReferenceId;
            var rows = DbHelperSQL.ExecuteSql(sqlString, parameters);
            return rows > 0;
        }
    }
}
