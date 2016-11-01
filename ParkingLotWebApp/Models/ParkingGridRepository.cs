using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingGridRepository : EFRepository<ParkingGrid>, IParkingGridRepository
	{

	}

	public  partial interface IParkingGridRepository : IRepositoryBase<ParkingGrid>
	{

	}
}