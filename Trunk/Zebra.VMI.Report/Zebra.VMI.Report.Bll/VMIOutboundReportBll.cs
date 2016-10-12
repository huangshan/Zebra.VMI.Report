using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Dal;

namespace Zebra.VMI.Report.Bll
{
    public class VMIOutboundReportBll
    {
        private void GetEntity(OutboundReport model, DataRow dr)
        {
            model.Id = dr["Id"].ToString();
            model.slCode = dr["slCode"].ToString();
            model.shipTitle = dr["shipTitle"].ToString();
            model.slArea = dr["slArea"].ToString();
            model.suPin = dr["suPin"].ToString();
            model.suCode = dr["suCode"].ToString();
            model.status = dr["status"].ToString();
            model.intoDate = Convert.IsDBNull(dr["intoDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["intoDate"]);
            model.slAAECode = dr["slAAECode"].ToString();
            model.slDate = Convert.IsDBNull(dr["slDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["slDate"]);
            model.slFlag = Convert.IsDBNull(dr["slFlag"]) ? 0 : Convert.ToInt32(dr["slFlag"]);
            model.NewOrder = dr["NewOrder"].ToString();
            model.IsPacked = dr["IsPacked"].ToString();
            model.PackedTime = Convert.IsDBNull(dr["PackedTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["PackedTime"]);
            model.PackedWeight = Convert.IsDBNull(dr["PackedWeight"]) ? 0 : Convert.ToDecimal(dr["PackedWeight"]);
            model.IsCz = dr["IsCz"].ToString();
            model.CzTime = Convert.IsDBNull(dr["CzTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CzTime"]);
            model.CzWeight = Convert.IsDBNull(dr["CzWeight"]) ? 0 : Convert.ToDecimal(dr["CzWeight"]);
            model.ShipWeight = Convert.IsDBNull(dr["ShipWeight"]) ? 0 : Convert.ToDecimal(dr["ShipWeight"]);
            model.RealWeight = Convert.IsDBNull(dr["RealWeight"]) ? 0 : Convert.ToDecimal(dr["RealWeight"]);
            model.ChargeWeight = Convert.IsDBNull(dr["ChargeWeight"]) ? 0 : Convert.ToDecimal(dr["ChargeWeight"]);
            model.IsPayment = dr["IsPayment"].ToString();
            model.IsOutbound = dr["IsOutBound"].ToString();
            model.OutboundTime = Convert.IsDBNull(dr["OutBoundTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["OutBoundTime"]);
            model.OutboundWeight = Convert.IsDBNull(dr["OutBoundWeight"]) ? 0 : Convert.ToDecimal(dr["OutBoundWeight"]);
            model.AddTime = Convert.IsDBNull(dr["AddTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["AddTime"]);
        }
    }
}
