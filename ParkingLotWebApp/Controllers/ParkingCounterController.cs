using ParkingLotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingLotWebApp.Controllers
{
    public class ParkingCounterController : ApiController
    {
        private Models.IParkingLotsDetailRepository parkingDetailsRepo;
        private Models.IParkingLotsFloorRepository parkingFloorRepo;

        public ParkingCounterController()
        {
            parkingDetailsRepo = Models.RepositoryHelper.GetParkingLotsDetailRepository();
            parkingFloorRepo = Models.RepositoryHelper.GetParkingLotsFloorRepository(parkingDetailsRepo.UnitOfWork);
        }
        // GET: api/ParkingCounter
        public IHttpActionResult Get()
        {
            try
            {
                List<Counter_ParkingDetail> model = new List<Models.Counter_ParkingDetail>();

                var details = parkingDetailsRepo.Where(w => w.Void == false);

                if (details != null)
                {
                    if (details.Count() > 0)
                    {
                        foreach (var detailitem in details)
                        {
                            if (detailitem.ParkingLotsFloor != null)
                            {
                                foreach (var item in detailitem.ParkingLotsFloor.OrderBy(o => o.FloorOrder))
                                {
                                    Counter_ParkingDetail area = new Counter_ParkingDetail();
                                    area.Id = item.ID;
                                    area.Name = string.Format("{0}-{1}", detailitem.Name, item.FloorName);
                                    area.RFIDCount = item.CarLastGridRFID;
                                    area.Total = item.CarTotalGrid;
                                    area.Count = item.CarLastGrid;
                                    model.Add(area);
                                }
                            }
                        }
                    }
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return InternalServerError(ex);
            }
        }

        // GET: api/ParkingCounter/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var floor = parkingFloorRepo.Get(id);

                if (floor != null)
                {
                    Counter_ParkingDetail model = new Counter_ParkingDetail();
                    model.Id = model.Id;
                    model.Name  = string.Format("{0}-{1}", floor.ParkingLotsDetail.Name , floor.FloorName);
                    model.Total = floor.CarTotalGrid;
                    model.Count = floor.CarLastGrid;
                    model.RFIDCount = floor.CarLastGridRFID;
                   
                    return Ok(model);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return InternalServerError(ex);
            }
        }

        // POST: api/ParkingCounter
        public void Post([FromBody]Counter_ParkingDetail value)
        {
            try
            {
                var floor = parkingFloorRepo.Get(value.Id);

                if (floor != null)
                {
                    floor.CarLastGrid = value.Count;
                    floor.CarLastGridRFID = value.RFIDCount;
                    parkingDetailsRepo.UnitOfWork.Context.Entry(floor).State = System.Data.Entity.EntityState.Modified;
                    parkingDetailsRepo.UnitOfWork.Commit();  
                }

            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex); 
            }
        }

        // PUT: api/ParkingCounter/5
        public void Put(int id)
        {
            try
            {
                var floor = parkingFloorRepo.Get(id);

                if (floor != null)
                {
                    floor.CarLastGrid+=1;
                
                    parkingDetailsRepo.UnitOfWork.Context.Entry(floor).State = System.Data.Entity.EntityState.Modified;
                    parkingDetailsRepo.UnitOfWork.Commit();

               
                }

               
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }
        }

        // DELETE: api/ParkingCounter/5
        public void Delete(int id)
        {
            try
            {
                var floor = parkingFloorRepo.Get(id);

                if (floor != null)
                {
                    floor.CarLastGrid -= 1;

                    parkingDetailsRepo.UnitOfWork.Context.Entry(floor).State = System.Data.Entity.EntityState.Modified;
                    parkingDetailsRepo.UnitOfWork.Commit();


                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex); 
            }
        }
    }
}
