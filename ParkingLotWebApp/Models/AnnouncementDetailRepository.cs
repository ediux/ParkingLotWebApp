using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class AnnouncementDetailRepository : EFRepository<AnnouncementDetail>, IAnnouncementDetailRepository
	{

	}

	public  partial interface IAnnouncementDetailRepository : IRepositoryBase<AnnouncementDetail>
	{

	}
}