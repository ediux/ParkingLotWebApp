using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class ParkingLotsDetailRepository
    {
        public override IQueryable<ParkingLotsDetail> All()
        {
            return base.All().Where(w=>w.Void==false);
        }
        public override ParkingLotsDetail Add(ParkingLotsDetail entity)
        {
            ParkingLotsDetail entityInDatabase = ObjectSet.SingleOrDefault(s => s.Name.Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));
            if (entityInDatabase != null)
            {
                //如果資料庫已經有相同名稱的資料則複寫原本的資料                
                entityInDatabase.ParkingLotsFloor.Clear();//移除原相同名稱的關聯資料
                entityInDatabase.Address = entity.Address;
                entityInDatabase.Charge = entity.Charge;
                entityInDatabase.LastUpdate = DateTime.Now;
                entityInDatabase.Latitude = entity.Latitude;
                entityInDatabase.Longitude = entity.Longitude;
                entityInDatabase.Name = entity.Name;
                entityInDatabase.Period = entity.Period;
                entityInDatabase.Tel = entity.Tel;
                entityInDatabase.Void = false;
                UnitOfWork.Context.Entry(entityInDatabase).State = System.Data.Entity.EntityState.Modified;
                return entityInDatabase;
            }
            return base.Add(entity);
        }
        public override void Delete(ParkingLotsDetail entity)
        {
            if (entity.Void == false)
            {
                entity.Void = true;
            }            
        }
        public HomeIndexViewModel GetListRemainParkingGridAmounts()
        {
            HomeIndexViewModel result = new Models.HomeIndexViewModel();

            var areadatas = All().Select(s => new { s.Name, s.ID }).Distinct()
                .ToDictionary(k => k.ID, v => v.Name);

            foreach (var k in areadatas.Keys)
            {
                var area = Get(k);
                result.RemainSummary.Add(k, area.ParkingLotsFloor
                    .Select(s =>
                    new vw_ParkingLotGridRemain()
                    {
                        FloorOrder = s.FloorOrder,
                        NoneFloor = (s.FloorName == areadatas[k]),
                        剩餘停車格數 = s.CarLastGrid,
                        樓層名稱 = s.FloorName,
                        剩餘機車格數 = s.MotoLastGrid,
                        總停車格數 = s.CarTotalGrid,
                        總機車格數 = s.MotoTotalGrid,
                        ID = s.ID
                    }).ToList());
                result.Areas.Add(k, areadatas[k]);
                result.SelectedAreas.Add(k, false);
            }


            return result;
        }
    }

    public partial interface IParkingLotsDetailRepository : IRepositoryBase<ParkingLotsDetail>
    {
        HomeIndexViewModel GetListRemainParkingGridAmounts();
    }
}