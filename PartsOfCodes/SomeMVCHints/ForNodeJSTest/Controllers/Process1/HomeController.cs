using ForNodeJSTest.SelfDefinedAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForNodeJSTest.Controllers.Process1
{
    public class HomeController : Controller
    {
        // GET: Home
        [UAuthorize]
        public ActionResult Index()
        {
            var areaName = ControllerContext.RouteData.DataTokens["area"];
            return View("~/Views/Process1/Home/Index.cshtml");
        }
    }
}