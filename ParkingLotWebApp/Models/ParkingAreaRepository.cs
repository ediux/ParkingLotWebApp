using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingAreaRepository : EFRepository<ParkingArea>, IParkingAreaRepository
	{

	}

	public  partial interface IParkingAreaRepository : IRepositoryBase<ParkingArea>
	{

	}
}