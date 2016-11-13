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

namespace ParkingLotWebApp.Controllers
{
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
        public IQueryable<SyncDataViewModel> GetETAs()
        {
            var model = new SyncDataViewModel();

            var etcsyncdata = from q in db.All()
                              from s in q.Cars
                              select new ETCSQLiteViewModel()
                              {
                                  CarId = s.CarNumber,
                                  CarPurposeTypesId = s.CarPurposeTypeID ?? 0,
                                  TagCode = q.Code
                              };

            model.ETCBinding = new Collection<ETCSQLiteViewModel>(etcsyncdata.ToList());
            model.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());

            return model as IQueryable<SyncDataViewModel>;
        }

        // GET: api/SQLiteSync/5
        [ResponseType(typeof(SyncDataViewModel))]
        public IHttpActionResult GetETAs(string id)
        {
            ETAs eTAs = db.Get(id);
            SyncDataViewModel model =
                new Models.SyncDataViewModel();

            model.ETCBinding.Add(new ETCSQLiteViewModel() { CarId = eTAs.Cars.First().CarNumber, TagCode = eTAs.Code, CarPurposeTypesId = eTAs.Cars.First().CarPurposeTypeID ?? 0 });
            model.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());

            if (eTAs == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/SQLiteSync/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutETAs(int id, SyncDataViewModel eTAs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eTAs.Id)
            {
                return BadRequest();
            }

            db.Entry(eTAs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostETAs(ETAs eTAs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ETAs.Add(eTAs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eTAs.Id }, eTAs);
        }

        // DELETE: api/SQLiteSync/5
        [ResponseType(typeof(SyncDataViewModel))]
        public IHttpActionResult DeleteETAs(int id)
        {
            ETAs eTAs = db.ETAs.Find(id);
            if (eTAs == null)
            {
                return NotFound();
            }

            db.ETAs.Remove(eTAs);
            db.SaveChanges();

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

        private bool ETAsExists(int id)
        {
            return db.ETAs.Count(e => e.Id == id) > 0;
        }
    }
}