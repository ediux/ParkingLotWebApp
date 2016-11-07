namespace My.Core.Infrastructures.Implementations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ApplicationRoleMetaData))]
    public partial class ApplicationRole
    {
    }
    
    public partial class ApplicationRoleMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateTime { get; set; }
    
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
