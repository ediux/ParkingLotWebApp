namespace My.Core.Infrastructures.Implementations.Models
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ApplicationRoleMetaData))]
    public partial class ApplicationRole : IRole<int>
    {
        public static ApplicationRole Create()
        {
            return new ApplicationRole()
            {
                Id = -1,
                CreateTime = DateTime.Now.ToUniversalTime(),
                CreateUserId = -1,
                LastUpdateTime = DateTime.Now.ToUniversalTime(),
                LastUpdateUserId = -1,
                Name = string.Empty,
                ApplicationUserRole = new Collection<ApplicationUserRole>(),
            };
        }
    }

    public partial class ApplicationRoleMetaData
    {
        [Display(Name="Id", ResourceType = typeof(Resources.MUI))]
        [Required]
        public int Id { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(Resources.MUI))]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "CreateUserId", ResourceType = typeof(Resources.MUI))]
        [Required]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(Resources.MUI))]
        [DisplayFormat(DataFormatString="{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(Resources.MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(Resources.MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateTime { get; set; }
        [UIHint("VoidDisplay")]
        [Required]
        [Display(Name = "Void", ResourceType = typeof(Resources.MUI))]
        public bool Void { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
