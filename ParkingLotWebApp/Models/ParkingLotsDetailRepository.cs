using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsDetailRepository : EFRepository<ParkingLotsDetail>, IParkingLotsDetailRepository
	{

	}

	public  partial interface IParkingLotsDetailRepository : IRepositoryBase<ParkingLotsDetail>
	{

	}
}