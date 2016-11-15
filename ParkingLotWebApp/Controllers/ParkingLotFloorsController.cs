using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ParkingLotWebApp.Models;
using Microsoft.AspNet.Identity;
using System;

namespace ParkingLotWebApp.Controllers
{
    public class ParkingLotsFloorController : Controller
    {
        private IParkingLotsFloorRepository db = RepositoryHelper.GetParkingLotsFloorRepository();
        private IParkingLotsDetailRepository db_area = RepositoryHelper.GetParkingLotsDetailRepository();

        public ParkingLotsFloorController()
        {
            db_area.UnitOfWork = db.UnitOfWork;
        }

        // GET: ParkingLotsFloor
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.AreaId = id.Value;
                ViewBag.AreaName = db_area.Get(id.Value).Name;
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotAreas", new { id = id.Value });
                var ParkingLotsFloorByFiliter = db.Where(w => w.ParkingLotsID == id && w.Void == false).Include(p => p.ParkingLotsDetail);
                return View(ParkingLotsFloorByFiliter.ToList());
            }
            var ParkingLotsFloor = db.Where(w => w.Void == false).Include(p => p.ParkingLotsDetail);
            return View(ParkingLotsFloor.ToList());
        }

        // GET: ParkingLotsFloor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotsFloor ParkingLotsFloor = db.Get(id);
            if (ParkingLotsFloor == null)
            {
                return HttpNotFound();
            }
            return View(ParkingLotsFloor);
        }

        // GET: ParkingLotsFloor/Create
        public ActionResult Create(int? id)
        {
            var viewmodel = ParkingLotsFloor.Create();
            if (id != null && id.HasValue)
            {
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotsFloor", new { id = id.Value });
                ViewBag.ParkingLotsID = new SelectList(db_area.Where(w => w.ID == id.Value && w.Void == false), "ID", "Name");
                viewmodel.ParkingLotsID = id.Value;
                viewmodel.ParkingLotsDetail = db_area.Get(id.Value);
            }
            else
            {
                ViewBag.ParkingLotsID = new SelectList(db_area.Where(w => w.Void == false), "ID", "Name");

            }

            return View(viewmodel);
        }

        // POST: ParkingLotsFloor/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = @"ID,ParkingLotsID,FloorOrder,FloorName,CarTotalGrid
      ,CarLastGrid,MotoTotalGrid,MotoLastGrid,Void,LastUpdate")] ParkingLotsFloor ParkingLotsFloor)
        {
            if (ModelState.IsValid)
            {
                var parkingdetail = db_area.Get(ParkingLotsFloor.ParkingLotsID);
                ParkingLotsFloor.ParkingLotsID = parkingdetail.ID;
                ParkingLotsFloor.ParkingLotsDetail = parkingdetail;

                db.Add(ParkingLotsFloor);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index", new { id = ParkingLotsFloor.ParkingLotsID });
            }
            if (ParkingLotsFloor.ParkingLotsID != 0)
            {
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotsFloor", new { id = ParkingLotsFloor.ParkingLotsID });
                ViewBag.ParkingLotsID = new SelectList(db_area.Where(w => w.ID == ParkingLotsFloor.ParkingLotsID && w.Void == false), "Id", "Name");
            }
            else
            {
                ViewBag.ParkingLotsID = new SelectList(db_area.Where(w => w.Void == false), "ID", "Name");
            }
            return View(ParkingLotsFloor);
        }

        // GET: ParkingLotsFloor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotsFloor ParkingLotsFloor = db.Get(id);
            if (ParkingLotsFloor == null)
            {
                return HttpNotFound();
            }            
            ViewBag.ParkingLotsDetail = new SelectList(db_area.Where(w => w.Void == false), "ID", "Name", ParkingLotsFloor.ParkingLotsID);
            return View(ParkingLotsFloor);
        }

        // POST: ParkingLotsFloor/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"ID,ParkingLotsID,FloorOrder,FloorName,CarTotalGrid
      ,CarLastGrid,MotoTotalGrid,MotoLastGrid,Void,LastUpdate")] ParkingLotsFloor ParkingLotsFloor)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfWork.Context.Entry(ParkingLotsFloor).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ParkingLotsID = new SelectList(db_area.Where(w => w.Void == false), "ID", "Name", ParkingLotsFloor.ParkingLotsID);
            return View(ParkingLotsFloor);
        }

        // GET: ParkingLotsFloor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotsFloor ParkingLotsFloor = db.Get(id);
            if (ParkingLotsFloor == null)
            {
                return HttpNotFound();
            }
            return View(ParkingLotsFloor);
        }

        // POST: ParkingLotsFloor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingLotsFloor ParkingLotsFloor = db.Get(id);
            db.Delete(ParkingLotsFloor);
            db.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult ListRemainParkingGridAmounts()
        {
            var model = db_area.GetListRemainParkingGridAmounts();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListRemainParkingGridAmounts(FormCollection collection)
        {
            string selects = collection["areaId"];
            int[] sId = new int[] { };

            if (!string.IsNullOrEmpty(selects))
            {
                sId = selects.Split(',').ToList().ConvertAll(c => int.Parse(c)).ToArray();
            }

            var model = db_area.GetListRemainParkingGridAmounts();

            foreach (var selected in sId)
            {
                model.SelectedAreas[selected] = true;
            }

            return View(model);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult EditRemainParkingGridAmounts([Bind(Include = "ID,CarLastGrid,MotoLastGrid")]ParkingLotsFloor ParkingLotsFloor)
        {
            if (ParkingLotsFloor != null)
            {
                ParkingLotsFloor data = db.Get(ParkingLotsFloor.ID);
                if (data != null)
                {
                    data.CarLastGrid = ParkingLotsFloor.CarLastGrid;
                    data.MotoLastGrid = ParkingLotsFloor.MotoLastGrid;
                    data.LastUpdate = DateTime.Now;
                    db.UnitOfWork.Commit();
                    db.UnitOfWork.Context.Entry(data).Reload();
                    return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { Success = true, Data = data }), "application/json");
                }
            }
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { Success = false, Data = ParkingLotsFloor }), "application/json");
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
