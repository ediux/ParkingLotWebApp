namespace ParkingLotWebApp.Models
{
    using My.Core.Infrastructures.Implementations.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ParkingLotsDetailMetaData))]
    public partial class ParkingLotsDetail
    {
    }
    
    public partial class ParkingLotsDetailMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        [Display(Name="區域名稱")]
        public string Name { get; set; }
        
        [StringLength(75, ErrorMessage="欄位長度不得大於 75 個字元")]
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        [Display(Name = "電話")]
        public string Tel { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        [Display(Name = "可停時間")]
        public string Period { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        [Display(Name = "收費說明")]
        public string Charge { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        [Display(Name = "Void",ResourceType =typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Display(Name="最後更新時間")]
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> AreaID { get; set; }
    
        public virtual ParkingArea ParkingArea { get; set; }
        public virtual ICollection<ParkingLotsFloor> ParkingLotsFloor { get; set; }
    }
}
