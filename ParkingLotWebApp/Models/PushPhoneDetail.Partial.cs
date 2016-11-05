namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PushPhoneDetailMetaData))]
    public partial class PushPhoneDetail
    {
    }
    
    public partial class PushPhoneDetailMetaData
    {
        [Required]
        public byte PhoneTypeID { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string DeviceID { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string Token { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Void { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> CarInfoId { get; set; }
    
        public virtual PushPhoneType PushPhoneType { get; set; }
        public virtual Cars Cars { get; set; }
    }
}
