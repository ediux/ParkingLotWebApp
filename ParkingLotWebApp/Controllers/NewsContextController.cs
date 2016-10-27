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
    public class NewsContextController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: NewsContext
        public ActionResult Index()
        {
            var news_Body = db.News_Body.Include(n => n.News_Header);
            return View(news_Body.ToList());
        }

        // GET: NewsContext/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Body news_Body = db.News_Body.Find(id);
            if (news_Body == null)
            {
                return HttpNotFound();
            }
            return View(news_Body);
        }

        // GET: NewsContext/Create
        public ActionResult Create(int? id)
        {
            if (id != null && id.HasValue)
            {
                var News_Body = new Models.News_Body()
                {
                    Header_Id = id.Value,
                    Content = string.Empty,
                    CreateUserId = User.Identity.GetUserId<int>(),
                    CreateUTCTime = DateTime.Now.ToUniversalTime(),
                    LastUpdateUserId = User.Identity.GetUserId<int>(),
                    LastUpdateUTCTime = DateTime.Now.ToUniversalTime(),
                    Version = 0,
                    Void = false
                };
                db.News_Body.Add(News_Body);
                db.SaveChanges();
                return RedirectToAction("Edit", "News", new { id = id.Value });
            }

            ViewBag.Id = new SelectList(db.News_Header, "Id", "Caption");
            return View(new News_Body());
        }

        // POST: NewsContext/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header_Id,Content,Version,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Body news_Body)
        {
            if (ModelState.IsValid)
            {
                db.News_Body.Add(news_Body);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.News_Header, "Id", "Caption", news_Body.Id);
            return View(news_Body);
        }

        // GET: NewsContext/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Body news_Body = db.News_Body.Find(id);
            if (news_Body == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.News_Header, "Id", "Caption", news_Body.Id);
            return View(news_Body);
        }

        // POST: NewsContext/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header_Id,Content,Version,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Body news_Body)
        {
            if (ModelState.IsValid)
            {
                news_Body.Void = true;
                db.Entry(news_Body).State = EntityState.Modified;

                var newversion_body = new News_Body();
                newversion_body.Content = news_Body.Content;
                newversion_body.Void = false;
                newversion_body.Header_Id = news_Body.Header_Id;
                newversion_body.Version = news_Body.Version + 1;
                newversion_body.LastUpdateUserId = newversion_body.CreateUserId = news_Body.LastUpdateUserId;
                newversion_body.LastUpdateUTCTime = newversion_body.CreateUTCTime = news_Body.LastUpdateUTCTime;

                db.News_Body.Add(newversion_body);
           
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.News_Header, "Id", "Caption", news_Body.Id);
            return View(news_Body);
        }

        // GET: NewsContext/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Body news_Body = db.News_Body.Find(id);
            if (news_Body == null)
            {
                return HttpNotFound();
            }
            return View(news_Body);
        }

        // POST: NewsContext/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_Body news_Body = db.News_Body.Find(id);
            news_Body.Void = false;
            news_Body.LastUpdateUserId = User.Identity.GetUserId<int>();
            news_Body.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();

            //db.News_Body.Remove(news_Body);
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
