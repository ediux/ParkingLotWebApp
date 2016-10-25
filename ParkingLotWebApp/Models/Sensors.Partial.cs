namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(SensorsMetaData))]
    public partial class Sensors
    {
    }

    public partial class SensorsMetaData
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "序號")]
        public string SerialNumber { get; set; }
        [Display(Name = "地理資訊")]
        public System.Data.Entity.Spatial.DbGeography GPS { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        [Required]
        [Display(Name = "狀態")]
        [UIHint("VoidDisplay")]
        public string Void { get; set; }
        [Required]
        [Display(Name = "建立者")]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        [Display(Name = "最後更新者")]
        [UIHint("UserIDMappingDisplay")]
        public int LastUserId { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateUtcTime { get; set; }

        public virtual ICollection<CarsInParkingLotPath_Body> CarsInParkingLotPath_Body { get; set; }
        public virtual ICollection<ParkingLotFloors> ParkingLotFloors { get; set; }
    }
}
