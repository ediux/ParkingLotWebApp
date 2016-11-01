using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class News_HeaderRepository : EFRepository<News_Header>, INews_HeaderRepository
	{

	}

	public  partial interface INews_HeaderRepository : IRepositoryBase<News_Header>
	{

	}
}