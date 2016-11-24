using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingLotWebApp.Models;
using Microsoft.Security.Application;
using ParkingLotWebApp;

namespace ParkingLotWebApp.Controllers
{
    [Authorize]
    public class ParkingLotAreasController : BaseController
    {
        private IParkingLotsDetailRepository db = RepositoryHelper.GetParkingLotsDetailRepository();

        // GET: ParkingLotAreas
        public ActionResult Index()
        {
            return View(db.Where(w=>w.Void==false)
                .ToList());
        }

        // GET: ParkingLotAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotsDetail parkingLotAreas = db.Get(id);
            if (parkingLotAreas == null)
            {
                return HttpNotFound();
            }
            parkingLotAreas.Charge = HttpUtility.HtmlDecode(parkingLotAreas.Charge);
            return View(parkingLotAreas);
        }

        // GET: ParkingLotAreas/Create
        public ActionResult Create()
        {
            return View(new ParkingLotsDetail());
        }

        // POST: ParkingLotAreas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Tel,Period,Charge,Longitude,Latitude,CarGrid,MotoGrid,Void,LastUpdate")] ParkingLotsDetail parkingLotAreas)
        {
            this.ApplyXSSProtected(parkingLotAreas);

            if (ModelState.IsValid)
            {
                //TODO: 加入可能被XSS攻擊的文字輸入框或是弱型別資料的輸入
                //parkingLotAreas.Address = Sanitizer.GetSafeHtmlFragment(parkingLotAreas.Address);
                //parkingLotAreas.Charge = Sanitizer.GetSafeHtmlFragment(parkingLotAreas.Charge);
               
                db.Add(parkingLotAreas);
                db.UnitOfWork.Commit();
               
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
            ParkingLotsDetail parkingLotAreas = db.Get(id);
            parkingLotAreas.LastUpdate = DateTime.Now;
            parkingLotAreas.Charge = HttpUtility.HtmlDecode(parkingLotAreas.Charge);
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
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Tel,Period,Charge,Longitude,Latitude,CarGrid,MotoGrid,Void,LastUpdate")] ParkingLotsDetail parkingLotAreas)
        {
            
            if (ModelState.IsValid)
            {
                this.ApplyXSSProtected(parkingLotAreas);
                db.UnitOfWork.Context.Entry(parkingLotAreas).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            parkingLotAreas.LastUpdate = DateTime.Now;
            parkingLotAreas.Charge = HttpUtility.HtmlDecode(parkingLotAreas.Charge);
            return View(parkingLotAreas);
        }

        // GET: ParkingLotAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotsDetail parkingLotAreas = db.Get(id);
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
            ParkingLotsDetail parkingLotAreas = db.Get(id);
            parkingLotAreas.Void = true;
            parkingLotAreas.LastUpdate = DateTime.UtcNow;
            db.UnitOfWork.Context.Entry(parkingLotAreas).State = EntityState.Modified;
            db.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult RemainIndex()
        {
            return View(db.Where(w => w.Void == false)
                .ToList());
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
