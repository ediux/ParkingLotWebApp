using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ParkingLotWebApp.Models
{
    public partial class ParkingLotsFloorRepository : EFRepository<ParkingLotsFloor>, IParkingLotsFloorRepository
    {
        private IParkingLotsFloorLEDRepository ledRepo;
        private IAlterFloorLogRepository logRepo;

        public ParkingLotsFloorRepository()
        {
            ledRepo = RepositoryHelper.GetParkingLotsFloorLEDRepository(UnitOfWork);
            logRepo = RepositoryHelper.GetAlterFloorLogRepository(UnitOfWork);
        }

        public ParkingLotsFloor Update(ParkingLotsFloor entity)
        {
            try
            {
                AlterFloorLog logData = new AlterFloorLog();
                logData.AlterTime = DateTime.Now;
                logData.EmployeeID = 0;
                if (System.Web.HttpContext.Current != null)
                {
                    logData.EmployeeID = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();
                }

                if (entity != null)
                {
                    ParkingLotsFloor data = Get(entity.ID);


                    if (data != null)
                    {
                        logData.OldValue = data.CarLastGrid;
                      

                        data.CarLastGrid = entity.CarLastGrid;
                        data.MotoLastGrid = entity.MotoLastGrid;
                        data.LastUpdate = DateTime.Now;

                        ledRepo.UnitOfWork = UnitOfWork;

                        ParkingLotsFloorLED ledData = ledRepo.Get(data.ID);

                        if (ledData != null)
                        {
                            //一併修改Led紀錄表
                            ledData.CarLastGrid = entity.CarLastGrid;
                            ledData.MotoLastGrid = entity.MotoLastGrid;
                            ledData.LastUpdate = DateTime.Now;

                            ledRepo.UnitOfWork.Context.Entry(ledData).State = System.Data.Entity.EntityState.Modified;

                            //增加一筆Log紀錄
                            logData.NewValue = entity.CarLastGrid;
                            logData.ParkingLotsFloorID = data.ID;                    
                            logRepo.UnitOfWork = this.UnitOfWork;

                            logRepo.Add(logData);
                        }

                        UnitOfWork.Context.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        UnitOfWork.Commit();

                        return Reload(data);
                    }
                }

                return entity;
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw ex;
            }

        }
    }

    public partial interface IParkingLotsFloorRepository : IRepositoryBase<ParkingLotsFloor>
    {
        ParkingLotsFloor Update(ParkingLotsFloor entity);
    }
}