using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Security.Application;
using System.Web.Mvc;

namespace ParkingLotWebApp
{
    public static class SecurityHelper
    {
        public static void ApplyXSSProtected(this Controller ctr, FormCollection collection)
        {
            if (collection.Count > 0)
            {
                foreach (string key in collection.Keys)
                {
                    ctr.Request.Form[key] = Sanitizer.GetSafeHtmlFragment(ctr.Request.Form[key]);
                }
            }
        }

        public static void ApplyXSSProtected<T>(this Controller ctr, T model) where T : class
        {
            Type t = model.GetType();

            var prpoerites = t.GetProperties(System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Public);

            if (prpoerites.Count() > 0)
            {
                foreach (var p in prpoerites)
                {
                    object v = p.GetValue(model);
                    if (v is string)
                    {
                        string value = v as string;
                        p.SetValue(model, Sanitizer.GetSafeHtmlFragment(value));
                    }


                }
            }
        }
    }
}