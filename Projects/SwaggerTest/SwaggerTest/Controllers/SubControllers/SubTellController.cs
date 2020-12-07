using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwaggerTest.Controllers.SubControllers
{
    public class SubTellController : Controller
    {
        // GET: SubTell
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubTell/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubTell/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubTell/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubTell/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubTell/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubTell/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubTell/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
