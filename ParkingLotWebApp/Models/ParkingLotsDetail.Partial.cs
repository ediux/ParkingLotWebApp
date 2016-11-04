namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// 停車場資訊
    /// </summary>
    [MetadataType(typeof(ParkingLotsDetailMetaData))]
    public partial class ParkingLotsDetail
    {
    }
    
    public partial class ParkingLotsDetailMetaData
    {
        [Required]
        [Display(Name="停車場系統代碼")]
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
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string Charge { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public int CarGrid { get; set; }
        [Required]
        public int MotoGrid { get; set; }
        [Required]
        public bool Void { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
