namespace ParkingLotWebApp.Models
{
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
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "ETC號碼")]
        public string Code { get; set; }
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
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        public System.DateTime LastUpdateUTCTime { get; set; }
    
        public virtual ICollection<Cars> Cars { get; set; }
    }
}
