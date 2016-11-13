using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class ETCSQLiteViewModel
    {
        public string TagCode { get; set; }
        public string CarId { get; set; }
        public int CarPurposeTypesId { get; set; }
    }
    public class SyncDataViewModel
    {
        public SyncDataViewModel()
        {
            ETCBinding = new Collection<ETCSQLiteViewModel>();
            CarPurposeTypes = new Collection<CarPurposeTypes>();
        }
        public virtual ICollection<ETCSQLiteViewModel> ETCBinding { get; set; }

        public virtual ICollection<CarPurposeTypes> CarPurposeTypes { get; set; }
    }
}