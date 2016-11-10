using System;

namespace My.Core.Infrastructures.Implementations.Models
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
		
		
		public static ApplicationRoleRepository GetApplicationRoleRepository()
		{
			var repository = new ApplicationRoleRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ApplicationRoleRepository GetApplicationRoleRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ApplicationRoleRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ApplicationUserRepository GetApplicationUserRepository()
		{
			var repository = new ApplicationUserRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ApplicationUserRepository GetApplicationUserRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ApplicationUserRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ApplicationUserClaimRepository GetApplicationUserClaimRepository()
		{
			var repository = new ApplicationUserClaimRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ApplicationUserClaimRepository GetApplicationUserClaimRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ApplicationUserClaimRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ApplicationUserLoginRepository GetApplicationUserLoginRepository()
		{
			var repository = new ApplicationUserLoginRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ApplicationUserLoginRepository GetApplicationUserLoginRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ApplicationUserLoginRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}