using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using My.Core.Infrastructures.Implementations.Base;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class MenusRepository : EFRepository<Menus>, IMenusRepository, IDataRepository<Menus>
    {
        private ICacheProvider _cache;
        private const string key = "Menus";
        public MenusRepository()
        {
            _cache = new DefaultCacheProvider();
        }

        public ICacheProvider Cache
        {
            get
            {
                return _cache;
            }

        }
        public override IQueryable<Menus> All()
        {
            return GetCache().AsQueryable();
        }
        public void ClearCache(string key)
        {
            _cache.Invalidate(key);
        }

        public IQueryable<Menus> GetCache()
        {
            List<Menus> customerData = Cache.Get(key) as List<Menus>;

            if (Cache.IsSet(key)==false)
            {
                //Get the Customer data
                customerData = ObjectSet.ToList();
                Cache.Set(key, customerData, 60);                
            }

            if (customerData.Count == 0)
            {
                customerData = ObjectSet.ToList();
                Cache.Set(key, customerData, 60);
            }

            return customerData.AsQueryable();
        }

        public IQueryable<Menus> GetRootMenus()
        {
            return All().Where(w => w.ParentMenuId == null && w.Void == false);
        }
        
    }

    public partial interface IMenusRepository : IRepositoryBase<Menus>
    {
        ICacheProvider Cache { get; }
        IQueryable<Menus> GetRootMenus();
    }
}