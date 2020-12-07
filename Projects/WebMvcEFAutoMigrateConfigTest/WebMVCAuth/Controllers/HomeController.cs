using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            //db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("MyRoleA"));
            //db.SaveChanges();

            ViewBag.AppString = System.Configuration.ConfigurationManager.AppSettings["TestNode"]?.ToString().Trim();
            ViewBag.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString().Trim();
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