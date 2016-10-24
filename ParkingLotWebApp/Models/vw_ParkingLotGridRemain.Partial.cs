namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vw_ParkingLotGridRemainMetaData))]
    public partial class vw_ParkingLotGridRemain
    {
    }
    
    public partial class vw_ParkingLotGridRemainMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "區域名稱")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "是否刪除")]
        public bool Void { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "樓層名稱")]
        public string 樓層名稱 { get; set; }
        [Required]
        [Display(Name = "停車格數")]
        public int 停車格數 { get; set; }
        [Required]
        [Display(Name = "剩餘停車格數")]
        public int 剩餘停車格數 { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        public System.DateTime 最後更新時間 { get; set; }
    }
}
