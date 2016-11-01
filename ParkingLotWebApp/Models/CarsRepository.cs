using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class CarsRepository : EFRepository<Cars>, ICarsRepository
	{

	}

	public  partial interface ICarsRepository : IRepositoryBase<Cars>
	{

	}
}