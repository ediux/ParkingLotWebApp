namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotsRecoed_HTMetaData))]
    public partial class ParkingLotsRecoed_HT
    {
    }
    
    public partial class ParkingLotsRecoed_HTMetaData
    {
        [Required]
        public int ID { get; set; }
        public Nullable<System.DateTime> LogTime { get; set; }
        public Nullable<System.DateTime> ParkDate { get; set; }
        [Required]
        public short Count { get; set; }
    }
}
