namespace ParkingLotWebApp.Models
{
    using My.Core.Infrastructures.Implementations.Resources;
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
        [Display(Name = "車號")]
        public string CarNumber { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        [Required]
        [Display(Name = "車種")]
        [UIHint("CarTypeDisplay")]
        public string CarType { get; set; }
        [Display(Name = "ETC ID")]
        public Nullable<int> ETAId { get; set; }
        [Display(Name = "員工資料識別碼")]
        public Nullable<int> EmpId { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void",ResourceType = typeof(MUI))]
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
        [Display(Name = "用途類型")]
        public Nullable<int> CarPurposeTypeID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ETAs ETAs { get; set; }
        public virtual CarPurposeTypes CarPurposeTypes { get; set; }
        public virtual ICollection<PushPhoneDetail> PushPhoneDetail { get; set; }
    }
}
