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

            if (ObjectSet.Count() == 0)
            {
                //資料表為空
                var Controllers = WebAppType.Assembly.GetTypes().Where(s => s.FullName.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase));

                if (Controllers.Any())
                {
                    foreach(var ctrl in Controllers)
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

                        Add(ctrcls);
                        UnitOfWork.Commit();
                        ctrcls = Reload(ctrcls);

                        var actions = ctrl.GetMethods();
                        if (actions.Any())
                        {
                            actions = actions.Where(w => w.ReturnType == typeof(ActionResult) 
                            || w.ReturnType == typeof(JsonResult)).ToArray();

                            foreach(var action in actions)
                            {
                                if (action.GetCustomAttributes(true).OfType<HttpPostAttribute>().Any())
                                    continue;

                                if (actionRepo.Where(w => w.Name == action.Name && w.System_Controllers.Id == ctrcls.Id).Any())
                                    continue;

                                System_ControllerActions actiondata = new Models.System_ControllerActions();
                                actiondata.ControllerId = ctrcls.Id;
                                actiondata.CreateTime = DateTime.Now;
                                actiondata.CreateUserId = 0;
                                actiondata.LastUpdateTime = DateTime.Now;
                                actiondata.LastUpdateUserId = 0;
                                actiondata.Name = action.Name;
                                actiondata.Void = false;

                                actionRepo.Add(actiondata);                                
                            }
                            actionRepo.UnitOfWork.Commit();
                        }
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