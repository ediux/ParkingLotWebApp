using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{   
	public  partial class System_ControllerActionsRepository : EFRepository<System_ControllerActions>, ISystem_ControllerActionsRepository
	{

	}

	public  partial interface ISystem_ControllerActionsRepository : IRepositoryBase<System_ControllerActions>
	{

	}
}