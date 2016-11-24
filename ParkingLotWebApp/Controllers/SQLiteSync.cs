using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ParkingLotWebApp.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNet.Identity;

namespace ParkingLotWebApp.Controllers
{
    [Filters.ElmahError]
    public class SQLiteSyncController : ApiController
    {
        private IETAsRepository db;
        private ICarsRepository db_cars;
        private ICarPurposeTypesRepository db_cartypes;

        public SQLiteSyncController()
        {
            db = RepositoryHelper.GetETAsRepository();
            db_cars = RepositoryHelper.GetCarsRepository(db.UnitOfWork);
            db_cartypes = RepositoryHelper.GetCarPurposeTypesRepository(db.UnitOfWork);
        }

        // GET: api/SQLiteSync
        public IHttpActionResult GetETAs()
        {
            var model = new SyncDataViewModel();

            var etcsyncdata = from q in db.All()
                              select new ETCBinding()
                              {
                                  CarID = q.Cars.CarNumber,
                                  CarPurposeTypeID = q.Cars.CarPurposeTypeID ?? 0,
                                  ETCID = q.Code,
                                  CreateTime = q.CreateUTCTime,
                                  LastUpdateTiem = q.LastUpdateUTCTime
                              };

            model.ETCBinding = new Collection<ETCBinding>(etcsyncdata.ToList());
            model.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());

            return Ok(model);
        }

        // GET: api/SQLiteSync/5
        [ResponseType(typeof(SyncDataViewModel))]
        public IHttpActionResult GetETAs(string id)
        {
            ETAs eTAs = db.All().SingleOrDefault(s => s.Code == id);

            SyncDataViewModel model =
                new Models.SyncDataViewModel();

            if (eTAs != null)
            {
                ETCBinding bindingdata = new ETCBinding() { ETCID = eTAs.Code,
                    CreateTime = eTAs.CreateUTCTime,
                    LastUpdateTiem = eTAs.LastUpdateUTCTime
                };

                if (eTAs.CarRefId != null)
                {
                    bindingdata.CarID = eTAs.Cars.CarNumber;
                    bindingdata.CarPurposeTypeID = eTAs.Cars.CarPurposeTypeID;
                }


                model.ETCBinding.Add(bindingdata);
            }


            model.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());

            if (eTAs == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/SQLiteSync/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutETAs(string id, ETCBinding eTAs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eTAs.ETCID)
            {
                return BadRequest();
            }

            eTAs = db.SyncFromDevice(this, id, eTAs);

            try
            {
                db.UnitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ETAsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SQLiteSync
        [ResponseType(typeof(SyncDataViewModel))]
        public IHttpActionResult PostETAs(SyncDataViewModel eTAs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            eTAs = db.BatchSyncFormDevice(this, eTAs);

            return Ok(eTAs);
        }

        // DELETE: api/SQLiteSync/5
        [ResponseType(typeof(SyncDataViewModel))]
        public IHttpActionResult DeleteETAs(int id)
        {
            ETAs eTAs = db.Get(id);
            if (eTAs == null)
            {
                return NotFound();
            }

            db.Delete(eTAs);
            db.UnitOfWork.Commit();

            return Ok(eTAs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ETAsExists(string id)
        {
            return db.All().Count(e => e.Code == id) > 0;
        }
    }
}