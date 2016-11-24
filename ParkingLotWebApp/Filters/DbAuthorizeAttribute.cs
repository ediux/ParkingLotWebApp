﻿using System;
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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            string[] _allowroles = this.Roles.Split(',');

            List<ApplicationRole> rolesInDb = roleRepo.Where(w => _allowroles.Contains(w.Name)).ToList();

            return base.AuthorizeCore(httpContext);
        }

    }
}