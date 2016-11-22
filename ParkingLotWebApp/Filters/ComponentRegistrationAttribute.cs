using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Core.Infrastructures.Implementations.Models;

namespace ParkingLotWebApp.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ComponentRegistrationAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISystem_ControllersRepository CtrRepo = RepositoryHelper.GetSystem_ControllersRepository();
            ISystem_ControllerActionsRepository ActionRepo = RepositoryHelper.GetSystem_ControllerActionsRepository(CtrRepo.UnitOfWork);

            base.OnActionExecuting(filterContext);
        }
    }
}