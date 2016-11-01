using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class News_BodyRepository : EFRepository<News_Body>, INews_BodyRepository
	{

	}

	public  partial interface INews_BodyRepository : IRepositoryBase<News_Body>
	{

	}
}