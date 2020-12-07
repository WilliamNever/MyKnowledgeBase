using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForT4TemplateTest.Controllers
{
    public partial class AtestController : Controller
    {
        // GET: Atest
        public virtual ActionResult Index()
        {
            UserInforsDB.UserInforsDBContext db = new UserInforsDB.UserInforsDBContext("UserInforsDB");
            return View(db.UserInfors);
        }

        public virtual ActionResult Create()
        {
            return View();
        }
    }
}