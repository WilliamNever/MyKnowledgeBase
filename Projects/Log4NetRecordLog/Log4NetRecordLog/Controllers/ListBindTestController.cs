using Log4NetRecordLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetRecordLog.Controllers
{
    public class ListBindTestController : Controller
    {
        // GET: ListBindTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowList()
        {
            List<CheckValueClass> list = new List<ViewModels.CheckValueClass>();
            int round = 10, tmp;
            var rdm = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < round; i++)
            {
                tmp = rdm.Next(round);
                list.Add(new CheckValueClass { IsChecked = tmp > i, ItemName = $"{tmp}/{i}:", Value = i });
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowListPost(List<CheckValueClass> list, FormCollection frm)
        {
            PageViewModel pvm = new ViewModels.PageViewModel();
            //var ss = frm.Get("ItemNameList");
            pvm.OpString = frm["ItemNameList"];
            pvm.CheckValueList = list;
            return View(pvm);
        }

        public ActionResult InputTest()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InputTest(PageInputClass Infor)
        {
            var biresulter = ModelState.IsValid;
            return View(Infor);
        }
    }
}