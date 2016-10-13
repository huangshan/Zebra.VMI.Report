using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Common.Model;
using Zebra.VMI.Report.Dal;

namespace Zebra.VMI.Report.Bll
{
    public class VMIOutboundReportBll
    {
        public List<OutboundReport> GetByStartTime(DateTime startTime)
        {
            string strWhere = "intodate > '"+startTime.ToString()+"'";
            return Get(strWhere);
        }

        public List<OutboundReport> GetByShipTitle(string shipTitle)
        {
            string strWhere = "shipTitle = '" + shipTitle + "'";
            return Get(strWhere);
        }
        
        public void GetNewOrders()
        {
            VMIOutboundReportDal dal = new VMIOutboundReportDal();
            dal.GetNewOrders();
        }
        public void UpdateReport()
        {
            VMIOutboundReportDal dal = new VMIOutboundReportDal();
            dal.UpdateReport();
        }

        private List<OutboundReport> Get(string strWhere)
        {
            VMIOutboundReportDal da = new VMIOutboundReportDal();
            DataSet ds = da.Get(strWhere);
            if (ds == null || ds.Tables.Count == 0) return null;
            List<OutboundReport> list = new List<OutboundReport>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                OutboundReport entity = new OutboundReport();
                GetEntity(entity, row);
                list.Add(entity);
            }
            return list;
        }
        private void GetEntity(OutboundReport entity, DataRow dr)
        {
            entity.Id = dr["Id"].ToString();
            entity.slCode = dr["slCode"].ToString();
            entity.shipTitle = dr["shipTitle"].ToString();
            entity.slArea = dr["slArea"].ToString();
            entity.suPin = dr["suPin"].ToString();
            entity.suCode = dr["suCode"].ToString();
            entity.status = dr["status"].ToString();
            entity.intoDate = Convert.IsDBNull(dr["intoDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["intoDate"]);
            entity.slAAECode = dr["slAAECode"].ToString();
            entity.slDate = Convert.IsDBNull(dr["slDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["slDate"]);
            entity.slFlag = Convert.IsDBNull(dr["slFlag"]) ? 0 : Convert.ToInt32(dr["slFlag"]);
            entity.NewOrder = dr["NewOrder"].ToString();
            entity.IsPacked = dr["IsPacked"].ToString();
            entity.PackedTime = Convert.IsDBNull(dr["PackedTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["PackedTime"]);
            entity.PackedWeight = Convert.IsDBNull(dr["PackedWeight"]) ? 0 : Convert.ToDecimal(dr["PackedWeight"]);
            entity.IsCz = dr["IsCz"].ToString();
            entity.CzTime = Convert.IsDBNull(dr["CzTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CzTime"]);
            entity.CzWeight = Convert.IsDBNull(dr["CzWeight"]) ? 0 : Convert.ToDecimal(dr["CzWeight"]);
            entity.ShipWeight = Convert.IsDBNull(dr["ShipWeight"]) ? 0 : Convert.ToDecimal(dr["ShipWeight"]);
            entity.RealWeight = Convert.IsDBNull(dr["RealWeight"]) ? 0 : Convert.ToDecimal(dr["RealWeight"]);
            entity.ChargeWeight = Convert.IsDBNull(dr["ChargeWeight"]) ? 0 : Convert.ToDecimal(dr["ChargeWeight"]);
            entity.IsPayment = dr["IsPayment"].ToString();
            entity.IsOutbound = dr["IsOutBound"].ToString();
            entity.OutboundTime = Convert.IsDBNull(dr["OutBoundTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["OutBoundTime"]);
            entity.OutboundWeight = Convert.IsDBNull(dr["OutBoundWeight"]) ? 0 : Convert.ToDecimal(dr["OutBoundWeight"]);
            entity.AddTime = Convert.IsDBNull(dr["AddTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["AddTime"]);
        }
    }
}
