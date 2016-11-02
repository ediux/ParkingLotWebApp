namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ParkingGridMetaData))]
    public partial class ParkingGrid
    {
        public static ParkingGrid Create(int UserId)
        {
            var model = new ParkingGrid();
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }

    public partial class ParkingGridMetaData
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "樓層")]
        public Nullable<int> FloorId { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "車格位號碼")]
        public string Name { get; set; }
        [Display(Name = "地理資訊")]
        public System.Data.Entity.Spatial.DbGeography GPS { get; set; }
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

        public virtual ParkingLotFloors ParkingLotFloors { get; set; }
        public virtual ICollection<Cars> Cars { get; set; }
        public virtual ICollection<CarsInParkingLotPath_Header> CarsInParkingLotPath_Header { get; set; }
    }
}
