using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class CarsInParkingLotPath_HeaderRepository : EFRepository<CarsInParkingLotPath_Header>, ICarsInParkingLotPath_HeaderRepository
	{

	}

	public  partial interface ICarsInParkingLotPath_HeaderRepository : IRepositoryBase<CarsInParkingLotPath_Header>
	{

	}
}