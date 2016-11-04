using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{
    public partial class ParkingLotsDetailRepository : EFRepository<ParkingLotsDetail>, IParkingLotsDetailRepository
    {
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
                        NoneFloor = !area.ParkingLotsFloor.Any(),
                        剩餘停車格數 = s.CarLastGrid,
                        樓層名稱 = s.FloorName,
                        剩餘機車格數 = s.MotoLastGrid
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