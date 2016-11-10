namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotsDetailMetaData))]
    public partial class ParkingLotsDetail
    {
    }
    
    public partial class ParkingLotsDetailMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(75, ErrorMessage="欄位長度不得大於 75 個字元")]
        [Required]
        public string Address { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string Tel { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        public string Period { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string Charge { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public bool Void { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> AreaID { get; set; }
    
        public virtual ParkingArea ParkingArea { get; set; }
        public virtual ICollection<ParkingLotsFloor> ParkingLotsFloor { get; set; }
    }
}
