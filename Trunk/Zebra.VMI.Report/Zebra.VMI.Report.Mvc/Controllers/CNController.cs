using System;
using System.Web.Mvc;
using Zebra.VMI.Report.Bll;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Common.Model;

namespace Zebra.VMI.Report.Mvc.Controllers
{
    public class CNController : Controller
    {
        public ActionResult Index()
        {
            string config = ConfigMgr.GetSettingByName("DefaultTopCount");
            int defTopCount = 30;
            if (!string.IsNullOrEmpty(config)) defTopCount = Convert.ToInt32(config);

            InventorySnapshotBll bll = new InventorySnapshotBll();
            ViewBag.Items = bll.GetDefaultList(defTopCount);

            FilterModel filter = new FilterModel();
            ViewBag.FilterModel = filter;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FilterModel model)
        {
            string config = ConfigMgr.GetSettingByName("DefaultTopCount");
            int defTopCount = 30;
            if (!string.IsNullOrEmpty(config)) defTopCount = Convert.ToInt32(config);

            InventorySnapshotBll bll = new InventorySnapshotBll();
            ViewBag.Items = bll.GetList(model, defTopCount);

            ViewBag.FilterModel = model;
            return View();
        }
    }
}
