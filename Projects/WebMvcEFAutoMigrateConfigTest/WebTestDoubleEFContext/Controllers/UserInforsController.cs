using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserInforsDB;

namespace WebTestDoubleEFContext.Controllers
{
    public class UserInforsController : Controller
    {
        private UserInforsDBContext db = new UserInforsDBContext();

        // GET: UserInfors
        public ActionResult Index()
        {
            return View(db.UserInfors.ToList());
        }

        // GET: UserInfors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfors userInfors = db.UserInfors.Find(id);
            if (userInfors == null)
            {
                return HttpNotFound();
            }
            return View(userInfors);
        }

        // GET: UserInfors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Age,Email")] UserInfors userInfors)
        {
            if (ModelState.IsValid)
            {
                db.UserInfors.Add(userInfors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfors);
        }

        // GET: UserInfors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfors userInfors = db.UserInfors.Find(id);
            if (userInfors == null)
            {
                return HttpNotFound();
            }
            return View(userInfors);
        }

        // POST: UserInfors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,Age,Email")] UserInfors userInfors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfors);
        }

        // GET: UserInfors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfors userInfors = db.UserInfors.Find(id);
            if (userInfors == null)
            {
                return HttpNotFound();
            }
            return View(userInfors);
        }

        // POST: UserInfors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfors userInfors = db.UserInfors.Find(id);
            db.UserInfors.Remove(userInfors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
