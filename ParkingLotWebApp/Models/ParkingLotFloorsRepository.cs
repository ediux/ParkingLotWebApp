using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{
    public partial class ParkingLotFloorsRepository : EFRepository<ParkingLotFloors>, IParkingLotFloorsRepository
    {
        private Ivw_ParkingLotGridRemainRepository _p_vw_parkingLotGridRemainRepository;
        public Ivw_ParkingLotGridRemainRepository vw_ParkingLotGridRemainRepository
        {
            get
            {
                if (_p_vw_parkingLotGridRemainRepository == null)
                {
                    _p_vw_parkingLotGridRemainRepository = RepositoryHelper.Getvw_ParkingLotGridRemainRepository();
                    _p_vw_parkingLotGridRemainRepository.UnitOfWork = UnitOfWork;
                }

                return _p_vw_parkingLotGridRemainRepository;
            }

            set
            {
                _p_vw_parkingLotGridRemainRepository = value;
                _p_vw_parkingLotGridRemainRepository.UnitOfWork = UnitOfWork;
            }
        }

        public HomeIndexViewModel GetListRemainParkingGridAmounts()
        {
            var model = new HomeIndexViewModel();

            var result = (from q in vw_ParkingLotGridRemainRepository.All()
                          where q.Void == false
                          select q).ToList();

            var keys = result.Select(s => s.Id).Distinct();

            foreach (var key in keys)
            {
                // result.Where(w => w.Id == key.Id).ToList()
                model.Areas.Add(key, result.First(w => w.Id == key).Name);
                model.RemainSummary.Add(key, result.Where(w => w.Id == key).ToList());
                model.SelectedAreas.Add(key, false);
            }

            return model;
        }
    }

    public partial interface IParkingLotFloorsRepository : IRepositoryBase<ParkingLotFloors>
    {


        HomeIndexViewModel GetListRemainParkingGridAmounts();

        Ivw_ParkingLotGridRemainRepository vw_ParkingLotGridRemainRepository { get; set; }
    }
}