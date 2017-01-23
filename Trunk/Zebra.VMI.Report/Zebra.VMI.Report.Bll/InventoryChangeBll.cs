using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Common.Model;
using Zebra.VMI.Report.Dal;

namespace Zebra.VMI.Report.Bll
{
    public class InventoryChangeBll
    {
        public List<InventoryChange> GetList(FilterModel model, int topCount)
        {
            StringBuilder strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(model.SKU))
                strWhere.Append("sgcode='" + model.SKU + "'");
            if (!string.IsNullOrEmpty(model.SuCode))
            {
                if (!string.IsNullOrEmpty(strWhere.ToString()))
                    strWhere.Append(" and");
                strWhere.Append(" SUCODE='" + model.SuCode + "'");
            }
                if (model.StartTime != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(strWhere.ToString()))
                    strWhere.Append(" and");
                strWhere.Append(" OPTIME>='" + model.StartTime + "'");
            }
            if (model.EndTime != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(strWhere.ToString()))
                    strWhere.Append(" and");
                strWhere.Append(" OPTIME<='" + model.EndTime + "'");
            }
            if (string.IsNullOrEmpty(strWhere.ToString()))
                return GetDefaultList(topCount);
            else
                return GetList(strWhere.ToString());
        }
        public List<InventoryChange> GetList(string strWhere)
        {
            return Get(strWhere);
        }
        public List<InventoryChange> GetDefaultList(int topCount)
        {
            string strWhere = "";
            return Get(strWhere, topCount);
        }
        private List<InventoryChange> Get(string strWhere, int topCount=0)
        {
            InventoryChangeDal dal = new InventoryChangeDal();
            DataSet ds = dal.Get(strWhere, topCount);
            if (ds == null || ds.Tables.Count == 0) return null;
            List<InventoryChange> list = new List<InventoryChange>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                InventoryChange entity = new InventoryChange();
                GetEntity(entity, row);
                list.Add(entity);
            }
            return list;
        }
        private void GetEntity(InventoryChange entity, DataRow dr)
        {
            entity.Id = dr["Id"].ToString();
            entity.SuCode = dr["SUCODE"].ToString();
            entity.SgCode = dr["SGCODE"].ToString();
            entity.SgStatus = Convert.IsDBNull(dr["SGSTATUS"]) ? "" : dr["SGSTATUS"].ToString();
            entity.SgArea = dr["SGAREA"].ToString();
            entity.OpTime = Convert.IsDBNull(dr["OPTIME"]) ? DateTime.MinValue : Convert.ToDateTime(dr["OPTIME"]);
            entity.RemainQty = Convert.IsDBNull(dr["REMAINQTY"]) ? 0 : Convert.ToInt32(dr["REMAINQTY"]);
            entity.DiffQty = Convert.IsDBNull(dr["DIFFQTY"]) ? 0 : Convert.ToInt32(dr["DIFFQTY"]);
            entity.BatchNo = Convert.IsDBNull(dr["BATCHNO"]) ? "" : dr["BATCHNO"].ToString();
            entity.ORemainQty = Convert.IsDBNull(dr["OREMAINQTY"]) ? 0 : Convert.ToInt32(dr["OREMAINQTY"]);
            
        }
    }
}
