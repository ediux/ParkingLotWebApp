namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ApplicationUserProfileMetaData))]
    public partial class ApplicationUserProfile
    {
    }
    
    public partial class ApplicationUserProfileMetaData
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.MUI))]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Address", ResourceType = typeof(Resources.MUI))]
        public string Address { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        [Display(Name = "EMail", ResourceType = typeof(Resources.MUI))]
        public string EMail { get; set; }
        [Required]
        [Display(Name = "EMailConfirmed", ResourceType = typeof(Resources.MUI))]
        public bool EMailConfirmed { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.MUI))]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "PhoneConfirmed", ResourceType = typeof(Resources.MUI))]
        public bool PhoneConfirmed { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(Resources.MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(Resources.MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateTime { get; set; }

        [Display(Name = "DisplayName", ResourceType = typeof(Resources.MUI))]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string DisplayName { get; set; }
    
        public virtual ICollection<ApplicationUserProfileRef> ApplicationUserProfileRef { get; set; }
    }
}
