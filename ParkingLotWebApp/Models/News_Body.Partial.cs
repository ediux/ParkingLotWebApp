namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(News_BodyMetaData))]
    public partial class News_Body
    {
    }
    
    public partial class News_BodyMetaData
    {
        [Required]
        public int Id { get; set; }
        [Display(Name="公告標題")]
        public Nullable<int> Header_Id { get; set; }
        [Display(Name="公告內容")]
        public string Content { get; set; }
        [Required]
        [Display(Name="版本號")]
        public int Version { get; set; }
        [Required]
        [Display(Name="建立者")]
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
    
        public virtual News_Header News_Header { get; set; }
    }
}
