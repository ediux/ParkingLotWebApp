using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotFloorsRepository : EFRepository<ParkingLotFloors>, IParkingLotFloorsRepository
	{

	}

	public  partial interface IParkingLotFloorsRepository : IRepositoryBase<ParkingLotFloors>
	{

	}
}