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
        private IAnnouncementDetailRepository db = RepositoryHelper.GetAnnouncementDetailRepository();

        // GET: News
        public async Task<ActionResult> Index()
        {
            var news_Header = await db.All().ToListAsync();
            return View(news_Header.OrderBy(o => o.ToTop).OrderByDescending(o => o.StartDate));
        }

        // GET: News/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    News_Header news_Header = await db.News_Header.FindAsync(id);
        //    if (news_Header == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(news_Header);
        //}

        // GET: News/Create
        public ActionResult Create()
        {
            var model = new NewsPostViewModel();
            model.Caption = string.Empty;
            model.Content = string.Empty;
            model.Void = false;
            model.StartTime = DateTime.Now.ToUniversalTime();
            model.EndTime = model.StartTime.AddDays(1);
            model.LastUpdateUserId = model.CreateUserId = User.Identity.GetUserId<int>();
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();

            return View(model);
        }

        // POST: News/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime")] NewsPostViewModel newspostViewModel)
        {
            if (ModelState.IsValid)
            {
                var news = new AnnouncementDetail();
                news.Detail = newspostViewModel.Content;
                news.EndDate = newspostViewModel.EndTime;
                news.LastUpdate = newspostViewModel.LastUpdateUTCTime;
                news.StartDate = newspostViewModel.StartTime;
                news.Title = newspostViewModel.Caption;
                news.ToTop = newspostViewModel.IsTop;

                db.Add(news);
                //var news_Header = new News_Header();
                //news_Header.Caption = newspostViewModel.Caption;
                //news_Header.CreateUserId = newspostViewModel.CreateUserId;
                //news_Header.CreateUTCTime = newspostViewModel.CreateUTCTime;
                //news_Header.EndTime = newspostViewModel.EndTime;
                //news_Header.LastUpdateUserId = newspostViewModel.LastUpdateUserId;
                //news_Header.LastUpdateUTCTime = newspostViewModel.LastUpdateUTCTime;
                //news_Header.StartTime = newspostViewModel.StartTime;
                //news_Header.Void = newspostViewModel.Void;
                //news_Header = db.News_Header.Add(news_Header);
                //newspostViewModel.Id = news_Header.Id;

                //var news_Body = new News_Body();
                //news_Body.Content = newspostViewModel.Content;
                //news_Body.CreateUserId = newspostViewModel.CreateUserId;
                //news_Body.CreateUTCTime = newspostViewModel.CreateUTCTime;
                //news_Body.Header_Id = news_Header.Id;
                //news_Body.LastUpdateUserId = newspostViewModel.LastUpdateUserId;
                //news_Body.LastUpdateUTCTime = newspostViewModel.LastUpdateUTCTime;
                //news_Body.Version = newspostViewModel.Version;
                //news_Body.Void = newspostViewModel.Void;
                //news_Body = db.News_Body.Add(news_Body);
                //newspostViewModel.Body_Id = news_Body.Id;

                await db.UnitOfWork.CommitAsync();
                return RedirectToAction("Index");  //重導至新增內文的控制器
            }

            return View(newspostViewModel);
        }

        // GET: News/Edit/5
        [OutputCache(Duration = 0, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Server)]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                AnnouncementDetail news_Header = await db.GetAsync(id);

                if (news_Header == null)
                {
                    return HttpNotFound();
                }

                NewsPostViewModel viewmodel = new NewsPostViewModel(news_Header);
                viewmodel.LastUpdateUserId = User.Identity.GetUserId<int>();
                viewmodel.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();
                // ViewBag.Id = new SelectList(db.News_Body, "Id", "Content", news_Header.Id);

                return View(viewmodel);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // POST: News/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Server)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Caption,StartTime,EndTime,Void,CreateUserId,CreateUTCTime,LastUpdateUserId,LastUpdateUTCTime,Body_Id,Content,Version")] NewsPostViewModel viewModel)
        {

            if (viewModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                AnnouncementDetail news_Header = await db.GetAsync(viewModel.Id);

                if (news_Header == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                news_Header.Title = viewModel.Caption;
                news_Header.Detail = viewModel.Content;
                news_Header.StartDate = viewModel.StartTime;
                news_Header.EndDate = viewModel.EndTime;
              
                news_Header.LastUpdate = viewModel.LastUpdateUTCTime;

                db.UnitOfWork.Context.Entry(news_Header).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                
            }


            return RedirectToAction("Index");
        }

        //// GET: News/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    News_Header news_Header = await db.News_Header.FindAsync(id);
        //    if (news_Header == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    NewsPostViewModel viewModel = new NewsPostViewModel(news_Header);
        //    return View(viewModel);
        //}

        //// POST: News/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    News_Header news_Header = await db.News_Header.FindAsync(id);
        //    news_Header.Void = true;
        //    news_Header.LastUpdateUserId = User.Identity.GetUserId<int>();
        //    news_Header.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();

        //    foreach (var item in news_Header.News_Body.Where(w => w.Void == false))
        //    {
        //        item.Void = true;
        //        item.LastUpdateUserId = news_Header.LastUpdateUserId;
        //        item.LastUpdateUTCTime = news_Header.LastUpdateUTCTime;
        //    }

        //    // db.News_Header.Remove(news_Header);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
