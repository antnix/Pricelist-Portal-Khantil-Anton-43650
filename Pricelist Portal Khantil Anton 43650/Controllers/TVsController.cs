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
    public class TVsController : Controller
    {
        private PricelistModel db = new PricelistModel();

        public ActionResult Index()
        {
            return View(db.TVs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TV tV = db.TVs.Find(id);
            if (tV == null)
            {
                return HttpNotFound();
            }
            return View(tV);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TV_ID,Brand,ProductCode,Price,Amount," +
            "EnergyClass,ScreenDiagonal,SmartTV,WiFi,Details")] TV tV)
        {
            if (ModelState.IsValid)
            {
                db.TVs.Add(tV);
                db.SaveChanges();
                TempData["msg"] = "<script>alert('Product added successfully!');</script>";
                ModelState.Clear();
                return RedirectToAction("Create");
            }
            return View(tV);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TV tV = db.TVs.Find(id);
            if (tV == null)
            {
                return HttpNotFound();
            }
            return View(tV);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TV_ID,Brand,ProductCode,Price,Amount," +
            "EnergyClass,ScreenDiagonal,SmartTV,WiFi,Details")] TV tV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tV);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TV tV = db.TVs.Find(id);
            if (tV == null)
            {
                return HttpNotFound();
            }
            return View(tV);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TV tV = db.TVs.Find(id);
            db.TVs.Remove(tV);
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
