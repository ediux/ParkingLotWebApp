using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsRecoed_HTRepository : EFRepository<ParkingLotsRecoed_HT>, IParkingLotsRecoed_HTRepository
	{

	}

	public  partial interface IParkingLotsRecoed_HTRepository : IRepositoryBase<ParkingLotsRecoed_HT>
	{

	}
}