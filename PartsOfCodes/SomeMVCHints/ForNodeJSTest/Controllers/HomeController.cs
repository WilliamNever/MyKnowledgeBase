using ForNodeJSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ForNodeJSTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var areaName = ControllerContext.RouteData.DataTokens["area"];
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

        public ActionResult Login()
        {
            LoginClass UsLogInfor = new LoginClass { UsName = "admin", Password = "" };
            var isLogin = this.User.Identity.IsAuthenticated;
            return View(UsLogInfor);
        }

        [HttpPost]
        public ActionResult Login(LoginClass UsLogInfor)
        {
            #region for check infors
            /*
                //建立身份验证票对象
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket (1,u.Uname, DateTime.Now, DateTime.Now.AddMinutes(30), false,roles,"/");
                //加密序列化验证票为字符串
                string hashTicket = FormsAuthentication.Encrypt (ticket) ;
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
                HttpContext.Current.Response.Cookies.Add(userCookie);
             */
            #endregion

            FormsAuthentication.SetAuthCookie(UsLogInfor.UsName, false);
            return RedirectToRoute("Default", new { controller = "Home", Action = "Index" });
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Default", new { controller = "Home", Action = "Index" });
        }
    }
}