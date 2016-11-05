using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsFloorRepository : EFRepository<ParkingLotsFloor>, IParkingLotsFloorRepository
	{

	}

	public  partial interface IParkingLotsFloorRepository : IRepositoryBase<ParkingLotsFloor>
	{

	}
}