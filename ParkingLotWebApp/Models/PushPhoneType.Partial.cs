namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PushPhoneTypeMetaData))]
    public partial class PushPhoneType
    {
    }
    
    public partial class PushPhoneTypeMetaData
    {
        [Required]
        public byte ID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string PushPhone { get; set; }
    }
}
