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
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string CarNumber { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        [Required]
        public string CarType { get; set; }
        public Nullable<int> CarPurposeTypeID { get; set; }
        public Nullable<int> EmpId { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public int CreateUserId { get; set; }
        [Required]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        public int LastUpdateUserId { get; set; }
        [Required]
        public System.DateTime LastUpdateUTCTime { get; set; }
    
        public virtual ICollection<ETAs> ETAs { get; set; }
        public virtual ICollection<PushPhoneDetail> PushPhoneDetail { get; set; }
        public virtual CarPurposeTypes CarPurposeTypes { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
