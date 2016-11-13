using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public partial class ETCBinding
    {
        public string ETCID { get; set; }
        public string CarID { get; set; }
        public Nullable<int> CarPurposeTypeID { get; set; }

    }
    public class SyncDataViewModel
    {
        public SyncDataViewModel()
        {
            ETCBinding = new Collection<ETCBinding>();
            CarPurposeTypes = new Collection<CarPurposeTypes>();
        }
        public virtual ICollection<ETCBinding> ETCBinding { get; set; }

        public virtual ICollection<CarPurposeTypes> CarPurposeTypes { get; set; }
    }
}