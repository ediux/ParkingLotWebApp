using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class NewsPostViewModel
    {
        public NewsPostViewModel()
        {
            IsTop = false;
            LastUpdateUserId = CreateUserId = -1;
            LastUpdateUTCTime = CreateUTCTime = DateTime.Now.ToUniversalTime();
        }

        public NewsPostViewModel(AnnouncementDetail source) :base()
        {
            Id = source.No;
            StartTime = (source.StartDate.HasValue)?source.StartDate.Value: new DateTime(1900,1,1);
            EndTime = (source.EndDate.HasValue) ? source.EndDate.Value : new DateTime(1900, 1, 1);
            Caption = source.Title;
            Content = source.Detail;
            IsTop = source.ToTop;
            LastUpdateUTCTime = (source.LastUpdate.HasValue)? source.LastUpdate.Value: new DateTime(1900,1,1);
        }
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

        public int Body_Id { get; set; }
        [Display(Name = "公告內容")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "版本號")]
        public int Version { get; set; }

        [Required]
        [Display(Name ="置頂")]
        public bool IsTop { get; set; }
    }
}