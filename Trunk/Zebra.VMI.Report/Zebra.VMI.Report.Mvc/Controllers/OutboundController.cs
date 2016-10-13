using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zebra.VMI.Report.Bll;

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
            DateTime startTime = new DateTime(now.Year, now.Month, now.Day);
            ViewBag.Items = bll.GetByStartTime(startTime);
            return View();
        }

    }
}
