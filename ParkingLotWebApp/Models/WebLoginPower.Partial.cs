namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(WebLoginPowerMetaData))]
    public partial class WebLoginPower
    {
    }
    
    public partial class WebLoginPowerMetaData
    {
        [Required]
        public byte ID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Name { get; set; }
        public Nullable<bool> Void { get; set; }
    }
}
