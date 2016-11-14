namespace ParkingLotWebApp.Models
{
    using My.Core.Infrastructures.Implementations.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ETAsMetaData))]
    public partial class ETAs
    {
    }
    
    public partial class ETAsMetaData
    {
        [Required]
        [Display(Name = "系統識別碼")]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "eTag號碼")]
        public string Code { get; set; }
        [Required]
        [Display(Name ="Void", ResourceType = typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "紀錄建立者")]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public System.DateTime CreateUTCTime { get; set; }
        [Display(Name = "最後更新者")]
        [UIHint("UserIDMappingDisplay")]
        public Nullable<int> LastUpdateUserId { get; set; }
        [Display(Name = "最後更新時間")]
        [UIHint("UTCLocalTimeDisplay")]
        public Nullable<System.DateTime> LastUpdateUTCTime { get; set; }
        [Display(Name ="車號")]
        public Nullable<int> CarRefId { get; set; }
    
        public virtual Cars Cars { get; set; }
    }
}
