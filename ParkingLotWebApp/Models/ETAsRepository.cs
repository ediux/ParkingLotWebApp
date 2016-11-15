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

            if (ctr.ModelState.IsValid == false)
            {
                return syncdata;
            }

            foreach (var eTAs in syncdata.ETCBinding)
            {
                try
                {
                    ETAs dbeTAs = All().SingleOrDefault(w => w.Code.Equals(eTAs.ETCID, StringComparison.InvariantCultureIgnoreCase));

                    bool isNew = false; //�X�е����O�_���s���

                    if (dbeTAs == null)
                    {
                        //��etc tag�L���
                        //�s�W�@��ETC���
                        dbeTAs = CreateETCData(ctr, eTAs);
                        isNew = true;
                    }

                    if (isNew)
                    {
                        //�p�GETC�O�s�W��
                        //�M�䨮��
                        var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                        if (found_car == null)
                        {
                            found_car = CreateCarRefData(ctr, db_cars, eTAs);
                        }

                        dbeTAs.Cars = found_car;
                        dbeTAs.CarRefId = found_car.Id;
                        dbeTAs.LastUpdateUTCTime = DateTime.Now;

                        Add(dbeTAs);
                    }
                    //else
                    //{
                    //    //��Ʈw�w�g����Tag���
                    //    //�w�g����������
                    //    if (dbeTAs.CarRefId != null && dbeTAs.CarRefId.HasValue)
                    //    {
                    //        if (eTAs.CarID != dbeTAs.Cars.CarNumber)
                    //        {
                    //            //�������@�P
                    //            var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                    //            if (found_car == null)
                    //            {
                    //                //�S��쨮��->�s�W
                    //                found_car = CreateCarRefData(ctr, db_cars, eTAs);                                   
                    //            }

                    //            dbeTAs.Cars = found_car;
                    //            dbeTAs.CarRefId = found_car.Id;
                    //            dbeTAs.LastUpdateUTCTime = DateTime.Now;

                    //            UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //�����S����
                    //        var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                    //        if (found_car == null)
                    //        {
                    //            //�S��쨮��->�s�W
                    //            found_car = CreateCarRefData(ctr, db_cars, eTAs);
                    //        }

                    //        dbeTAs.Cars = found_car;
                    //        dbeTAs.CarRefId = found_car.Id;
                    //        dbeTAs.LastUpdateUTCTime = DateTime.Now;

                    //        UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                    //    }
                    //}

                }
                catch (Exception)
                {
                    continue;
                }
            }

            try
            {
                UnitOfWork.Commit();    //�����ܧ�n�D
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            syncdata.CarPurposeTypes = new Collection<CarPurposeTypes>(db_cartypes.All().ToList());

            return syncdata;
        }

        private static Cars CreateCarRefData(ApiController ctr, ICarsRepository db_cars, ETCBinding eTAs)
        {
            //�S��쨮��->�s�W
            Cars found_car = new Models.Cars();
            found_car.CarNumber = eTAs.CarID;
            found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
            found_car.CarType = "C";
            found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
            found_car.CreateUTCTime = DateTime.Now;
            found_car.LastUpdateUTCTime = eTAs.LastUploadTime??eTAs.CreateTime;
            found_car.EmpId = null;
            eTAs.LastUpdateTiem = DateTime.Now;
            db_cars.Add(found_car);
            db_cars.UnitOfWork.Commit();    //��commit�@��
            found_car = db_cars.Reload(found_car);  //���sŪ��
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

            bool isNew = false; //�X�е����O�_���s���

            if (dbeTAs == null)
            {
                //��etc tag�L���
                //�s�W�@��ETC���
                dbeTAs = CreateETCData(ctr, eTAs);                
                isNew = true;
            }

            if (isNew)
            {
                //�p�GETC�O�s�W��
                //�M�䨮��
                var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                if (found_car == null)
                {
                    //�S��쨮��->�s�W
                    found_car = new Models.Cars();
                    found_car.CarNumber = eTAs.CarID;
                    found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                    found_car.CarType = "C";
                    found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                    found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                    found_car.EmpId = null;

                    db_cars.Add(found_car);
                    db_cars.UnitOfWork.Commit();    //��commit�@��
                    found_car = db_cars.Reload(found_car);  //���sŪ��
                }

                dbeTAs.Cars = found_car;
                dbeTAs.CarRefId = found_car.Id;
                dbeTAs.LastUpdateUTCTime = DateTime.Now;

                Add(dbeTAs);
            }
            else
            {
                //��Ʈw�w�g����Tag���
                //�w�g����������
                if (dbeTAs.CarRefId != null && dbeTAs.CarRefId.HasValue)
                {
                    if (eTAs.CarID != dbeTAs.Cars.CarNumber)
                    {
                        //�������@�P
                        var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                        if (found_car == null)
                        {
                            //�S��쨮��->�s�W
                            found_car = new Models.Cars();
                            found_car.CarNumber = eTAs.CarID;
                            found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                            found_car.CarType = "C";
                            found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                            found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                            found_car.EmpId = null;

                            db_cars.Add(found_car);
                            db_cars.UnitOfWork.Commit();    //��commit�@��
                            found_car = db_cars.Reload(found_car);  //���sŪ��
                        }

                        dbeTAs.Cars = found_car;
                        dbeTAs.CarRefId = found_car.Id;
                        dbeTAs.LastUpdateUTCTime = DateTime.Now;

                        UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                    }
                }
                else
                {
                    //�����S����
                    var found_car = db_cars.All().SingleOrDefault(s => s.CarNumber == eTAs.CarID && s.CarType == "C");

                    if (found_car == null)
                    {
                        //�S��쨮��->�s�W
                        found_car = new Models.Cars();
                        found_car.CarNumber = eTAs.CarID;
                        found_car.CarPurposeTypeID = eTAs.CarPurposeTypeID;
                        found_car.CarType = "C";
                        found_car.LastUpdateUserId = found_car.CreateUserId = ctr.User.Identity.GetUserId<int>();
                        found_car.LastUpdateUTCTime = found_car.CreateUTCTime = DateTime.Now;
                        found_car.EmpId = null;

                        db_cars.Add(found_car);
                        db_cars.UnitOfWork.Commit();    //��commit�@��
                        found_car = db_cars.Reload(found_car);  //���sŪ��
                    }

                    dbeTAs.Cars = found_car;
                    dbeTAs.CarRefId = found_car.Id;
                    dbeTAs.LastUpdateUTCTime = DateTime.Now;

                    UnitOfWork.Context.Entry(dbeTAs).State = EntityState.Modified;
                }
            }


            try
            {
                UnitOfWork.Commit();    //�����ܧ�n�D
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