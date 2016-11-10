namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ApplicationUserMetaData))]
    public partial class ApplicationUser
    {
    }
    
    public partial class ApplicationUserMetaData
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(Resources.MUI))]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources.MUI))]
        public string UserName { get; set; }
        [Display(Name = "Password", ResourceType = typeof(Resources.MUI))]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "PasswordHash", ResourceType = typeof(Resources.MUI))]
        public string PasswordHash { get; set; }
        [Display(Name = "SecurityStamp", ResourceType = typeof(Resources.MUI))]
        public string SecurityStamp { get; set; }
        [Required]
        [Display(Name = "TwoFactorEnabled", ResourceType = typeof(Resources.MUI))]
        [UIHint("EnabledDisplay")]
        public bool TwoFactorEnabled { get; set; }
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(Resources.MUI))]
        [Required]
        public bool Void { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "DisplayName", ResourceType = typeof(Resources.MUI))]
        public string DisplayName { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [EmailAddress]
        [Display(Name = "EMail", ResourceType = typeof(Resources.MUI))]
        public string EMail { get; set; }

        [Required]
        [Display(Name = "EMailConfirmed", ResourceType = typeof(Resources.MUI))]
        [UIHint("EnabledDisplay")]
        public bool EMailConfirmed { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.MUI))]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "PhoneConfirmed", ResourceType = typeof(Resources.MUI))]
        [UIHint("EnabledDisplay")]
        public bool PhoneConfirmed { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        [Display(Name = "CreateUserId", ResourceType = typeof(Resources.MUI))]
        public int CreateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "CreateTime", ResourceType = typeof(Resources.MUI))]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [UIHint("UserIDMappingDisplay")]
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(Resources.MUI))]
        public int LastUpdateUserId { get; set; }
        [Required]
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(Resources.MUI))]
        public System.DateTime LastUpdateTime { get; set; }
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastActivityTime", ResourceType = typeof(Resources.MUI))]
        public Nullable<System.DateTime> LastActivityTime { get; set; }
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastUnlockedTime", ResourceType = typeof(Resources.MUI))]
        public Nullable<System.DateTime> LastUnlockedTime { get; set; }
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastLoginFailTime", ResourceType = typeof(Resources.MUI))]
        public Nullable<System.DateTime> LastLoginFailTime { get; set; }
        [Required]
        [Display(Name = "AccessFailedCount", ResourceType = typeof(Resources.MUI))]
        public int AccessFailedCount { get; set; }

        [Display(Name = "LockoutEnabled", ResourceType = typeof(Resources.MUI))]
        [UIHint("EnabledDisplay")]
        public Nullable<bool> LockoutEnabled { get; set; }

        [Display(Name = "LockoutEndDate", ResourceType = typeof(Resources.MUI))]
        [UIHint("UTCLocalDateDisplay")]
 
        public Nullable<System.DateTime> LockoutEndDate { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Display(Name = "ResetPasswordToken", ResourceType = typeof(Resources.MUI))]
        [UIHint("Token")]
        public string ResetPasswordToken { get; set; }
    
        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaim { get; set; }
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        public virtual ICollection<ApplicationRole> ApplicationRole { get; set; }
    }
}
