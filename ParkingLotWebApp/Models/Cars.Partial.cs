namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CarsMetaData))]
    public partial class Cars
    {
    }

    public partial class CarsMetaData
    {
        [Required]
        [Display(Name = "系統識別碼")]
        public int Id { get; set; }

        [Display(Name = "eTag參照代碼")]
        public Nullable<int> ETCsID { get; set; }

        public virtual CarPurposeTypes CarPurposeTypes { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ETAs ETAs { get; set; }
        public virtual ICollection<PushPhoneDetail> PushPhoneDetail { get; set; }
    }
}
