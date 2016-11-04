namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(AnnouncementDetailMetaData))]
    public partial class AnnouncementDetail
    {
    }
    
    public partial class AnnouncementDetailMetaData
    {
        [Required]
        public int No { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        
        [StringLength(1000, ErrorMessage="欄位長度不得大於 1000 個字元")]
        [Required]
        public string Detail { get; set; }
        [Required]
        public bool ToTop { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
