namespace My.Core.Infrastructures.Implementations.Models
{
    using Microsoft.AspNet.Identity;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [MetadataType(typeof(ApplicationUserMetaData))]
    public partial class ApplicationUser : IUser<int>
    {

        public static ApplicationUser Create()
        {
            return new ApplicationUser()
            {
                Id = -1,
                AccessFailedCount = 0,
                ApplicationUserClaim = new Collection<ApplicationUserClaim>(),
                ApplicationUserGroup = new Collection<ApplicationUserGroup>(),
                ApplicationUserLogin = new Collection<ApplicationUserLogin>(),
                ApplicationUserProfileRef = new Collection<ApplicationUserProfileRef>(),
                ApplicationUserRole = new Collection<ApplicationUserRole>(),
                CreateTime = DateTime.Now.ToUniversalTime(),
                CreateUserId = -1,
                LastActivityTime = DateTime.Now.ToUniversalTime(),
                LastUpdateTime = DateTime.Now.ToUniversalTime(),
                LastUpdateUserId = -1,
                Password = string.Empty,
                PasswordHash = string.Empty,
                LockoutEnabled = false,
                ResetPasswordToken = string.Empty,
                SecurityStamp = string.Empty,
                TwoFactorEnabled = false,
                UserName = string.Empty,
                Void = false,
                UserOperationLog = new Collection<UserOperationLog>()
            };
        }

        public static ApplicationUser CreateKernelUser()
        {
            return new ApplicationUser()
            {
                Id = -1,
                AccessFailedCount = 0,
                ApplicationUserClaim = new Collection<ApplicationUserClaim>(),
                ApplicationUserGroup = new Collection<ApplicationUserGroup>(),
                ApplicationUserLogin = new Collection<ApplicationUserLogin>(),
                ApplicationUserProfileRef = new Collection<ApplicationUserProfileRef>(),
                ApplicationUserRole = new Collection<ApplicationUserRole>(),
                CreateTime = DateTime.Now.ToUniversalTime(),
                CreateUserId = -1,
                LastActivityTime = DateTime.Now.ToUniversalTime(),
                LastUpdateTime = DateTime.Now.ToUniversalTime(),
                LastUpdateUserId = -1,
                Password = string.Empty,
                PasswordHash = string.Empty,
                LockoutEnabled = false,
                ResetPasswordToken = string.Empty,
                SecurityStamp = string.Empty,
                TwoFactorEnabled = false,
                UserName = "System",
                Void = false,
                UserOperationLog = new Collection<UserOperationLog>()
            };
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;

        }
    }

    public partial class ApplicationUserMetaData
    {
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        [Required]
        public int Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(MUI))]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Password", ResourceType = typeof(MUI))]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "StringLength")]
        public string Password { get; set; }
        [Display(Name = "PasswordHash", ResourceType = typeof(MUI))]
        public string PasswordHash { get; set; }
        [Display(Name = "SecurityStamp", ResourceType = typeof(MUI))]
        public string SecurityStamp { get; set; }
        [Required]
        [Display(Name = "TwoFactorEnabled", ResourceType = typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool TwoFactorEnabled { get; set; }
        [Required]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "CreateUserId", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(MUI))]
        public System.DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public System.DateTime LastUpdateTime { get; set; }
        [Display(Name = "LastActivityTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public Nullable<System.DateTime> LastActivityTime { get; set; }
        [Display(Name = "LastUnlockedTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public Nullable<System.DateTime> LastUnlockedTime { get; set; }
        [Display(Name = "LastLoginFailTime", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        public Nullable<System.DateTime> LastLoginFailTime { get; set; }
        [Required]
        [Display(Name = "AccessFailedCount", ResourceType = typeof(MUI))]
        public int AccessFailedCount { get; set; }
        [Display(Name = "LockoutEnabled", ResourceType = typeof(MUI))]
        [UIHint("LockedStateDisplay")]
        public Nullable<bool> LockoutEnabled { get; set; }
        [Display(Name = "LockoutEndDate", ResourceType = typeof(MUI))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<System.DateTime> LockoutEndDate { get; set; }
        [Display(Name = "ResetPasswordToken", ResourceType = typeof(MUI))]
        [StringLength(512, ErrorMessage = "欄位長度不得大於 512 個字元")]
        public string ResetPasswordToken { get; set; }

        public virtual ICollection<ApplicationUserGroup> ApplicationUserGroup { get; set; }
        public virtual ICollection<ApplicationUserProfileRef> ApplicationUserProfileRef { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual ICollection<UserOperationLog> UserOperationLog { get; set; }
        public virtual ApplicationUserClaim ApplicationUserClaim { get; set; }
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogin { get; set; }
    }
}
