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
        private ParkingLotModelEntities db = new ParkingLotModelEntities();

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.RemainSummary = new Dictionary<string, IEnumerable<vw_ParkingLotGridRemain>>();

            var result = db.vw_ParkingLotGridRemain;
            var keys = result.Select(d => new { d.Id, d.Name }).Distinct().ToList();

            foreach (var key in keys)
            {
                model.RemainSummary.Add(key.Name, result.Where(w => w.Id == key.Id).ToList());
            }

            ViewBag.Selected = new int[] { };
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
              
            var model = new HomeIndexViewModel();

            model.RemainSummary = new Dictionary<string, IEnumerable<vw_ParkingLotGridRemain>>();

            var result = db.vw_ParkingLotGridRemain;
            var keys = result.Select(d => new { d.Id, d.Name }).Distinct().ToList();

            foreach (var key in keys)
            {
                model.RemainSummary.Add(key.Name, result.Where(w => w.Id == key.Id).ToList());
            }

            ViewBag.Selected = sId;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}