using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
	{

	}

	public  partial interface IEmployeeRepository : IRepositoryBase<Employee>
	{

	}
}