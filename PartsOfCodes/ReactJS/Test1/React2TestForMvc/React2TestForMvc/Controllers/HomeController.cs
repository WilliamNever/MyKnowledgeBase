using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebTestForAngularJs.Models.ViewModels;
using WebTestForAngularJs.Models.ViewParamModels;

namespace React2TestForMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return Contact("ssr");
            //return RedirectToAction("Contact", new { id="SSR" });
            //var view = Contact("ssr") as ViewResult;
            //view.ViewName = "Contact";
            //return view;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string id)
        {
            ViewBag.Message = "Your contact page.";

            //return View("Contact");
            return View();
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        //[OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult GetInfors(SearchForUsers searcher)
        {
            var bdt = DateTime.Now;
            List<UsersInfor> list = new List<UsersInfor>();
            var mydefinedHeader = Request.Headers["mydefinedHeader"];
            UsersInfor usr;
            for (int i = 0; i < 10; i++)
            {
                usr = new UsersInfor
                {
                    ID = i,
                    UserName = "USN:" + i.ToString()
                    ,
                    FirstName = string.Format("Fst:{0}", i)
                    ,
                    LastName = string.Format("LstN:{0}", i)
                    , Age = i * i * i
                };
                list.Add(usr);
            }
            string intervalMilliSeconds = (DateTime.Now.Subtract(bdt)).TotalMilliseconds.ToString();
            Response.Headers.Add("ReturnHeader", intervalMilliSeconds);
            return Json(list);//,JsonRequestBehavior.AllowGet
        }
    }
}