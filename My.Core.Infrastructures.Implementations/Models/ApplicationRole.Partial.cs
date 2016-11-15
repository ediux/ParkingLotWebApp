namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [MetadataType(typeof(ApplicationRoleMetaData))]
    public partial class ApplicationRole
    {
    }

    public partial class ApplicationRoleMetaData
    {
        [Required]
        public int Id { get; set; }

        [Index]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "RoleName", ResourceType = typeof(MUI))]
        public string Name { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        public bool Void { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        [Display(Name = "CreateUserId", ResourceType = typeof(MUI))]
        public int CreateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "CreateTime", ResourceType = typeof(MUI))]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(MUI))]
        public int LastUpdateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        public System.DateTime LastUpdateTime { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
