using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class PushPhoneDetailRepository : EFRepository<PushPhoneDetail>, IPushPhoneDetailRepository
	{

	}

	public  partial interface IPushPhoneDetailRepository : IRepositoryBase<PushPhoneDetail>
	{

	}
}