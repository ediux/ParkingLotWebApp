using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsRecord_HTRepository : EFRepository<ParkingLotsRecord_HT>, IParkingLotsRecord_HTRepository
	{

	}

	public  partial interface IParkingLotsRecord_HTRepository : IRepositoryBase<ParkingLotsRecord_HT>
	{

	}
}