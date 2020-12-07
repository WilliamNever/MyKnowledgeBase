using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetRecordLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            log4net.LogManager.GetLogger(this.GetType()).Error("Test Errors!", new Exception("Hello Test!"));
            //log4net.LogManager.GetLogger("testApp.Logging").Error("Test Errors!", new Exception("Hello Test!"));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}