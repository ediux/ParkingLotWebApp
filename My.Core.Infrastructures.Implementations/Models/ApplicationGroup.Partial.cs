namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ApplicationGroupMetaData))]
    public partial class ApplicationGroup
    {
    }
    
    public partial class ApplicationGroupMetaData
    {
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "GroupName", ResourceType = typeof(MUI))]
        public string Name { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        public bool Void { get; set; }
        [Display(Name = "CreateUserId", ResourceType = typeof(MUI))]
        [Required]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateTime { get; set; }
    
        public virtual ICollection<ApplicationGroupTree> ApplicationGroupTree { get; set; }
        public virtual ICollection<ApplicationGroupTree> ApplicationGroupTree1 { get; set; }
        public virtual ICollection<ApplicationGroupTree> ApplicationGroupTree2 { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUserGroup { get; set; }
    }
}
