using ForNodeJSTest.SelfDefinedAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForNodeJSTest.Areas.OP.Controllers
{
    public class HomeController : Controller
    {
        // GET: OP/Home
        [UAuthorize(Roles = "Administrators")]
        public ActionResult Index()
        {
            var areaName = ControllerContext.RouteData.DataTokens["area"];
            return View();
        }
    }
}