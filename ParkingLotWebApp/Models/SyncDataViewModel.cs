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

        public DateTime CreateTime { get; set; }
        public DateTime? LastUpdateTiem { get; set; }
        public DateTime? LastUploadTime { get; set; }
    }
    public class SyncDataViewModel
    {
        public SyncDataViewModel()
        {
            etcbinding = new List<ETCBinding>();
            carpurposetypes = new List<CarPurposeTypes>();
            _settings = new Dictionary<string, object>();
        }
        private IList<ETCBinding> etcbinding;

        public virtual IList<ETCBinding> ETCBinding { get { return etcbinding; } set { etcbinding = value; } }

        private IList<CarPurposeTypes> carpurposetypes;
        public virtual IList<CarPurposeTypes> CarPurposeTypes { get { return carpurposetypes; } set { carpurposetypes = value; } }

        private IDictionary<string, object> _settings;

        public IDictionary<string, object> AppSettings { get { return _settings; } set { _settings = value; } }
    }
}