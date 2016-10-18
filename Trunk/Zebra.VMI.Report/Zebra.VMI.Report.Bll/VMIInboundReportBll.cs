using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common.Entities;
using Zebra.VMI.Report.Dal;

namespace Zebra.VMI.Report.Bll
{
    public class VMIInboundReportBll
    {
        public List<InboundReport> GetByStartTime(DateTime startTime)
        {
            string strWhere = "receiveTime > '" + startTime.ToString() + "'";
            return Get(strWhere);
        }

        public List<InboundReport> GetByShipTitle(string ref_value)
        {
            string strWhere = "ref_value = '" + ref_value + "'";
            return Get(strWhere);
        }

        public void GetNewOrders()
        {
            VMIInboundReportDal dal = new VMIInboundReportDal();
            dal.GetNewOrders();
        }
        public void UpdateReport()
        {
            VMIInboundReportDal dal = new VMIInboundReportDal();
            dal.UpdateReport();
        }

        private List<InboundReport> Get(string strWhere)
        {
            VMIInboundReportDal da = new VMIInboundReportDal();
            DataSet ds = da.Get(strWhere);
            if (ds == null || ds.Tables.Count == 0) return null;
            List<InboundReport> list = new List<InboundReport>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                InboundReport entity = new InboundReport();
                GetEntity(entity, row);
                list.Add(entity);
            }
            return list;
        }
        private void GetEntity(InboundReport entity, DataRow dr)
        {
            entity.Id = dr["Id"].ToString();
            entity.ref_value = dr["ref_value"].ToString();
            entity.partner = dr["partner"].ToString();
            entity.slArea = dr["slArea"].ToString();
            entity.pin = dr["pin"].ToString();
            entity.receiveTime = Convert.IsDBNull(dr["receiveTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["receiveTime"]);
            entity.PostFlux = dr["PostFlux"].ToString();
            entity.SEFLAG = dr["SEFLAG"].ToString();
            entity.LotNo = dr["LotNo"].ToString();
            entity.AddTime = Convert.IsDBNull(dr["AddTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["AddTime"]);
            if (entity.partner.Equals("CSC44453"))
            {
                entity.ParseStatus = dr["ParseStatus"].ToString();
            }
            else if (entity.partner.Equals("CSC40467"))
            {
                if (!(entity.LotNo == null || entity.LotNo == ""))
                {
                    entity.ParseStatus = "Y";
                }
                else
                {
                    entity.ParseStatus = "N";
                }
            }
            else
            {
                entity.ParseStatus = "Y";
            }
        }
    }
}
