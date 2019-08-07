using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;

namespace And.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private AndDB db = new AndDB();

        // GET: Admin/AdminOrders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Status).Include(o => o.User).Include(o => o.UserAddress);
            return View(orders.ToList());
        }

        // GET: Admin/AdminOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name");
            ViewBag.UserAddressID = new SelectList(db.Addresses, "ID", "Title");
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,UserAddressID,StatusID,TotalProductPrice,TotalTaxPrice,TotalDiscount,TotalPrice,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "Name", order.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name", order.UserID);
            ViewBag.UserAddressID = new SelectList(db.Addresses, "ID", "Title", order.UserAddressID);
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "Name", order.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name", order.UserID);
            ViewBag.UserAddressID = new SelectList(db.Addresses, "ID", "Title", order.UserAddressID);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,UserAddressID,StatusID,TotalProductPrice,TotalTaxPrice,TotalDiscount,TotalPrice,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "Name", order.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name", order.UserID);
            ViewBag.UserAddressID = new SelectList(db.Addresses, "ID", "Title", order.UserAddressID);
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
