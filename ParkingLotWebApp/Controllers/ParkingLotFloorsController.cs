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
    public class ParkingLotFloorsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: ParkingLotFloors
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var parkingLotFloorsByFiliter = db.ParkingLotFloors.Include(p => p.ParkingLotAreas);
                return View(parkingLotFloorsByFiliter.Where(w => w.AreaId == id).ToList());
            }
            var parkingLotFloors = db.ParkingLotFloors.Include(p => p.ParkingLotAreas);
            return View(parkingLotFloors.ToList());
        }

        // GET: ParkingLotFloors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.ParkingLotFloors.Find(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.ParkingLotAreas, "Id", "Name");
            return View();
        }

        // POST: ParkingLotFloors/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaId,Name,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime")] ParkingLotFloors parkingLotFloors)
        {
            if (ModelState.IsValid)
            {
                db.ParkingLotFloors.Add(parkingLotFloors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.ParkingLotAreas, "Id", "Name", parkingLotFloors.AreaId);
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.ParkingLotFloors.Find(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.ParkingLotAreas, "Id", "Name", parkingLotFloors.AreaId);
            return View(parkingLotFloors);
        }

        // POST: ParkingLotFloors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaId,Name,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime")] ParkingLotFloors parkingLotFloors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingLotFloors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.ParkingLotAreas, "Id", "Name", parkingLotFloors.AreaId);
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.ParkingLotFloors.Find(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotFloors);
        }

        // POST: ParkingLotFloors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingLotFloors parkingLotFloors = db.ParkingLotFloors.Find(id);
            db.ParkingLotFloors.Remove(parkingLotFloors);
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
