namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CarsInParkingLotPath_HeaderMetaData))]
    public partial class CarsInParkingLotPath_Header
    {
    }
    
    public partial class CarsInParkingLotPath_HeaderMetaData
    {
        [Required]
        public int Id { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> GridId { get; set; }
        [Required]
        public int Direction { get; set; }
        [Required]
        public System.DateTime CreateUTCTime { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual ICollection<CarsInParkingLotPath_Body> CarsInParkingLotPath_Body { get; set; }
        public virtual ParkingGrid ParkingGrid { get; set; }
    }
}
