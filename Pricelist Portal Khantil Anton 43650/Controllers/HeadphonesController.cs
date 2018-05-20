using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pricelist_Portal_Khantil_Anton_43650.Models.DB;

namespace Pricelist_Portal_Khantil_Anton_43650.Controllers
{
    public class HeadphonesController : Controller
    {
        private PricelistModel db = new PricelistModel();

        // GET: Headphones
        public ActionResult Index()
        {
            return View(db.Headphones.ToList());
        }

        // GET: Headphones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headphone headphone = db.Headphones.Find(id);
            if (headphone == null)
            {
                return HttpNotFound();
            }
            return View(headphone);
        }

        // GET: Headphones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Headphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brand,ProductCode,Price,Amount,MaxWorkingTime," +
            "TransmissionType,HaveMicrophone,Range,Details")] Headphone headphone)
        {
            if (ModelState.IsValid)
            {
                db.Headphones.Add(headphone);
                db.SaveChanges();
                TempData["msg"] = "<script>alert('Product added successfully!');</script>";
                ModelState.Clear();
                return RedirectToAction("Create");
            }

            return View(headphone);
        }

        // GET: Headphones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headphone headphone = db.Headphones.Find(id);
            if (headphone == null)
            {
                return HttpNotFound();
            }
            return View(headphone);
        }

        // POST: Headphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,ProductCode,Price,Amount,MaxWorkingTime," +
            "TransmissionType,HaveMicrophone,Range,Details")] Headphone headphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headphone);
        }

        // GET: Headphones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headphone headphone = db.Headphones.Find(id);
            if (headphone == null)
            {
                return HttpNotFound();
            }
            return View(headphone);
        }

        // POST: Headphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Headphone headphone = db.Headphones.Find(id);
            db.Headphones.Remove(headphone);
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
