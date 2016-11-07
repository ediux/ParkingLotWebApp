namespace ParkingLotWebApp.Models
{
    using My.Core.Infrastructures.Implementations.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CarPurposeTypesMetaData))]
    public partial class CarPurposeTypes
    {
    }
    
    public partial class CarPurposeTypesMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name="用途")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Void",ResourceType = typeof(MUI))]
        public bool Void { get; set; }
    
        public virtual ICollection<Cars> Cars { get; set; }
    }
}
