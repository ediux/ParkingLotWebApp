using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{
	public partial class EFUnitOfWork : IUnitOfWork
	{
		private DbContext _context;
		public DbContext Context { get{ return _context;} set{ _context=value;} }

		public EFUnitOfWork()
		{
			Context = new OpenWebSiteEntities();
		}

		public void Commit()
		{
            try
            {
                Context.SaveChanges();
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbva)
            {
                List<string> msg = new List<string>();
                foreach(var o in dbva.EntityValidationErrors)
                {
                    foreach(var i in o.ValidationErrors)
                    {
                        msg.Add(string.Format("{0}:{1}", i.PropertyName, i.ErrorMessage));
                    }
                }

                throw new System.Exception(string.Join(",", msg.ToArray()));
            }
			
		}
		
		public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public object Get(string key)
        {
            return MemoryCache.Default[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            MemoryCache.Default.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (MemoryCache.Default[key] != null);
        }

        public void Invalidate(string key)
        {
            MemoryCache.Default.Remove(key);
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
