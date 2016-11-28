using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Core.Infrastructures.Implementations.Models;
using Microsoft.AspNet.Identity;

namespace ParkingLotWebApp.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ComponentRegistrationAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                ISystem_ControllersRepository CtrRepo = RepositoryHelper.GetSystem_ControllersRepository();
                ISystem_ControllerActionsRepository ActionRepo = RepositoryHelper.GetSystem_ControllerActionsRepository(CtrRepo.UnitOfWork);

                int currentUserId = filterContext.HttpContext.User.Identity.GetUserId<int>();
                System_Controllers ctrl = null;

                string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name;
                ctrl = CtrRepo.All().FirstOrDefault(w => w.ClassName.Equals(ctrlName, StringComparison.InvariantCultureIgnoreCase));

                if (ctrl == null)
                {

                    ctrl = CtrRepo.Add(new System_Controllers()
                    {
                        AllowAnonymous = true,
                        ClassName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name,
                        CreateUserId = currentUserId,
                        CreateTime = DateTime.Now,
                        LastUpdateUserId = currentUserId,
                        LastUpdateTime = DateTime.Now,
                        Name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                        Namespace = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace,
                        Void = false
                    });

                    CtrRepo.Commit();
                    ctrl = CtrRepo.Reload(ctrl);
                }

                string actionname = filterContext.ActionDescriptor.ActionName;
                System_ControllerActions action = ActionRepo.All().FirstOrDefault(
                    w => w.Name.Equals(actionname, StringComparison.InvariantCultureIgnoreCase)
                    && w.ControllerId == ctrl.Id);

                if (action == null)
                {
                    action = ActionRepo.Add(new System_ControllerActions
                    {
                        AllowAnonymous = true,
                        ControllerId = ctrl.Id,
                        CreateTime = DateTime.Now,
                        CreateUserId = currentUserId,
                        LastUpdateTime = DateTime.Now,
                        LastUpdateUserId = currentUserId,
                        Name = filterContext.ActionDescriptor.ActionName,
                        Void = false
                    });
                    ActionRepo.Commit();
                    action = ActionRepo.Reload(action);
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw ex;
            }
           
        }
    }
}