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
    public class ParkingLotAreasController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: ParkingLotAreas
        public ActionResult Index()
        {
            return View(db.ParkingLotAreas.ToList());
        }

        // GET: ParkingLotAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotAreas parkingLotAreas = db.ParkingLotAreas.Find(id);
            if (parkingLotAreas == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotAreas);
        }

        // GET: ParkingLotAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingLotAreas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,GPS,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ParkingLotAreas parkingLotAreas)
        {
            if (ModelState.IsValid)
            {
                db.ParkingLotAreas.Add(parkingLotAreas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkingLotAreas);
        }

        // GET: ParkingLotAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotAreas parkingLotAreas = db.ParkingLotAreas.Find(id);
            if (parkingLotAreas == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotAreas);
        }

        // POST: ParkingLotAreas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GPS,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ParkingLotAreas parkingLotAreas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingLotAreas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkingLotAreas);
        }

        // GET: ParkingLotAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotAreas parkingLotAreas = db.ParkingLotAreas.Find(id);
            if (parkingLotAreas == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotAreas);
        }

        // POST: ParkingLotAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingLotAreas parkingLotAreas = db.ParkingLotAreas.Find(id);
            db.ParkingLotAreas.Remove(parkingLotAreas);
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
