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
    public class ParkingGridsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: ParkingGrids
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var parkingGridByFloorId = db.ParkingGrid.Where(w => w.FloorId == id.Value && w.Void==false).Include(p => p.ParkingLotFloors);
                return View(parkingGridByFloorId.ToList());
            }
            var parkingGrid = db.ParkingGrid.Where(w=>w.Void==false).Include(p => p.ParkingLotFloors);
            return View(parkingGrid.ToList());
        }

        // GET: ParkingGrids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingGrid parkingGrid = db.ParkingGrid.Find(id);
            if (parkingGrid == null)
            {
                return HttpNotFound();
            }
            return View(parkingGrid);
        }

        // GET: ParkingGrids/Create
        public ActionResult Create()
        {
            ViewBag.FloorId = new SelectList(db.ParkingLotFloors.Where(w => w.Void == false), "Id", "Name");
            return View(new ParkingGrid());
        }

        // POST: ParkingGrids/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FloorId,Name,GPS,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ParkingGrid parkingGrid)
        {
            if (ModelState.IsValid)
            {
                db.ParkingGrid.Add(parkingGrid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FloorId = new SelectList(db.ParkingLotFloors.Where(w => w.Void == false), "Id", "Name", parkingGrid.FloorId);
            return View(parkingGrid);
        }

        // GET: ParkingGrids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingGrid parkingGrid = db.ParkingGrid.Find(id);
            if (parkingGrid == null)
            {
                return HttpNotFound();
            }
            ViewBag.FloorId = new SelectList(db.ParkingLotFloors.Where(w => w.Void == false), "Id", "Name", parkingGrid.FloorId);
            return View(parkingGrid);
        }

        // POST: ParkingGrids/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FloorId,Name,GPS,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] ParkingGrid parkingGrid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingGrid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FloorId = new SelectList(db.ParkingLotFloors.Where(w => w.Void == false), "Id", "Name", parkingGrid.FloorId);
            return View(parkingGrid);
        }

        // GET: ParkingGrids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingGrid parkingGrid = db.ParkingGrid.Find(id);
            if (parkingGrid == null)
            {
                return HttpNotFound();
            }
            return View(parkingGrid);
        }

        // POST: ParkingGrids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingGrid parkingGrid = db.ParkingGrid.Find(id);
            db.ParkingGrid.Remove(parkingGrid);
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
