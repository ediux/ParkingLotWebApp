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
    public class SensorsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: Sensors
        public ActionResult Index()
        {
            return View(db.Sensors.ToList());
        }

        // GET: Sensors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensors sensors = db.Sensors.Find(id);
            if (sensors == null)
            {
                return HttpNotFound();
            }
            return View(sensors);
        }

        // GET: Sensors/Create
        public ActionResult Create()
        {
            return View(new Sensors());
        }

        // POST: Sensors/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SerialNumber,GPS,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime")] Sensors sensors)
        {
            if (ModelState.IsValid)
            {
                db.Sensors.Add(sensors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sensors);
        }

        // GET: Sensors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensors sensors = db.Sensors.Find(id);
            if (sensors == null)
            {
                return HttpNotFound();
            }
            return View(sensors);
        }

        // POST: Sensors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SerialNumber,GPS,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime")] Sensors sensors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sensors);
        }

        // GET: Sensors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensors sensors = db.Sensors.Find(id);
            if (sensors == null)
            {
                return HttpNotFound();
            }
            return View(sensors);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sensors sensors = db.Sensors.Find(id);
            db.Sensors.Remove(sensors);
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
