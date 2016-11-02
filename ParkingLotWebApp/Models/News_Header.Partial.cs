namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(News_HeaderMetaData))]
    public partial class News_Header
    {
        public static News_Header Create(int UserId)
        {
            var model = new News_Header();
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }

    public partial class News_HeaderMetaData
    {
        [Required]
        public int Id { get; set; }

        [StringLength(500, ErrorMessage = "欄位長度不得大於 500 個字元")]
        [Required]
        [Display(Name = "標題")]
        public string Caption { get; set; }
        [Required]
        [Display(Name = "起始時間")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [UIHint("UTCLocalDateDisplay")]
        public System.DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "結束時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [UIHint("UTCLocalDateDisplay")]
        public System.DateTime EndTime { get; set; }
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

        public virtual News_Body News_Body { get; set; }
    }
}
