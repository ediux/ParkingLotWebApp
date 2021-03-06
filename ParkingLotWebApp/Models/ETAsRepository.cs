using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.ObjectModel;

namespace ParkingLotWebApp.Models
{
    public partial class ETAsRepository : EFRepository<ETAs>, IETAsRepository
    {
        public SyncDataViewModel BatchSyncFormDevice(ApiController ctr, SyncDataViewModel syncdata)
        {
            ICarsRepository db_cars = RepositoryHelper.GetCarsRepository(UnitOfWork);
            ICarPurposeTypesRepository db_cartypes = RepositoryHelper.GetCarPurposeTypesRepository(UnitOfWork);
            IETAsRepository db_etc = RepositoryHelper.GetETAsRepository();

            if (ctr.ModelState.IsValid == false)
            {
                return syncdata;
            }

            foreach (var eTAs in syncdata.ETCBinding)
            {
                try
                {
                    if (eTAs.LastUploadTime != null)
                    {
                        ETAs dbeTAs = All().SingleOrDefault(w => w.Code.Equals(eTAs.ETCID, StringComparison.InvariantCultureIgnoreCase));

                        bool isNew = false; //旗標註明是否為新資料

                        if (dbeTAs == null)
                        {
                            //當etc tag無資料
                            //新增一筆ETC資料
                            dbeTAs = CreateETCData(ctr, eTAs);
                            isNew = true;
                        }

                        if (isNew)
                        {
                            //如果ETC是新增的
                            //尋找車號
                            var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                            if (found_car == null && string.IsNullOrEmpty(eTAs.CarID) == false)
                            {
                                found_car = CreateCarRefData(ctr, db_cars, eTAs);
                                dbeTAs.Cars = found_car;
                                dbeTAs.CarRefId = found_car.Id;
                            }


                            dbeTAs.LastUpdateUTCTime = DateTime.Now;

                            Add(dbeTAs);
                        }
                        else
                        {
                            //資料庫已經有此Tag資料
                            //已經有對應車輛
                            if (dbeTAs.CarRefId != null && dbeTAs.CarRefId.HasValue)
                            {
                                if (eTAs.CarID != dbeTAs.Cars.CarNumber)
                                {
                                    //車號不一致
                                    var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                                    if (found_car == null)
                                    {
                                        //沒找到車號->新增
                                        found_car = CreateCarRefData(ctr, db_cars, eTAs);
                                    }

                                    dbeTAs.Cars = found_car;
                                    dbeTAs.CarRefId = found_car.Id;
                                    dbeTAs.LastUpdateUTCTime = DateTime.Now;

                                    UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                                }
                            }
                            else
                            {
                                //完全沒對應
                                var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                                if (found_car == null)
                                {
                                    //沒找到車號->新增
                                    found_car = CreateCarRefData(ctr, db_cars, eTAs);
                                }

                                dbeTAs.Cars = found_car;
                                dbeTAs.CarRefId = found_car.Id;
                                dbeTAs.LastUpdateUTCTime = DateTime.Now;

                                UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    continue;
                }
            }

            try
            {
                UnitOfWork.Commit();    //提交變更要求

                List<ETAs> result = db_etc.Where(w => w.Void == false).ToList();
                List<ETCBinding> converteddata = new List<ETCBinding>();
                if (result != null && result.Count > 0)
                {
                    foreach(ETAs d in result)
                    {
                        ETCBinding ndata = new ETCBinding();
                        if (d == null)
                            continue;

                        ndata.ETCID = d.Code;
                        ndata.CreateTime = d.CreateUTCTime;
                        ndata.LastUpdateTiem = d.LastUpdateUTCTime;
                        ndata.LastUploadTime = d.LastUpdateUTCTime;

                        if (d.Cars != null)
                        {
                            ndata.CarID = d.Cars.CarNumber;
                            ndata.CarPurposeTypeID = d.Cars.CarPurposeTypeID;

                        }

                        converteddata.Add(ndata);
                    }
                }
                syncdata.ETCBinding = converteddata;
                syncdata.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }




            return syncdata;
        }

        private static Cars CreateCarRefData(ApiController ctr, ICarsRepository db_cars, ETCBinding eTAs)
        {
            //沒找到車號->新增
            Cars found_car = new Models.Cars();
            found_car.CarNumber = eTAs.CarID;
            found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
            found_car.CarType = "C";
            found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
            found_car.CreateUTCTime = DateTime.Now;
            found_car.LastUpdateUTCTime = eTAs.LastUploadTime ?? eTAs.CreateTime;
            found_car.EmpId = null;
            eTAs.LastUpdateTiem = DateTime.Now;
            db_cars.Add(found_car);
            db_cars.UnitOfWork.Commit();    //先commit一次
            found_car = db_cars.Reload(found_car);  //重新讀取
            return found_car;
        }

        private static ETAs CreateETCData(ApiController ctr, ETCBinding eTAs)
        {
            ETAs dbeTAs = new ETAs();
            dbeTAs.Code = eTAs.ETCID;
            dbeTAs.LastUpdateUserId = dbeTAs.CreateUserId = ctr.User.Identity.GetUserId<int>();
            dbeTAs.CreateUTCTime = eTAs.CreateTime;
            dbeTAs.LastUpdateUTCTime = eTAs.LastUploadTime;
            eTAs.LastUpdateTiem = DateTime.Now;
            return dbeTAs;
        }

        public ETCBinding SyncFromDevice(ApiController ctr, string id, ETCBinding eTAs)
        {
            ICarsRepository db_cars = RepositoryHelper.GetCarsRepository(UnitOfWork);
            ICarPurposeTypesRepository db_cartypes = RepositoryHelper.GetCarPurposeTypesRepository(UnitOfWork);

            if (id != eTAs.ETCID)
            {
                throw new Exception("Not Match!");
            }

            ETAs dbeTAs = All().SingleOrDefault(w => w.Code.Equals(eTAs.ETCID, StringComparison.InvariantCultureIgnoreCase));

            bool isNew = false; //旗標註明是否為新資料

            if (dbeTAs == null)
            {
                //當etc tag無資料
                //新增一筆ETC資料
                dbeTAs = CreateETCData(ctr, eTAs);
                isNew = true;
            }

            if (isNew)
            {
                //如果ETC是新增的
                //尋找車號
                var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                if (found_car == null)
                {
                    //沒找到車號->新增
                    found_car = new Models.Cars();
                    found_car.CarNumber = eTAs.CarID;
                    found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                    found_car.CarType = "C";
                    found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                    found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                    found_car.EmpId = null;

                    db_cars.Add(found_car);
                    db_cars.UnitOfWork.Commit();    //先commit一次
                    found_car = db_cars.Reload(found_car);  //重新讀取
                }

                dbeTAs.Cars = found_car;
                dbeTAs.CarRefId = found_car.Id;
                dbeTAs.LastUpdateUTCTime = DateTime.Now;

                Add(dbeTAs);
            }
            else
            {
                //資料庫已經有此Tag資料
                //已經有對應車輛
                if (dbeTAs.CarRefId != null && dbeTAs.CarRefId.HasValue)
                {
                    if (eTAs.CarID != dbeTAs.Cars.CarNumber)
                    {
                        //車號不一致
                        var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                        if (found_car == null)
                        {
                            //沒找到車號->新增
                            found_car = new Models.Cars();
                            found_car.CarNumber = eTAs.CarID;
                            found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                            found_car.CarType = "C";
                            found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                            found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                            found_car.EmpId = null;

                            db_cars.Add(found_car);
                            db_cars.UnitOfWork.Commit();    //先commit一次
                            found_car = db_cars.Reload(found_car);  //重新讀取
                        }

                        dbeTAs.Cars = found_car;
                        dbeTAs.CarRefId = found_car.Id;
                        dbeTAs.LastUpdateUTCTime = DateTime.Now;

                        UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                    }
                }
                else
                {
                    //完全沒對應
                    var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                    if (found_car == null)
                    {
                        //沒找到車號->新增
                        found_car = new Models.Cars();
                        found_car.CarNumber = eTAs.CarID;
                        found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                        found_car.CarType = "C";
                        found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                        found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                        found_car.EmpId = null;

                        db_cars.Add(found_car);
                        db_cars.UnitOfWork.Commit();    //先commit一次
                        found_car = db_cars.Reload(found_car);  //重新讀取
                    }

                    dbeTAs.Cars = found_car;
                    dbeTAs.CarRefId = found_car.Id;
                    dbeTAs.LastUpdateUTCTime = DateTime.Now;

                    UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                }
            }


            try
            {
                UnitOfWork.Commit();    //提交變更要求
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            try
            {
                eTAs = new ETCBinding()
                {
                    CarID = dbeTAs.Cars.CarNumber,
                    ETCID = dbeTAs.Code,
                    CarPurposeTypeID = dbeTAs.Cars.CarPurposeTypeID
                };
            }
            catch
            {
                throw;
            }

            return eTAs;
        }

    }

    public partial interface IETAsRepository : IRepositoryBase<ETAs>
    {
        ETCBinding SyncFromDevice(ApiController ctr, string id, ETCBinding eTAs);
        SyncDataViewModel BatchSyncFormDevice(ApiController ctr, SyncDataViewModel syncdata);
    }
}