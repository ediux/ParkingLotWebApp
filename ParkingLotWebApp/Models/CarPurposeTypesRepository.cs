using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class CarPurposeTypesRepository : EFRepository<CarPurposeTypes>, ICarPurposeTypesRepository
	{

	}

	public  partial interface ICarPurposeTypesRepository : IRepositoryBase<CarPurposeTypes>
	{

	}
}