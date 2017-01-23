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
    public class InventorySnapshotBll
    {
        public List<InventorySnapshot> GetList(FilterModel model, int topCount)
        {
            StringBuilder strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(model.SKU))
                strWhere.Append("itemId='" + model.SKU + "'");
            if (model.StartTime != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(strWhere.ToString()))
                    strWhere.Append(" and modifiedTime>='" + model.StartTime + "'");
                else
                    strWhere.Append(" modifiedTime>='" + model.StartTime + "'");
            }
            if (model.EndTime != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(strWhere.ToString()))
                    strWhere.Append(" and modifiedTime<='" + model.EndTime + "'");
                else
                    strWhere.Append(" modifiedTime<='" + model.EndTime + "'");
            }
            if (string.IsNullOrEmpty(strWhere.ToString()))
                return GetDefaultList(topCount);
            else
                return GetList(strWhere.ToString());
        }
        public List<InventorySnapshot> GetList(string strWhere)
        {
            return Get(strWhere);
        }
        public List<InventorySnapshot> GetDefaultList(int topCount)
        {
            string strWhere = "";
            return Get(strWhere, topCount);
        }
        private List<InventorySnapshot> Get(string strWhere, int topCount = 0)
        {
            InventorySnapshotDal dal = new InventorySnapshotDal();
            DataSet ds = dal.Get(strWhere, topCount);
            if (ds == null || ds.Tables.Count == 0) return null;
            List<InventorySnapshot> list = new List<InventorySnapshot>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                InventorySnapshot entity = new InventorySnapshot();
                GetEntity(entity, row);
                list.Add(entity);
            }
            return list;
        }
        private void GetEntity(InventorySnapshot entity, DataRow dr)
        {
            entity.Id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
            entity.WarehouseId = dr["warehouseId"].ToString();
            entity.ItemId = dr["itemId"].ToString();
            entity.BatchCode = dr["batchCode"].ToString();
            entity.InventoryType = Convert.IsDBNull(dr["inventoryType"]) ? 0 : Convert.ToInt32(dr["inventoryType"]);
            entity.Quantity = Convert.IsDBNull(dr["quantity"]) ? 0 : Convert.ToInt32(dr["quantity"]);
            entity.ModifiedTime = Convert.IsDBNull(dr["modifiedTime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["modifiedTime"]);
        }
    }
}
