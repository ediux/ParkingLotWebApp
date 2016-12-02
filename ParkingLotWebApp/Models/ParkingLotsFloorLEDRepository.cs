using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsFloorLEDRepository : EFRepository<ParkingLotsFloorLED>, IParkingLotsFloorLEDRepository
	{

	}

	public  partial interface IParkingLotsFloorLEDRepository : IRepositoryBase<ParkingLotsFloorLED>
	{

	}
}