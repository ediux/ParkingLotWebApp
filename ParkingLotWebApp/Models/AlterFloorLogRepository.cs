using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{   
	public  partial class AlterFloorLogRepository : EFRepository<AlterFloorLog>, IAlterFloorLogRepository
	{

	}

	public  partial interface IAlterFloorLogRepository : IRepositoryBase<AlterFloorLog>
	{

	}
}