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
                var news_Header = new News_Header();
                news_Header.Caption = newspostViewModel.Caption;
                news_Header.CreateUserId = newspostViewModel.CreateUserId;
                news_Header.CreateUTCTime = newspostViewModel.CreateUTCTime;
                news_Header.EndTime = newspostViewModel.EndTime;
                news_Header.LastUpdateUserId = newspostViewModel.LastUpdateUserId;
                news_Header.LastUpdateUTCTime = newspostViewModel.LastUpdateUTCTime;
                news_Header.StartTime = newspostViewModel.StartTime;
                news_Header.Void = newspostViewModel.Void;
                news_Header = db.News_Header.Add(news_Header);
                newspostViewModel.Id = news_Header.Id;

                var news_Body = new News_Body();
                news_Body.Content = newspostViewModel.Content;
                news_Body.CreateUserId = newspostViewModel.CreateUserId;
                news_Body.CreateUTCTime = newspostViewModel.CreateUTCTime;
                news_Body.Header_Id = news_Header.Id;
                news_Body.LastUpdateUserId = newspostViewModel.LastUpdateUserId;
                news_Body.LastUpdateUTCTime = newspostViewModel.LastUpdateUTCTime;
                news_Body.Version = newspostViewModel.Version;
                news_Body.Void = newspostViewModel.Void;
                news_Body = db.News_Body.Add(news_Body);
                newspostViewModel.Body_Id = news_Body.Id;

                await db.SaveChangesAsync();
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

            News_Header news_Header = await db.News_Header.FindAsync(id);

            if (news_Header == null)
            {
                return HttpNotFound();
            }

            NewsPostViewModel viewmodel = new Models.NewsPostViewModel(news_Header);
            viewmodel.LastUpdateUserId = User.Identity.GetUserId<int>();
            viewmodel.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();

            try
            {
                var postcontent = news_Header.News_Body.Where(w => w.Void == false)
                    .OrderByDescending(o => o.Version)
                    .Take(1)
                    .SingleOrDefault();

                if (postcontent != null)
                {
                    viewmodel.Body_Id = postcontent.Id;
                    viewmodel.Content = HttpUtility.HtmlDecode(postcontent.Content);
                    viewmodel.Version = postcontent.Version;
                }
                else
                {
                    viewmodel.Body_Id = -1;
                    viewmodel.Content = string.Empty;
                    viewmodel.Version = 0;
                }

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
                News_Header news_Header = await db.News_Header.FindAsync(viewModel.Id);

                if (news_Header == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                news_Header.Caption = viewModel.Caption;
                news_Header.StartTime = viewModel.StartTime;
                news_Header.EndTime = viewModel.EndTime;
                news_Header.LastUpdateUserId = viewModel.LastUpdateUserId;
                news_Header.LastUpdateUTCTime = viewModel.LastUpdateUTCTime;

                db.Entry(news_Header).State = EntityState.Modified;

                if (news_Header.News_Body != null)
                {
                    foreach (var item in news_Header.News_Body)
                    {
                        item.Void = true;
                        item.LastUpdateUserId = viewModel.LastUpdateUserId;
                        item.LastUpdateUTCTime = viewModel.LastUpdateUTCTime;
                    }
                }

                News_Body news_Body = (await db.News_Body.Where(w => w.Header_Id == viewModel.Id).ToListAsync())
                    .Take(1).SingleOrDefault();

                if (news_Body == null)
                {
                    news_Body = new News_Body();
                    news_Body.Content = HttpUtility.HtmlDecode(viewModel.Content);
                    news_Body.Void = false;
                    news_Body.Header_Id = viewModel.Id;
                    news_Body.Version = 1;
                    news_Body.LastUpdateUserId = news_Body.CreateUserId = viewModel.LastUpdateUserId;
                    news_Body.LastUpdateUTCTime = news_Body.CreateUTCTime = viewModel.LastUpdateUTCTime;
                    news_Header.News_Body.Add(news_Body);
                    await db.SaveChangesAsync();
                    viewModel.Body_Id = news_Body.Id;
                }
                else
                {
                    //news_Body.Void = true;
                    //news_Body.LastUpdateUserId = viewModel.LastUpdateUserId;
                    //news_Body.LastUpdateUTCTime = viewModel.LastUpdateUTCTime;

                    //db.Entry(news_Body).State = EntityState.Modified;



                    var newversion_body = new News_Body();
                    newversion_body.Content = HttpUtility.HtmlDecode(viewModel.Content);
                    newversion_body.Void = false;
                    newversion_body.Header_Id = viewModel.Id;
                    newversion_body.Version = viewModel.Version + 1;
                    newversion_body.LastUpdateUserId = newversion_body.CreateUserId = viewModel.LastUpdateUserId;
                    newversion_body.LastUpdateUTCTime = newversion_body.CreateUTCTime = viewModel.LastUpdateUTCTime;

                    //newversion_body = db.News_Body.Add(newversion_body);
                    news_Header.News_Body.Add(newversion_body);
                    await db.SaveChangesAsync();
                    viewModel.Body_Id = newversion_body.Id;
                }
            }


            return RedirectToAction("Index");
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
            NewsPostViewModel viewModel = new NewsPostViewModel(news_Header);
            return View(viewModel);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            News_Header news_Header = await db.News_Header.FindAsync(id);
            news_Header.Void = true;
            news_Header.LastUpdateUserId = User.Identity.GetUserId<int>();
            news_Header.LastUpdateUTCTime = DateTime.Now.ToUniversalTime();

            foreach (var item in news_Header.News_Body.Where(w => w.Void == false))
            {
                item.Void = true;
                item.LastUpdateUserId = news_Header.LastUpdateUserId;
                item.LastUpdateUTCTime = news_Header.LastUpdateUTCTime;
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
