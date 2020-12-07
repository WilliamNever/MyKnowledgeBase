using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExtendInforsDB;

namespace WebTestDoubleEFContext.Controllers
{
    public class OrdersInforsController : Controller
    {
        private ExtendInforsDBContext db = new ExtendInforsDBContext();

        // GET: OrdersInfors
        public ActionResult Index()
        {
            return View(db.OrdersInfors.ToList());
        }

        // GET: OrdersInfors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersInfors ordersInfors = db.OrdersInfors.Find(id);
            if (ordersInfors == null)
            {
                return HttpNotFound();
            }
            return View(ordersInfors);
        }

        // GET: OrdersInfors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersInfors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "StatusChangedDate")] OrdersInfors ordersInfors
            , [Bind(Prefix = "StatusChangedDate.CheckDateTime")]Models.DateTimeViewModel MdDate
            )
        {
            if (ModelState.IsValid)
            {
                ordersInfors.StatusChangedDate = new DateTime(MdDate.Year, MdDate.Month, MdDate.Day);
                db.OrdersInfors.Add(ordersInfors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordersInfors);
        }

        // GET: OrdersInfors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersInfors ordersInfors = db.OrdersInfors.Find(id);
            if (ordersInfors == null)
            {
                return HttpNotFound();
            }
            return View(ordersInfors);
        }

        // POST: OrdersInfors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "StatusChangedDate")]OrdersInfors ordersInfors
            , [Bind(Prefix = "StatusChangedDate.CheckDateTime")]Models.DateTimeViewModel MdDate
            , FormCollection fcs)
        {
            /*[Bind(Include = "ID,UserName,OrderNumber,CreateDate,Status,StatusChangedDate,CheckedUserName",Prefix ="StatusChangedDate")] */
            var objForm = fcs;
            if (ModelState.IsValid)
            {
                ordersInfors.StatusChangedDate = new DateTime(MdDate.Year, MdDate.Month, MdDate.Day);
                db.Entry(ordersInfors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordersInfors);
        }

        // GET: OrdersInfors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersInfors ordersInfors = db.OrdersInfors.Find(id);
            if (ordersInfors == null)
            {
                return HttpNotFound();
            }
            return View(ordersInfors);
        }

        // POST: OrdersInfors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersInfors ordersInfors = db.OrdersInfors.Find(id);
            db.OrdersInfors.Remove(ordersInfors);
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
