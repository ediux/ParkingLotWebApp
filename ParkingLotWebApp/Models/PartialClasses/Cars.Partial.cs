using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class Cars
    {


        public static Cars Create(int UserId)
        {
            var model = new Cars();
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }

    public partial class CarsMetaData
    {        
        
 
    }
}