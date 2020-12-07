using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTestForAngularJs.Models.ViewModels;
using WebTestForAngularJs.Models.ViewParamModels;

namespace WebTestForAngularJs.Controllers
{

    public class OptItm
    {
        public bool IsChecked { get; set; }
        public string ItemName { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<OptItm> strList = new List<OptItm>();

            for (int i = 0; i < 10; i++)
            {
                strList.Add(new OptItm { ItemName = "html"+i, IsChecked = i < 5 });
            }

            return View(strList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            HttpContext.Response.Headers.Add("Hello", "World");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
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
            return Json(list);
        }
    }
}