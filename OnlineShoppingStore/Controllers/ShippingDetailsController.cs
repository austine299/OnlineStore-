using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Controllers
{
    public class ShippingDetailsController : Controller
    {
        private dbMyOnlineStoreEntities db = new dbMyOnlineStoreEntities();

        // GET: ShippingDetails
        public ActionResult Index()
        {
            var shippingDetails = db.ShippingDetails.Include(s => s.Member);
            return View(shippingDetails.ToList());
        }

        // GET: ShippingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingDetail shippingDetail = db.ShippingDetails.Find(id);
            if (shippingDetail == null)
            {
                return HttpNotFound();
            }
            return View(shippingDetail);
        }

        // GET: ShippingDetails/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: ShippingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingDetailId,MemberId,Address,City,State,Country,ZipCode,OrderId,AmountPaid,PaymentType")] ShippingDetail shippingDetail)
        {
            if (ModelState.IsValid)
            {
                db.ShippingDetails.Add(shippingDetail);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", shippingDetail.MemberId);
            return View(shippingDetail);
        }

        // GET: ShippingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingDetail shippingDetail = db.ShippingDetails.Find(id);
            if (shippingDetail == null)
            {
                return HttpNotFound();
            }
            return View(shippingDetail);
        }

        // POST: ShippingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingDetail shippingDetail = db.ShippingDetails.Find(id);
            db.ShippingDetails.Remove(shippingDetail);
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
