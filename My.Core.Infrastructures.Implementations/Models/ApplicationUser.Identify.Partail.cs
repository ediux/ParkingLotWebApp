using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class ApplicationUser : IUser<int>
    {
        public static ApplicationUser Create()
        {
            return new ApplicationUser()
            {
                Id = -1,
                AccessFailedCount = 0,
                ApplicationUserClaim = new Collection<ApplicationUserClaim>(),
                ApplicationUserLogin = new Collection<ApplicationUserLogin>(),
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
                Void = false
            };
        }

        public static ApplicationUser CreateKernelUser()
        {
            return new ApplicationUser()
            {
                Id = -1,
                AccessFailedCount = 0,
                ApplicationUserClaim = new Collection<ApplicationUserClaim>(),
                ApplicationUserLogin = new Collection<ApplicationUserLogin>(),
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
                Void = false
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
}
