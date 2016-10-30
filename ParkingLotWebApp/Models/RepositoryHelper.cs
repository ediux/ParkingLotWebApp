using System;

namespace ParkingLotWebApp.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}

		public static TUnitOfWork GetUnitOfWork<TUnitOfWork>() where TUnitOfWork : IUnitOfWork
        {
            return Activator.CreateInstance<TUnitOfWork>();
        }
		
		
		public static CarsRepository GetCarsRepository()
		{
			var repository = new CarsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CarsRepository GetCarsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CarsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static CarsInParkingLotPath_BodyRepository GetCarsInParkingLotPath_BodyRepository()
		{
			var repository = new CarsInParkingLotPath_BodyRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CarsInParkingLotPath_BodyRepository GetCarsInParkingLotPath_BodyRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CarsInParkingLotPath_BodyRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static CarsInParkingLotPath_HeaderRepository GetCarsInParkingLotPath_HeaderRepository()
		{
			var repository = new CarsInParkingLotPath_HeaderRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CarsInParkingLotPath_HeaderRepository GetCarsInParkingLotPath_HeaderRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CarsInParkingLotPath_HeaderRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static EmployeeRepository GetEmployeeRepository()
		{
			var repository = new EmployeeRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static EmployeeRepository GetEmployeeRepository(IUnitOfWork unitOfWork)
		{
			var repository = new EmployeeRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ETAsRepository GetETAsRepository()
		{
			var repository = new ETAsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ETAsRepository GetETAsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ETAsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static News_BodyRepository GetNews_BodyRepository()
		{
			var repository = new News_BodyRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static News_BodyRepository GetNews_BodyRepository(IUnitOfWork unitOfWork)
		{
			var repository = new News_BodyRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static News_HeaderRepository GetNews_HeaderRepository()
		{
			var repository = new News_HeaderRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static News_HeaderRepository GetNews_HeaderRepository(IUnitOfWork unitOfWork)
		{
			var repository = new News_HeaderRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingGridRepository GetParkingGridRepository()
		{
			var repository = new ParkingGridRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ParkingGridRepository GetParkingGridRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingGridRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotAreasRepository GetParkingLotAreasRepository()
		{
			var repository = new ParkingLotAreasRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ParkingLotAreasRepository GetParkingLotAreasRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotAreasRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotFloorsRepository GetParkingLotFloorsRepository()
		{
			var repository = new ParkingLotFloorsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ParkingLotFloorsRepository GetParkingLotFloorsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotFloorsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static SensorsRepository GetSensorsRepository()
		{
			var repository = new SensorsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static SensorsRepository GetSensorsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new SensorsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static vw_ParkingLotGridRemainRepository Getvw_ParkingLotGridRemainRepository()
		{
			var repository = new vw_ParkingLotGridRemainRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static vw_ParkingLotGridRemainRepository Getvw_ParkingLotGridRemainRepository(IUnitOfWork unitOfWork)
		{
			var repository = new vw_ParkingLotGridRemainRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}