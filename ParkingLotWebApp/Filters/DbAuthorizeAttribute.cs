using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Core.Infrastructures.Implementations.Models;

namespace ParkingLotWebApp.Filters
{
    public class DbAuthorizeAttribute : AuthorizeAttribute
    {
        private IApplicationRoleRepository roleRepo;

        public DbAuthorizeAttribute()
        {
            roleRepo = RepositoryHelper.GetApplicationRoleRepository();

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string controllerClassName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name;
            string controllerNamespace = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace;
            ApplicationUser currentUser = null;

            IApplicationUserRepository userRepo = RepositoryHelper.GetApplicationUserRepository();

            ISystem_ControllerActionsRepository actionRepo = RepositoryHelper.GetSystem_ControllerActionsRepository(userRepo.UnitOfWork);

            currentUser = userRepo.FindUserByLoginAccount(filterContext.HttpContext.User.Identity.Name, false);

            if (currentUser != null)
            {
                if (currentUser.ApplicationRole.SelectMany(s => s.System_ControllerActions)
                        .Where(w => w.Name == actionName)
                        .Where(w => w.System_Controllers.Name == controllerName
                        && w.System_Controllers.ClassName == controllerClassName
                        && w.System_Controllers.Namespace == controllerNamespace)
                        .Any())
                {
                    return;
                }

            }

            if (filterContext.ActionDescriptor.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any())
                return;

            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any())
                return;

            if(filterContext.HttpContext.User.Identity.Name.Equals("root", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            filterContext.Result = new HttpUnauthorizedResult();
            //base.OnAuthorization(filterContext);
        }

    }
}