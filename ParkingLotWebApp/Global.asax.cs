﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ParkingLotWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            My.Core.Infrastructures.Implementations.Models.ISystem_ControllersRepository ctrRepo = My.Core.Infrastructures.Implementations.Models.RepositoryHelper.GetSystem_ControllersRepository();
            ctrRepo.ScanForComponentRegistration(typeof(ParkingLotWebApp.MvcApplication));
            ctrRepo.Dispose();
            ctrRepo = null;
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //將 Cookies 的 MyLang 取出，主要是要指定語系
            HttpCookie MyLang = Request.Cookies["MyLang"];
            if (MyLang != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture =
                 new System.Globalization.CultureInfo(MyLang.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                 new System.Globalization.CultureInfo(MyLang.Value);
            }
        }
    }
}
