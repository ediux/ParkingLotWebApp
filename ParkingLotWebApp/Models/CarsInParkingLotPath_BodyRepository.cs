using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class CarsInParkingLotPath_BodyRepository : EFRepository<CarsInParkingLotPath_Body>, ICarsInParkingLotPath_BodyRepository
	{

	}

	public  partial interface ICarsInParkingLotPath_BodyRepository : IRepositoryBase<CarsInParkingLotPath_Body>
	{

	}
}