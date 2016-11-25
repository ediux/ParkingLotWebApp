﻿using ParkingLotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingLotWebApp.Controllers
{
    public class HomeController : BaseController
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

            var model = db.GetListRemainParkingGridAmounts();
            ViewBag.AreaId = string.Join(",", model.SelectedAreas.Keys.Select(s => s.ToString()).ToArray());
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

            var model = db.GetListRemainParkingGridAmounts();
ViewBag.AreaId = selects;
            int[] keys = model.SelectedAreas.Keys.ToArray();

            foreach (var selected in keys)
            {
                model.SelectedAreas[selected] = false;
                if (sId.Contains(selected))
                    model.SelectedAreas[selected] = true;
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

            int[] keys = model.SelectedAreas.Keys.ToArray();

            foreach (var selected in keys)
            {
                model.SelectedAreas[selected] = false;
            }


            foreach (var selected in keys)
            {
                if (sId.Contains(selected))
                    model.SelectedAreas[selected] = true;
            }



            return View(model);
        }
#if DEBUG
        public ActionResult Theme()
        {

            return View();
        }
#endif
    }
}