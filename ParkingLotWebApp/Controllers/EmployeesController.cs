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

namespace ParkingLotWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository db;

        public EmployeesController()
        {
            db = RepositoryHelper.GetEmployeeRepository();
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Where(w=>w.Void==false).ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View(Employee.Create(User.Identity.GetUserId<int>()));
        }

        // POST: Employees/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUTCTime")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Add(employee);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUTCTime")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfWork.Context.Entry(employee).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Get(id);
            employee.Void = true;
            employee.LastUserId = User.Identity.GetUserId<int>();
            employee.LastUpdateUTCTime = DateTime.UtcNow;
            db.UnitOfWork.Context.Entry(employee).State = EntityState.Modified;
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
