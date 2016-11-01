using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class ETAsRepository : EFRepository<ETAs>, IETAsRepository
	{

	}

	public  partial interface IETAsRepository : IRepositoryBase<ETAs>
	{

	}
}