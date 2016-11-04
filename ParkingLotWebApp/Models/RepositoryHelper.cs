using System;

namespace ParkingLotWebApp.Models
{
	public static class RepositoryHelper
	{
		public static TUnitOfWork GetUnitOfWork<TUnitOfWork>() where TUnitOfWork : IUnitOfWork
        {
            return Activator.CreateInstance<TUnitOfWork>();
        }
		
				public static IUnitOfWork GetWbParkSystemEntitiesUnitOfWork()
		{
			return new WbParkSystemEntitiesUnitOfWork();
		}			
			
		public static AnnouncementDetailRepository GetAnnouncementDetailRepository()
		{
			var repository = new AnnouncementDetailRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static AnnouncementDetailRepository GetAnnouncementDetailRepository(IUnitOfWork unitOfWork)
		{
			var repository = new AnnouncementDetailRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static CarsRepository GetCarsRepository()
		{
			var repository = new CarsRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static CarsRepository GetCarsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CarsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static EmployeeRepository GetEmployeeRepository()
		{
			var repository = new EmployeeRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
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
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static ETAsRepository GetETAsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ETAsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotsDetailRepository GetParkingLotsDetailRepository()
		{
			var repository = new ParkingLotsDetailRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static ParkingLotsDetailRepository GetParkingLotsDetailRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotsDetailRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotsFloorRepository GetParkingLotsFloorRepository()
		{
			var repository = new ParkingLotsFloorRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static ParkingLotsFloorRepository GetParkingLotsFloorRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotsFloorRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotsRecoed_HTRepository GetParkingLotsRecoed_HTRepository()
		{
			var repository = new ParkingLotsRecoed_HTRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static ParkingLotsRecoed_HTRepository GetParkingLotsRecoed_HTRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotsRecoed_HTRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ParkingLotsRecordRepository GetParkingLotsRecordRepository()
		{
			var repository = new ParkingLotsRecordRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static ParkingLotsRecordRepository GetParkingLotsRecordRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ParkingLotsRecordRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PushPhoneDetailRepository GetPushPhoneDetailRepository()
		{
			var repository = new PushPhoneDetailRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static PushPhoneDetailRepository GetPushPhoneDetailRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PushPhoneDetailRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PushPhoneTypeRepository GetPushPhoneTypeRepository()
		{
			var repository = new PushPhoneTypeRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static PushPhoneTypeRepository GetPushPhoneTypeRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PushPhoneTypeRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static WebLoginPowerRepository GetWebLoginPowerRepository()
		{
			var repository = new WebLoginPowerRepository();
			repository.UnitOfWork = GetWbParkSystemEntitiesUnitOfWork();
			return repository;
		}

		public static WebLoginPowerRepository GetWebLoginPowerRepository(IUnitOfWork unitOfWork)
		{
			var repository = new WebLoginPowerRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

	}
}
	