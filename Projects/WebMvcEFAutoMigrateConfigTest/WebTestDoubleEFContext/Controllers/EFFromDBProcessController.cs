using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebTestDoubleEFContext.Controllers
{
    public class EFFromDBProcessController : Controller
    {
        public ActionResult AsyncTest()
        {
            var task =
                Task.Run(async () => { await Task.Delay(3000); return "Over Task!"; });
            ViewBag.ax = task.Result;
            return View();
        }
        // GET: EFFromDBProcess
        public async Task<ActionResult> Index()
        {
            //var dbTask = GetUserInforsDBEntitiesAsync();
            //await dbTask;
            //var db = dbTask.Result;

            var task = Task.Run(() =>
            {
                return new EFFromDB.UserInforsDBEntities().UserInfors.ToList();
            });
            await task;

            return View(task.Result);
        }

        private async Task<EFFromDB.UserInforsDBEntities> GetUserInforsDBEntitiesAsync()
        {
            var task = Task.Run(() => {
                return new EFFromDB.UserInforsDBEntities();
            });

            return await task;
        }
    }
}