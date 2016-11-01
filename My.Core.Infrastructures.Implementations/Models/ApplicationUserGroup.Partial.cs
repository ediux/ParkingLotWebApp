namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ApplicationUserGroupMetaData))]
    public partial class ApplicationUserGroup
    {
    }

    public partial class ApplicationUserGroupMetaData
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources.MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "GroupName", ResourceType = typeof(Resources.MUI))]
        [UIHint("GroupIDMappingDisplay")]
        public int GroupId { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(Resources.MUI))]
        public bool Void { get; set; }

        public virtual ApplicationGroup ApplicationGroup { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
