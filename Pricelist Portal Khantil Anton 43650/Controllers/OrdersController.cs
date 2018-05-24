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
    public class OrdersController : Controller
    {
        private PricelistModel db = new PricelistModel();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(long? id)
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
            ViewBag.H = "No headphones in order. ";
            ViewBag.T = "No TVs in order. ";
            var h = db.Headphones.Find(order.HeadphoneEntryNo);
            var t = db.Headphones.Find(order.TVEntryNo);
            if (h != null)  
                ViewBag.H = "Headphones: " + h.Brand + " " + h.ProductCode + " Price:" + h.Price;
            if (t != null)
                ViewBag.T = "TV: " + t.Brand + " " + t.ProductCode + " Price:" + t.Price;
            return View(order);
        }
         
        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.TVsList = GetTVListItems();
            ViewBag.HeadphonesList = GetHeadphoneListItems();
            return View();
        }

        public List<SelectListItem> GetHeadphoneListItems()
        {
            var headphones = db.Headphones.ToList();
            List<SelectListItem> headphoneListItems = new List<SelectListItem>();
            headphoneListItems.Add(new SelectListItem() { Value = "0", Text = "Not selected", Selected = true });
            foreach (var item in headphones)
                headphoneListItems.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Brand + " " + item.ProductCode + " Price:" + item.Price });
            return headphoneListItems;
        }

        public List<SelectListItem> GetTVListItems()
        {
            var tvs = db.TVs.ToList();
            List<SelectListItem> tvListItems = new List<SelectListItem>();
            tvListItems.Add(new SelectListItem() { Value = "0", Text = "Not selected", Selected = true });
            foreach (var item in tvs)
                tvListItems.Add(new SelectListItem() { Value = item.TV_ID.ToString(), Text = item.Brand + " " + item.ProductCode + " Price:" + item.Price });
            return tvListItems;
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryNo,CustomerEmail,CustomerPhoneNumber,CustomerName,CustomerAddress,HeadphoneEntryNo,TVEntryNo")] Order order)
        {
            ViewBag.TVsList = GetTVListItems();
            ViewBag.HeadphonesList = GetHeadphoneListItems();
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.TVsList = GetTVListItems();
            ViewBag.HeadphonesList = GetHeadphoneListItems();
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryNo,CustomerEmail,CustomerPhoneNumber,CustomerName,CustomerAddress,HeadphoneEntryNo,TVEntryNo")] Order order)
        {
            ViewBag.TVsList = GetTVListItems();
            ViewBag.HeadphonesList = GetHeadphoneListItems();
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(long? id)
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
            ViewBag.H = "No headphones in order. ";
            ViewBag.T = "No TVs in order. ";
            var h = db.Headphones.Find(order.HeadphoneEntryNo);
            var t = db.Headphones.Find(order.TVEntryNo);
            if (h != null)
                ViewBag.H = "Headphones: " + h.Brand + " " + h.ProductCode + " Price:" + h.Price;
            if (t != null)
                ViewBag.T = "TV: " + t.Brand + " " + t.ProductCode + " Price:" + t.Price;
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
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
