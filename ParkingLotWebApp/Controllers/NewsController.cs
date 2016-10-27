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
using System.Threading.Tasks;

namespace ParkingLotWebApp.Controllers
{
    public class NewsController : Controller
    {
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        // GET: News
        public async Task<ActionResult> Index()
        {
            var news_Header = await db.News_Header.Where(w => w.Void == false).Include(n => n.News_Body).ToListAsync();
            return View(news_Header.OrderBy(o => o.CreateUTCTime));
        }

        // GET: News/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = await db.News_Header.FindAsync(id);
            if (news_Header == null)
            {
                return HttpNotFound();
            }
            return View(news_Header);
        }

        // GET: News/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content");
            return await Task.Run(() => { return View(new News_Header()); });
        }

        // POST: News/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Header news_Header)
        {
            if (ModelState.IsValid)
            {
                news_Header = db.News_Header.Add(news_Header);
                await db.SaveChangesAsync();
                return RedirectToAction("Create", "NewsContext", new { id = news_Header.Id });  //重導至新增內文的控制器
            }

            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);
            return View(news_Header);
        }

        // GET: News/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = await db.News_Header.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] News_Header news_Header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_Header).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);
            return View(news_Header);
        }

        // GET: News/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Header news_Header = await db.News_Header.FindAsync(id);
            if (news_Header == null)
            {
                return HttpNotFound();
            }
            return View(news_Header);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            News_Header news_Header = await db.News_Header.FindAsync(id);
            news_Header.Void = false;
            news_Header.LastUpdateUserId = User.Identity.GetUserId<int>();
            news_Header.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();

            foreach (var item in news_Header.News_Body.Where(w => w.Void == false))
            {
                item.Void = false;
            }

            // db.News_Header.Remove(news_Header);
            await db.SaveChangesAsync();
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
