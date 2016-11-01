namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CarsMetaData))]
    public partial class Cars
    {
    }
    
    public partial class CarsMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name="車號")]
        public string CarNumber { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        [Required]
        [Display(Name="車種")]
        [UIHint("CarTypeDisplay")]
        public string CarType { get; set; }
        [Display(Name="ETC號碼")]
        public Nullable<int> ETAId { get; set; }
        [Display(Name="員工")]
        public Nullable<int> EmpId { get; set; }
        [Required]
        [Display(Name = "狀態")]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
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
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateUTCTime { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ETAs ETAs { get; set; }
        public virtual ICollection<ParkingGrid> ParkingGrid { get; set; }
        public virtual ICollection<CarsInParkingLotPath_Header> CarsInParkingLotPath_Header { get; set; }
    }
}
