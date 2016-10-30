using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class SensorsRepository : EFRepository<Sensors>, ISensorsRepository
	{

	}

	public  partial interface ISensorsRepository : IRepositoryBase<Sensors>
	{

	}
}