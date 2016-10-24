namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ParkingLotFloorsMetaData))]
    public partial class ParkingLotFloors
    {
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
        [Display(Name = "是否刪除")]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "建立者")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        [Display(Name = "最後更新者")]
        public int LastUserId { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        public System.DateTime LastUpdateUtcTime { get; set; }
    
        public virtual ICollection<ParkingGrid> ParkingGrid { get; set; }
        public virtual ParkingLotAreas ParkingLotAreas { get; set; }
        public virtual ICollection<Sensors> Sensors { get; set; }
    }
}
