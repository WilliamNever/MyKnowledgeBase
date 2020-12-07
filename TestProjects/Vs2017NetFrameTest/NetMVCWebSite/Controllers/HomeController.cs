using NetMVCWebSite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetMVCWebSite.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizedFilter(Policy = "Hellen.Read")]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizedFilter(Policy = "Hellen.About")]
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