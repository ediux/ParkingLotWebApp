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
    public class CarPurposeTypesController : BaseController
    {
        //private WbParkSystemEntities db = new WbParkSystemEntities();
        private ICarPurposeTypesRepository db = RepositoryHelper.GetCarPurposeTypesRepository();

        // GET: CarPurposeTypes
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View(db.All().ToList());
        }

        // GET: CarPurposeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPurposeTypes carPurposeTypes = db.Get(id);
            if (carPurposeTypes == null)
            {
                return HttpNotFound();
            }
            return View(carPurposeTypes);
        }

        // GET: CarPurposeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarPurposeTypes/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Void")] CarPurposeTypes carPurposeTypes)
        {
            if (ModelState.IsValid)
            {
                db.Add(carPurposeTypes);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(carPurposeTypes);
        }

        // GET: CarPurposeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPurposeTypes carPurposeTypes = db.Get(id);
            if (carPurposeTypes == null)
            {
                return HttpNotFound();
            }
            return View(carPurposeTypes);
        }

        // POST: CarPurposeTypes/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Void")] CarPurposeTypes carPurposeTypes)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfWork.Context.Entry(carPurposeTypes).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(carPurposeTypes);
        }

        // GET: CarPurposeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPurposeTypes carPurposeTypes = db.Get(id);
            if (carPurposeTypes == null)
            {
                return HttpNotFound();
            }
            return View(carPurposeTypes);
        }

        // POST: CarPurposeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarPurposeTypes carPurposeTypes = db.Get(id);
            db.Delete(carPurposeTypes);
            db.UnitOfWork.Commit();
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
