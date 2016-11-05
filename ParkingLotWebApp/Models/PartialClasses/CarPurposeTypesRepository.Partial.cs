using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class CarPurposeTypesRepository
    {
        public override IQueryable<CarPurposeTypes> All()
        {
            return base.All().Where(w => w.Void == false);
        }
    }
}