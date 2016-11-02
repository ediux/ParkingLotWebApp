using ParkingLotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingLotWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IParkingLotAreasRepository db;
        private IParkingLotFloorsRepository db_floor;

        public HomeController()
        {
            db = RepositoryHelper.GetParkingLotAreasRepository();
            db_floor = RepositoryHelper.GetParkingLotFloorsRepository(db.UnitOfWork);
        }

        public ActionResult Index()
        {
            var model = db_floor.GetListRemainParkingGridAmounts();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            string selects = collection["areaId"];
            int[] sId = new int[] { };

            if (!string.IsNullOrEmpty(selects))
            {
                sId = selects.Split(',').ToList().ConvertAll(c => int.Parse(c)).ToArray();
            }

            var model = db_floor.GetListRemainParkingGridAmounts();

            foreach (var key in sId)
            {
                model.SelectedAreas[key] = true;
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}