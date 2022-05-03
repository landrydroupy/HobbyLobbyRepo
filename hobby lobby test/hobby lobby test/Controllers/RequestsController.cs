using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hobby_lobby_test.Models;

namespace hobby_lobby_test.Controllers
{
    public class RequestsController : Controller
    {
        private DB_128040_hobbylobbyEntities db = new DB_128040_hobbylobbyEntities();

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Pickup).Include(r => r.Store);
            return View(requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult CreateRequest()
        {
            ViewBag.PickupNumber = new SelectList(db.Pickups, "PickupNumber", "PickupNumber");
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreNumber", "Location");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRequest([Bind(Include = "RequestNumber,StoreNumber,PickupNumber,ToteQuantity,CartonQuantity,LoadLockQuantity,Comments,CreationDate")] Request request)
        {
            if (ModelState.IsValid)
            {
                request.CreationDate = DateTime.Now;
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PickupNumber = new SelectList(db.Pickups, "PickupNumber", "PickupNumber", request.PickupNumber);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreNumber", "Location", request.StoreNumber);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.PickupNumber = new SelectList(db.Pickups, "PickupNumber", "PickupNumber", request.PickupNumber);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreNumber", "Location", request.StoreNumber);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestNumber,StoreNumber,PickupNumber,ToteQuantity,CartonQuantity,LoadLockQuantity,Comments,CreationDate")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PickupNumber = new SelectList(db.Pickups, "PickupNumber", "PickupNumber", request.PickupNumber);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreNumber", "Location", request.StoreNumber);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
