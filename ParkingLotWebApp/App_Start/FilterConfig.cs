using System.Web;
using System.Web.Mvc;

namespace ParkingLotWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute()
            //{
            //    ExceptionType = typeof(System.Data.Entity.Validation.DbEntityValidationException),
            //    View = "DbEntityValidationException"
            //}, 0);
            filters.Add(new ParkingLotWebApp.Filters.ComponentRegistrationAttribute(), 0);
            filters.Add(new Filters.DbAuthorizeAttribute(), 1);
            filters.Add(new HandleErrorAttribute() { View = "Error" }, 2);
        }
    }
}
