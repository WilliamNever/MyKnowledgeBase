using Log4NetRecordLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetRecordLog.DoubleTestControllers
{
    public class DoubleFormTestController : Controller
    {
        // GET: DoubleFormTest
        public ActionResult Index(string id)
        {
            var test = this.Request.QueryString;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetSubmit1(CheckValueClass cvc)
        {
            var isPassed = ModelState.IsValid;
            cvc.ItemName = $"GetSubmit1 - {cvc.ItemName}";
            return View("Index", cvc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetSubmit2(CheckValueClass cvc)
        {
            var isPassed = ModelState.IsValid;
            cvc.ItemName = $"GetSubmit2 - {cvc.ItemName}";
            return View("Index", cvc);
        }
    }
}