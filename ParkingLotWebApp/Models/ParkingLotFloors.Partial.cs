namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotFloorsMetaData))]
    public partial class ParkingLotFloors
    {
        public static ParkingLotFloors Create(int UserId)
        {
            var model = new ParkingLotFloors();
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }
    
    public partial class ParkingLotFloorsMetaData
    {
        [Required]
        public int Id { get; set; }
        public Nullable<int> AreaId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "樓層名稱")]
        public string Name { get; set; }
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
        [Required]
        [Display(Name = "停車格數")]
        public int GridAmout { get; set; }
        [Required]
        [Display(Name = "剩餘停車格數")]
        public int GridRemainAmount { get; set; }
        [Required]
        [Display(Name = "無樓層")]
        public bool NoneFloor { get; set; }
        public virtual ICollection<ParkingGrid> ParkingGrid { get; set; }
        public virtual ParkingLotAreas ParkingLotAreas { get; set; }
        public virtual ICollection<Sensors> Sensors { get; set; }
    }
}
