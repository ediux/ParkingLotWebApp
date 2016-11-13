namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotsRecordMetaData))]
    public partial class ParkingLotsRecord
    {
    }
    
    public partial class ParkingLotsRecordMetaData
    {
        [Required]
        public int ID { get; set; }
        public Nullable<System.DateTime> LogTime { get; set; }
        public Nullable<System.DateTime> ParkDate { get; set; }
        [Required]
        public int Count { get; set; }
        public Nullable<int> ParkingLotsFloorID { get; set; }
        [Required]
        public int CountRFID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string Code { get; set; }
    
        public virtual ParkingLotsFloor ParkingLotsFloor { get; set; }
    }
}
