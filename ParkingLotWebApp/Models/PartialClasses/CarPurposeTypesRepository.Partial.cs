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

        public override CarPurposeTypes Add(CarPurposeTypes entity)
        {
            CarPurposeTypes EntityInDatabase = ObjectSet.SingleOrDefault(w =>
                w.Name.Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

            if (EntityInDatabase != null)
            {
                EntityInDatabase.Void = false;
                UnitOfWork.Context.Entry(EntityInDatabase).State = System.Data.Entity.EntityState.Modified;
                return EntityInDatabase;
            }

            return base.Add(entity);
        }
        public override void Delete(CarPurposeTypes entity)
        {
            if (entity.Void == false)
            {
                entity.Void = true;
            }
        }
    }
}