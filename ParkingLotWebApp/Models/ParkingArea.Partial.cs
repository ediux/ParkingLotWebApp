namespace ParkingLotWebApp.Models
{
    using My.Core.Infrastructures.Implementations.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ParkingAreaMetaData))]
    public partial class ParkingArea
    {
    }
    
    public partial class ParkingAreaMetaData
    {
        [Required]
        [Display(Name = "區域代碼")]
        public int AreaId { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        [Display(Name = "區域名稱")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Void",ResourceType =typeof(MUI))]
        public bool Void { get; set; }
    
        public virtual ICollection<ParkingLotsDetail> ParkingLotsDetail { get; set; }
    }
}
