using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingLotWebApp.Models;

namespace ParkingLotWebApp.Controllers
{
    public class ETAsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: ETAs
        public ActionResult Index()
        {
            return View(db.ETAs.ToList());
        }

        // GET: ETAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs eTAs = db.ETAs.Find(id);
            if (eTAs == null)
            {
                return HttpNotFound();
            }
            return View(eTAs);
        }

        // GET: ETAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ETAs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ETAs eTAs)
        {
            if (ModelState.IsValid)
            {
                db.ETAs.Add(eTAs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eTAs);
        }

        // GET: ETAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs eTAs = db.ETAs.Find(id);
            if (eTAs == null)
            {
                return HttpNotFound();
            }
            return View(eTAs);
        }

        // POST: ETAs/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ETAs eTAs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTAs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eTAs);
        }

        // GET: ETAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs eTAs = db.ETAs.Find(id);
            if (eTAs == null)
            {
                return HttpNotFound();
            }
            return View(eTAs);
        }

        // POST: ETAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ETAs eTAs = db.ETAs.Find(id);
            db.ETAs.Remove(eTAs);
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
