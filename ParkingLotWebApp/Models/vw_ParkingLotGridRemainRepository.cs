using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class vw_ParkingLotGridRemainRepository : EFRepository<vw_ParkingLotGridRemain>, Ivw_ParkingLotGridRemainRepository
	{

	}

	public  partial interface Ivw_ParkingLotGridRemainRepository : IRepositoryBase<vw_ParkingLotGridRemain>
	{

	}
}