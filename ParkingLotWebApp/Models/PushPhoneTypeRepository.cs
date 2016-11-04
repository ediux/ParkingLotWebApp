using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class PushPhoneTypeRepository : EFRepository<PushPhoneType>, IPushPhoneTypeRepository
	{

	}

	public  partial interface IPushPhoneTypeRepository : IRepositoryBase<PushPhoneType>
	{

	}
}