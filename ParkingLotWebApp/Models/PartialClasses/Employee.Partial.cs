using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class Employee
    {
        public static Employee Create(int UserId)
        {
            var model = new Employee();
            model.Void = false;
            model.LastUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }
}