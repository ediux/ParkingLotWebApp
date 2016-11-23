using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class System_ControllersRepository : EFRepository<System_Controllers>, ISystem_ControllersRepository
    {
        public void ScanForComponentRegistration(Type WebAppType)
        {
            ISystem_ControllerActionsRepository actionRepo = RepositoryHelper.GetSystem_ControllerActionsRepository(UnitOfWork);
            var Controllers = WebAppType.Assembly.GetTypes().Where(s => s.FullName.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase));

            if (ObjectSet.Count() == 0)
            {
                //資料表為空

                if (Controllers.Any())
                {
                    foreach (var ctrl in Controllers)
                    {
                        System_Controllers ctrcls = new Models.System_Controllers();
                        ctrcls.ClassName = ctrl.Name;
                        ctrcls.Name = ctrl.Name.Replace("Controller", "");
                        ctrcls.CreateTime = DateTime.Now;
                        ctrcls.CreateUserId = 0;
                        ctrcls.LastUpdateTime = DateTime.Now;
                        ctrcls.LastUpdateUserId = 0;
                        ctrcls.Namespace = ctrl.Namespace;
                        ctrcls.Void = false;
                        ctrcls.AllowAnonymous = ctrl.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();

                        Add(ctrcls);
                        UnitOfWork.Commit();
                    }
                }
            }
            if (Controllers.Any())
            {
                foreach (var ctrl in Controllers)
                {
                    try
                    {
                        actionRepo.ScanForComponentRegistration(ctrl, All().SingleOrDefault(s => s.ClassName == ctrl.Name));
                    }
                    catch (Exception ex)
                    {
                        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    }
                    
                }
            }
        }
    }

    public partial interface ISystem_ControllersRepository : IRepositoryBase<System_Controllers>
    {
        void ScanForComponentRegistration(Type WebAppType);

    }
}