namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CarsInParkingLotPath_BodyMetaData))]
    public partial class CarsInParkingLotPath_Body
    {
    }
    
    public partial class CarsInParkingLotPath_BodyMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int HeaderId { get; set; }
        [Required]
        public int SensorId { get; set; }
        [Required]
        public System.DateTime CreateUTCTime { get; set; }
    
        public virtual Sensors Sensors { get; set; }
        public virtual CarsInParkingLotPath_Header CarsInParkingLotPath_Header { get; set; }
    }
}
