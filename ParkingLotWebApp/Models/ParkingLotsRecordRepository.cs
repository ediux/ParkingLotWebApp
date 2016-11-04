using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ParkingLotsRecordRepository : EFRepository<ParkingLotsRecord>, IParkingLotsRecordRepository
	{

	}

	public  partial interface IParkingLotsRecordRepository : IRepositoryBase<ParkingLotsRecord>
	{

	}
}