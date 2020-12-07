using MvcJqGridTest.ViewModel.JQPageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTestForAngularJs.Models.ViewModels;
using WebTestForAngularJs.Models.ViewParamModels;

namespace JQGridTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ListInfors()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetInfors(JQGridPageModel PageGridParam, SearchForUsers searcher)
        {
            var bdt = DateTime.Now;
            List<UsersInfor> list = new List<UsersInfor>();
            var mydefinedHeader = Request.Headers["mydefinedHeader"];
            UsersInfor usr;
            for (int i = 0; i < 35; i++)
            {
                usr = new UsersInfor
                {
                    ID = i,
                    UserName = "USN:" + i.ToString()
                    ,
                    FirstName = string.Format("Fst:{0}", i)
                    ,
                    LastName = string.Format("LstN:{0}", i)
                    ,
                    Age = i * i * i
                };
                list.Add(usr);
            }
            var listResult = new
            {
                total = (int)Math.Ceiling(35 / (float)20),
                page = 1,
                records = 20,
                rows = (
                from x in list
                select new
                {
                    id = x.ID,
                    cell = new string[] {
                    x.ID.ToString(),
                    x.FirstName,
                    x.LastName,
                    x.UserName,
                    x.Age.ToString()
                }
                }
                )
            };
            string intervalMilliSeconds = (DateTime.Now.Subtract(bdt)).TotalMilliseconds.ToString();
            Response.Headers.Add("ReturnHeader", intervalMilliSeconds);
            return Json(listResult);
        }
        public ActionResult Index()
        {
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