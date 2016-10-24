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
    public class NewsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: News
        public ActionResult Index()
        {
            var news_Header = db.News_Header.Include(n => n.News_Body);
            return View(news_Header.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = db.News_Header.Find(id);
            if (news_Header == null)
            {
                return HttpNotFound();
            }
            return View(news_Header);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content");
            return View();
        }

        // POST: News/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Header news_Header)
        {
            if (ModelState.IsValid)
            {
                db.News_Header.Add(news_Header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);
            return View(news_Header);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = db.News_Header.Find(id);
            if (news_Header == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);
            return View(news_Header);
        }

        // POST: News/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Header news_Header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_Header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);
            return View(news_Header);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = db.News_Header.Find(id);
            if (news_Header == null)
            {
                return HttpNotFound();
            }
            return View(news_Header);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_Header news_Header = db.News_Header.Find(id);
            db.News_Header.Remove(news_Header);
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
