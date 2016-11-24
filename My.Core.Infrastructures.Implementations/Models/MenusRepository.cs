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
       
        private const string key = "Menus";
        public MenusRepository()
        {
           
        }


        public override IQueryable<Menus> All()
        {
            return GetCache().Where(w => w.Void == false).AsQueryable();
        }
        public void ClearCache(string key)
        {
            UnitOfWork.Invalidate(key);
        }

        public IQueryable<Menus> GetCache()
        {
            List<Menus> customerData = UnitOfWork.Get(key) as List<Menus>;

            if (UnitOfWork.IsSet(key) == false)
            {
                //Get the Customer data
                customerData = ObjectSet.ToList();
                UnitOfWork.Set(key, customerData, 60);
            }

            if (customerData.Count == 0)
            {
                customerData = ObjectSet.ToList();
                UnitOfWork.Set(key, customerData, 60);
            }

            if (customerData.Count != ObjectSet.Count())
            {
                UnitOfWork.Invalidate(key);
                customerData = ObjectSet.ToList();
                UnitOfWork.Set(key, customerData, 60);
            }

            return customerData.AsQueryable();
        }

        public IQueryable<Menus> GetRootMenus(ApplicationUser user)
        {
            if (user != null)
            {
                var getmenus = user.ApplicationRole.SelectMany(s => s.Menus).Where(w => w.Void == false && w.AllowAnonymous == false)
                    .Union(ObjectSet.Where(w => w.AllowAnonymous == true
                && w.Void == false
                && (w.ParentMenuId == null
                || w.ParentMenuId == 0))).Distinct().OrderBy(o => o.Order);

                return getmenus.AsQueryable();
            }

            return ObjectSet.Where(w => w.AllowAnonymous == true
                && w.Void == false
                && (w.ParentMenuId == null
                || w.ParentMenuId == 0)).OrderBy(o => o.Order);

        }

    }

    public partial interface IMenusRepository : IRepositoryBase<Menus>
    {
        IQueryable<Menus> GetRootMenus(ApplicationUser user);
    }
}