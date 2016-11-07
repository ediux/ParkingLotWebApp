﻿using ParkingLotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingLotWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IParkingLotsDetailRepository db;
        private IParkingLotsFloorRepository db_floor;

        public HomeController()
        {
            db = RepositoryHelper.GetParkingLotsDetailRepository();
            db_floor = RepositoryHelper.GetParkingLotsFloorRepository(db.UnitOfWork);
        }

        public ActionResult Index()
        {
            ViewBag.AreaId = "";
            var model = db.GetListRemainParkingGridAmounts();
            return View(model);
        }

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            string selects = collection["areaId"];
            ViewBag.AreaId = selects;
            int[] sId = new int[] { };

            if (!string.IsNullOrEmpty(selects))
            {
                sId = selects.Split(',').ToList().ConvertAll(c => int.Parse(c)).ToArray();
            }

            var model = db.GetListRemainParkingGridAmounts();

            foreach (var key in sId)
            {
                model.SelectedAreas[key] = true;
            }

            return View(model);
        }

        [OutputCache(VaryByParam = "*", Duration = 0, NoStore = true)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reload(FormCollection collection)
        {
            string selects = collection["shared_areaId"];
            int[] sId = new int[] { };

            if (!string.IsNullOrEmpty(selects))
            {
                sId = selects.Split(',').ToList().ConvertAll(c => int.Parse(c)).ToArray();
            }

            var model = db.GetListRemainParkingGridAmounts();

            foreach (var key in sId)
            {
                model.SelectedAreas[key] = true;
            }

            return View(model);
        }

        public ActionResult Theme()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}