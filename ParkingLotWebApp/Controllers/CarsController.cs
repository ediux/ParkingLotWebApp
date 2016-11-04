using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingLotWebApp.Models;
using Microsoft.AspNet.Identity;

namespace ParkingLotWebApp.Controllers
{
    public class CarsController : Controller
    {
        //private ParkingLotModelEntities db = new ParkingLotModelEntities();
        private ICarsRepository db;
        private IEmployeeRepository db_emp;
        private IETAsRepository db_etc;

        public CarsController()
        {
            db = RepositoryHelper.GetCarsRepository();
            db_emp = RepositoryHelper.GetEmployeeRepository(db.UnitOfWork);
            db_etc = RepositoryHelper.GetETAsRepository(db.UnitOfWork);
        }

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Where(w => w.Void == false)
                .Include(c => c.Employee)
                .Include(c => c.ETAs);

            return View(cars
                .OrderBy(o => o.CarNumber)
                .OrderBy(o => o.CarType)
                .OrderBy(o => o.Employee.Code)
                .OrderBy(o => o.Employee.Name)
                .OrderBy(o => o.ETAs.Code)
                .OrderByDescending(o => o.CreateUTCTime)
                .ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Get(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            var selectemp = db_emp.Where(w => w.Void == false).ToList();
            selectemp.Insert(0, null);
            ViewBag.EmpId = new SelectList(selectemp, "Id", "Name");
            var selectetc = db_etc.Where(w => w.Void == false).ToList();
            selectetc.Insert(0, null);
            ViewBag.ETAId = new SelectList(selectetc, "Id", "Code");
            return View(new Cars());
        }

        // POST: Cars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarNumber,CarType,ETAId,EmpId,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Add(cars);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.EmpId = new SelectList(db_emp.Where(w => w.Void == false), "Id", "Name", cars.EmpId);
            ViewBag.ETAId = new SelectList(db_etc.Where(w => w.Void == false), "Id", "Code", cars.ETAId);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Get(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            var selectemp = db_emp.Where(w => w.Void == false).ToList();
            selectemp.Insert(0, null);
            var selectetc = db_etc.Where(w => w.Void == false).ToList();
            selectetc.Insert(0, null);
            ViewBag.EmpId = new SelectList(selectemp, "Id", "Name", cars.EmpId);
            ViewBag.ETAId = new SelectList(selectetc, "Id", "Code", cars.ETAId);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarNumber,CarType,ETAId,EmpId,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfWork.Context.Entry(cars).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            var selectemp = db_emp.Where(w => w.Void == false).ToList();
            selectemp.Insert(0, new Employee() { Id = -1, Name = "(無)" });
            var selectetc = db_etc.Where(w => w.Void == false).ToList();
            selectetc.Insert(0, new ETAs() { Id = -1, Code = "(無)" });
            ViewBag.EmpId = new SelectList(selectemp, "Id", "Name", cars.EmpId);
            ViewBag.ETAId = new SelectList(selectetc, "Id", "Code", cars.ETAId);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Get(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Get(id);
            cars.Void = true;
            cars.LastUpdateUserId = User.Identity.GetUserId<int>();
            cars.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();
            db.UnitOfWork.Context.Entry(cars).State = EntityState.Modified;
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
