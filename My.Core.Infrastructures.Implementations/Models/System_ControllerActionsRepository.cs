using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class System_ControllerActionsRepository : EFRepository<System_ControllerActions>, ISystem_ControllerActionsRepository
    {
        public void ScanForComponentRegistration(Type ControllerType, System_Controllers Controller)
        {
            try
            {
                System_Controllers ctrcls = Controller;

                if (ctrcls == null)
                    throw new ArgumentNullException("Controller");

                var actions = ControllerType.GetMethods();

                if (actions.Any())
                {
                    actions = actions.Where(w => w.ReturnType == typeof(ActionResult)
                    || w.ReturnType == typeof(JsonResult)).ToArray();

                    foreach (var action in actions)
                    {
                        try
                        {
                            if (action.GetCustomAttributes(true).OfType<HttpPostAttribute>().Any())
                                continue;

                            if (Where(w => w.Name == action.Name && w.System_Controllers.Id == ctrcls.Id).Any())
                                continue;

                            System_ControllerActions actiondata = new Models.System_ControllerActions();
                            actiondata.ControllerId = ctrcls.Id;
                            actiondata.CreateTime = DateTime.Now;
                            actiondata.CreateUserId = 0;
                            actiondata.LastUpdateTime = DateTime.Now;
                            actiondata.LastUpdateUserId = 0;
                            actiondata.Name = action.Name;
                            actiondata.Void = false;
                            actiondata.AllowAnonymous = action.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();

                            Add(actiondata);
                        }
                        catch (Exception ex)
                        {
                            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                            continue;
                        }

                    }

                    UnitOfWork.Commit();
                }

            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }
    }

    public partial interface ISystem_ControllerActionsRepository : IRepositoryBase<System_ControllerActions>
    {
        void ScanForComponentRegistration(Type ControllerType, System_Controllers Controller);
    }
}