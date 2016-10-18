using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zebra.VMI.Report.Bll;
using Zebra.VMI.Report.Common.Model;

namespace Zebra.VMI.Report.Mvc.Controllers
{
    public class OutboundController : Controller
    {
        //
        // GET: /Outbound/

        public ActionResult Index()
        {
            VMIOutboundReportBll bll = new VMIOutboundReportBll();
            DateTime now = DateTime.Now;
            //now = now.AddDays(-10);
            DateTime startTime = new DateTime(now.Year, now.Month, now.Day);
            ViewBag.Items = bll.GetByStartTime(startTime);
            FilterModel filter = new FilterModel();
            ViewBag.FilterModel = filter;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FilterModel model)
        {
            VMIOutboundReportBll bll = new VMIOutboundReportBll();
            DateTime now = DateTime.Now;
            DateTime startTime = new DateTime(now.Year, now.Month, now.Day);
            if (string.IsNullOrEmpty(model.ShipTitle))
                ViewBag.Items = bll.GetByStartTime(startTime);
            else
                ViewBag.Items = bll.GetByShipTitle(model.ShipTitle);
            ViewBag.FilterModel = model;
            return View();
        }
    }
}
