namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ApplicationUserProfileRefMetaData))]
    public partial class ApplicationUserProfileRef
    {
    }
    
    public partial class ApplicationUserProfileRefMetaData
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "ProfileId", ResourceType = typeof(MUI))]
        public int ProfileId { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateTime { get; set; }
    
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationUserProfile ApplicationUserProfile { get; set; }
    }
}
