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
        public short Count { get; set; }
    }
}
