using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ParkingLotWebApp.Models
{
	public partial class WbParkSystemEntitiesUnitOfWork : IUnitOfWork
	{
		private DbContext _context;
		public DbContext Context { get{ return _context;} set{ _context=value;} }

		public WbParkSystemEntitiesUnitOfWork()
		{
			Context = new WbParkSystemEntities();
		}

		public void Commit()
		{
            try
            {
                Context.SaveChanges();
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                List<string> errmsg = new List<string>();

                foreach(var vaerr in ex.EntityValidationErrors)
                {
                    foreach (var err in vaerr.ValidationErrors)
                    {
                        errmsg.Add(string.Format("{0} : {1}", err.PropertyName, err.ErrorMessage));
                    }                    
                }

                throw new System.Exception(ex.Message + string.Concat(errmsg.ToArray()), ex);
            }
			
		}
		
		public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                List<string> errmsg = new List<string>();

                foreach (var vaerr in ex.EntityValidationErrors)
                {
                    foreach (var err in vaerr.ValidationErrors)
                    {
                        errmsg.Add(string.Format("{0} : {1}", err.PropertyName, err.ErrorMessage));
                    }
                }

                throw new System.Exception(ex.Message + string.Concat(errmsg.ToArray()), ex);
            }
        }

		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public bool ProxyCreationEnabled
		{
			get { return Context.Configuration.ProxyCreationEnabled; }
			set { Context.Configuration.ProxyCreationEnabled = value; }
		}
		
		public string ConnectionString
		{
			get { return Context.Database.Connection.ConnectionString; }
			set { Context.Database.Connection.ConnectionString = value; }
		}

	}
}