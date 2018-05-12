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

        // GET: TVs
        public ActionResult Index()
        {
            return View(db.TVs.ToList());
        }

        // GET: TVs/Details/5
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

        // GET: TVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TV_ID,Brand,ProductCode,Price,Amount," +
            "EnergyClass,ScreenDiagonal,SmartTV,WiFi,Details")] TV tV)
        {
            if (ModelState.IsValid)
            {
                db.TVs.Add(tV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tV);
        }

        // GET: TVs/Edit/5
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

        // POST: TVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: TVs/Delete/5
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

        // POST: TVs/Delete/5
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
