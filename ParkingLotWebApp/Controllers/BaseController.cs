﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingLotWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);

            if(filterContext.Exception is System.Data.Entity.Validation.DbEntityValidationException)
            {
                filterContext.ExceptionHandled = true;

                filterContext.Result = View("DbEntityValidationException", filterContext.Exception);
   
                return;
            }

            //if(filterContext.HttpContext.Response.StatusCode == 404)
            //{

            //}
            base.OnException(filterContext);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            base.HandleUnknownAction(actionName);
        }
    }
}