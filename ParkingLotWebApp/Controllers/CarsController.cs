﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingLotWebApp.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

namespace ParkingLotWebApp.Controllers
{
    [Authorize]
    [HandleError(ExceptionType = typeof(DbEntityValidationException),
      View = "DbEntityValidationException")]
    public class CarsController : Controller
    {
        //private ParkingLotModelEntities db = new ParkingLotModelEntities();
        private ICarsRepository db;
        private IEmployeeRepository db_emp;
        private IETAsRepository db_etc;
        private ICarPurposeTypesRepository db_carPurpose;

        public CarsController()
        {
            db = RepositoryHelper.GetCarsRepository();
            db_emp = RepositoryHelper.GetEmployeeRepository(db.UnitOfWork);
            db_etc = RepositoryHelper.GetETAsRepository(db.UnitOfWork);
            db_carPurpose = RepositoryHelper.GetCarPurposeTypesRepository(db.UnitOfWork);
        }

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db_etc.Where(w => w.Void == false)
                .Include(c => c.Cars)
                .OrderByDescending(o => o.Cars.LastUpdateUTCTime)
                .OrderByDescending(o => o.Cars.CarNumber); ;

            return View(cars
                .ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection collection)
        {
            string etagid = collection["SearchTagId"];
            string carnumber = collection["SearchCarNumber"];
            string empid = collection["SearchEmpNo"];

            var cars = db_etc.Where(w => w.Void == false)
                .Include(c => c.Cars);

            if (!string.IsNullOrEmpty(etagid))
                cars = cars.Where(w => w.Code.Contains(etagid));

            if (!string.IsNullOrEmpty(carnumber))
                cars = cars.Where(w => w.Cars.CarNumber.Contains(carnumber));

            if (!string.IsNullOrEmpty(empid))
                cars = cars.Where(w => w.Cars.Employee.Code.Contains(empid));

            cars = cars
                .OrderByDescending(o => o.Cars.LastUpdateUTCTime)
                .OrderByDescending(o => o.Cars.CarNumber);

            return View("Index", cars
                .ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs cars = db_etc.Get(id);
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
            ViewBag.CarPurposeTypeID = new SelectList(db_carPurpose.All(), "Id", "Name");
            return View(new Cars());
        }

        // POST: Cars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarNumber,CarType,ETAId,EmpId,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime,CarPurposeTypeID")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Add(cars);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.EmpId = new SelectList(db_emp.Where(w => w.Void == false), "Id", "Name", cars.EmpId);
            //ViewBag.ETAId = new SelectList(db_etc.Where(w => w.Void == false), "Id", "Code", cars.ETCsID);
            ViewBag.CarPurposeTypeID = new SelectList(db_carPurpose.All(), "Id", "Name");
            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs etcbycars = db_etc.Get(id);
            if (etcbycars == null)
            {
                return HttpNotFound();
            }
            //var selectemp = db_emp.Where(w => w.Void == false).ToList();
            //selectemp.Insert(0, null);
            //var selectetc = db.Where(w => w.Void == false).ToList();
            //selectetc.Insert(0, null);
            //ViewBag.EmpId = new SelectList(selectemp, "Id", "Name", etcbycars.Cars.EmpId);
            //ViewBag.ETCsID = new SelectList(selectetc, "Id", "Code", cars.ETCsID);
            int carpurposetypeid = 0;
            if (etcbycars.Cars != null)
            {
                carpurposetypeid = etcbycars.Cars.CarPurposeTypeID ?? 0;
            }
            ViewBag.CarPurposeType = new SelectList(db_carPurpose.All(), "Id", "Name", carpurposetypeid);
            //etcbycars.Cars.Employee = etcbycars.Cars.Employee ?? new Models.Employee();                
            return View(etcbycars);
        }

        // POST: Cars/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var cars = db_etc.Get(id);

            if (TryValidateModel(cars))
            {
                string emp_code = collection["Cars.Employee.Code"];

                if (string.IsNullOrEmpty(emp_code) == false && emp_code.ToUpper().StartsWith("REMOVE:"))
                {
                    //刪除員工對應
                    if (cars.Cars != null)
                    {
                        if (cars.Cars.Employee != null)
                        {
                            cars.Cars.EmpId = null;
                        }
                    }
                }
                else
                {
                    var emp = db_emp.All().SingleOrDefault(w => w.Code == (emp_code ?? ""));

                    if (emp != null)
                    {
                        cars.Cars.EmpId = emp.Id;
                    }
                }

                string car_carNumber = collection["Cars.CarNumber"];

                if (cars.Cars != null && cars.Cars.CarNumber != car_carNumber)
                {
                    var foundnumber = db.All().SingleOrDefault(s => s.CarNumber.Equals(car_carNumber, StringComparison.InvariantCultureIgnoreCase));

                    if (foundnumber != null)
                    {
                        cars.CarRefId = foundnumber.Id;
                        cars.LastUpdateUserId = User.Identity.GetUserId<int>();
                        cars.LastUpdateUTCTime = DateTime.Now;
                    }
                    else
                    {
                        Cars tmpNewCar = new Cars();
                        tmpNewCar.CarNumber = car_carNumber;
                        tmpNewCar.CarPurposeTypeID = int.Parse(collection["Cars.CarPurposeTypeID"]);
                        tmpNewCar.CarType = "C";
                        tmpNewCar.CreateUserId = User.Identity.GetUserId<int>();
                        tmpNewCar.CreateUTCTime = DateTime.Now;
                        tmpNewCar.Void = false;
                        tmpNewCar.LastUpdateUserId = User.Identity.GetUserId<int>();
                        tmpNewCar.LastUpdateUTCTime = tmpNewCar.CreateUTCTime;
                        db.Add(tmpNewCar);
                        db.UnitOfWork.Commit();
                        tmpNewCar = db.Reload(tmpNewCar);
                        cars.CarRefId = tmpNewCar.Id;
                    }
                }
                cars.Cars.CarPurposeTypeID = int.Parse(collection["Cars.CarPurposeTypeID"]);
                db.UnitOfWork.Context.Entry(cars).State = EntityState.Modified;
                db.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            var selectemp = db_emp.Where(w => w.Void == false).ToList();
            selectemp.Insert(0, new Employee() { Id = -1, Name = "(無)" });
            var selectetc = db_etc.Where(w => w.Void == false).ToList();
            selectetc.Insert(0, new ETAs() { Id = -1, Code = "(無)" });
            ViewBag.EmpId = new SelectList(selectemp, "Id", "Name", cars.Cars.EmpId);
            //ViewBag.ETCsID = new SelectList(selectetc, "Id", "Code", cars.ETCsID);
            ViewBag.CarPurposeType = new SelectList(db_carPurpose.All(), "Id", "Name");
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAs etc = db_etc.Get(id);
            if (etc == null)
            {
                return HttpNotFound();
            }
            return View(etc);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ETAs etc = db_etc.Get(id);
            etc.CarRefId = null;
            etc.Cars = null;
            etc.LastUpdateUserId = User.Identity.GetUserId<int>();
            etc.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();
            db_etc.UnitOfWork.Context.Entry(etc).State = EntityState.Modified;
            db_etc.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars car = db.Get(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCar(int id, FormatException collection)
        {
            Cars car = db.Get(id);
            car.ETAs.Clear();   //斷開所有ETC的關聯
            car.Void = true;
            car.LastUpdateUserId = User.Identity.GetUserId<int>();
            car.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();
            db.UnitOfWork.Context.Entry(car).State = EntityState.Modified;
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
