using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class CarPurposeTypes
    {
        public static CarPurposeTypes Create()
        {
            return new Models.CarPurposeTypes()
            {
                Id = 0,
                Name = string.Empty,
                Void = false
            };
        }
    }
}