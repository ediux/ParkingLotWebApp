using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ParkingLotWebApp.Models;

namespace ParkingLotWebApp.Controllers
{
    public class ParkingLotFloorsController : Controller
    {
        private IParkingLotFloorsRepository db = RepositoryHelper.GetParkingLotFloorsRepository();
        private IParkingLotAreasRepository db_area = RepositoryHelper.GetParkingLotAreasRepository();

        public ParkingLotFloorsController()
        {
            db_area.UnitOfWork = db.UnitOfWork;
        }

        // GET: ParkingLotFloors
        public ActionResult Index(int? id)
        {

           
            if (id.HasValue)
            {
                ViewBag.AreaId = id.Value;
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotAreas", new { id = id.Value });
                var parkingLotFloorsByFiliter = db.Where(w => w.AreaId == id && w.Void == false).Include(p => p.ParkingLotAreas);
                return View(parkingLotFloorsByFiliter.ToList());
            }
            var parkingLotFloors = db.Where(w => w.Void == false).Include(p => p.ParkingLotAreas);
            return View(parkingLotFloors.ToList());
        }

        // GET: ParkingLotFloors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.Get(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Create
        public ActionResult Create(int? id)
        {

            if (id != null && id.HasValue)
            {
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotFloors", new { id = id.Value });
                ViewBag.AreaId = new SelectList(db.Where(w => w.Id == id.Value && w.Void == false), "Id", "Name");
            }
            else
            {
                ViewBag.AreaId = new SelectList(db.Where(w => w.Void == false), "Id", "Name");

            }

            return View(new ParkingLotFloors());
        }

        // POST: ParkingLotFloors/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaId,Name,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime,GridAmout,GridRemainAmount")] ParkingLotFloors parkingLotFloors)
        {
            if (ModelState.IsValid)
            {
                db.Add(parkingLotFloors);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index", new { id = parkingLotFloors.AreaId });
            }
            if (parkingLotFloors.AreaId != null && parkingLotFloors.AreaId.HasValue)
            {
                ViewBag.returnUrl = Url.Action("Index", "ParkingLotFloors", new { id = parkingLotFloors.AreaId.HasValue });
                ViewBag.AreaId = new SelectList(db.Where(w => w.Id == parkingLotFloors.AreaId.Value && w.Void == false), "Id", "Name");
            }
            else
            {
                ViewBag.AreaId = new SelectList(db.Where(w => w.Void == false), "Id", "Name");
            }
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.Get(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Where(w => w.Void == false), "Id", "Name", parkingLotFloors.AreaId);
            return View(parkingLotFloors);
        }

        // POST: ParkingLotFloors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaId,Name,Void,CreateUserId,CreateUTCTime,LastUserId,LastUpdateUtcTime,GridAmout,GridRemainAmount")] ParkingLotFloors parkingLotFloors)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfWork.Context.Entry(parkingLotFloors).State = EntityState.Modified;
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db_area.Where(w=>w.Void==false), "Id", "Name", parkingLotFloors.AreaId);
            return View(parkingLotFloors);
        }

        // GET: ParkingLotFloors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLotFloors parkingLotFloors = db.Get(id);
            if (parkingLotFloors == null)
            {
                return HttpNotFound();
            }
            return View(parkingLotFloors);
        }

        // POST: ParkingLotFloors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingLotFloors parkingLotFloors = db.Get(id);
            db.Delete(parkingLotFloors);
            db.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult ListRemainParkingGridAmounts()
        {
            var model = db.GetListRemainParkingGridAmounts();
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

            var model = db.GetListRemainParkingGridAmounts();

            foreach(var selected in sId)
            {
                model.SelectedAreas[selected] = true;
            }
           
            return View(model);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult EditRemainParkingGridAmounts([Bind(Include = "AreaId,Name,GridAmout,GridRemainAmount")]ParkingLotFloors parkinglotFloors)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
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
