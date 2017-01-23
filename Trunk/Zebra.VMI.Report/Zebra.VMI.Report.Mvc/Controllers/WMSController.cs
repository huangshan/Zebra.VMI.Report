using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Zebra.VMI.Report.Bll;
using Zebra.VMI.Report.Common;
using Zebra.VMI.Report.Common.Model;

namespace Zebra.VMI.Report.Mvc.Controllers
{
    public class WMSController : Controller
    {
        public ActionResult Index()
        {
            string config = ConfigMgr.GetSettingByName("DefaultTopCount");
            int defTopCount = 30;
            if (!string.IsNullOrEmpty(config)) defTopCount = Convert.ToInt32(config);

            InventoryChangeBll bll = new InventoryChangeBll();
            ViewBag.Items = bll.GetDefaultList(defTopCount);

            FilterModel filter = new FilterModel();
            var dt = DateTime.Now;
            filter.StartTime = dt.AddDays(-1);
            filter.EndTime = dt;
            ViewBag.FilterModel = filter;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FilterModel model)
        {
            string config = ConfigMgr.GetSettingByName("DefaultTopCount");
            int defTopCount = 30;
            if (!string.IsNullOrEmpty(config)) defTopCount = Convert.ToInt32(config);

            InventoryChangeBll bll = new InventoryChangeBll();
            ViewBag.Items = bll.GetList(model, defTopCount);

            ViewBag.FilterModel = model;
            return View();
        }
    }
}
