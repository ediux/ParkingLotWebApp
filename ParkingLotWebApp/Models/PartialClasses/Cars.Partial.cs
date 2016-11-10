using My.Core.Infrastructures.Implementations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    /// <summary>
    /// 車輛紀錄
    /// </summary>
    public partial class Cars
    {
        public static Cars Create(int UserId)
        {
            var model = new Cars()
            {
                CarNumber = string.Empty,
                CarPurposeTypeID = 0,
                CarType = "C",
                EmpId = null,
                ETCsID = null,
                Id = 0,
                Void = false
            };
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
    }

    public partial class CarsMetaData
    {
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "車號")]
        public string CarNumber { get; set; }

        [StringLength(1, ErrorMessage = "欄位長度不得大於 1 個字元")]
        [Required]
        [Display(Name = "車種")]
        [UIHint("CarTypeDisplay")]
        public string CarType { get; set; }

        [Display(Name = "員工資料識別碼")]
        public Nullable<int> EmpId { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
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

    }
}