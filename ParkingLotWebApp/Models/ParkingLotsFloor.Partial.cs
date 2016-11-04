namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotsFloorMetaData))]
    public partial class ParkingLotsFloor
    {
        public static ParkingLotsFloor Create()
        {
            return new ParkingLotsFloor() {
                LastUpdate = DateTime.Now  
            };
        }
    }
    
    public partial class ParkingLotsFloorMetaData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int ParkingLotsID { get; set; }
        [Required]
        public short FloorOrder { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string FloorName { get; set; }
        [Required]
        public int CarTotalGrid { get; set; }
        [Required]
        public int CarLastGrid { get; set; }
        [Required]
        public int MotoTotalGrid { get; set; }
        [Required]
        public int MotoLastGrid { get; set; }
        [Required]
        public bool Void { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    
        public virtual ParkingLotsDetail ParkingLotsDetail { get; set; }
    }
}
