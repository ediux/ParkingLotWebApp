using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Linq;
using My.Core.Infrastructures.Implementations.Models;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using My.Core.Infrastructures.DAL;
using My.Core.Infrastructures.Implementations;
using My.Core.Infrastructures;

namespace My.Core.Infrastructures.Implementations.Models
{
    // 您可以在 ApplicationUser 類別新增更多屬性，為使用者新增設定檔資料，請造訪 http://go.microsoft.com/fwlink/?LinkID=317594 以深入了解。

    public class OpenCoreWebUserStore : IUserStore<ApplicationUser, int>
        , IUserRoleStore<ApplicationUser, int>, IRoleStore<ApplicationRole, int>
        , IUserEmailStore<ApplicationUser, int>, IUserLockoutStore<ApplicationUser, int>
        , IUserLoginStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>
        , IUserPhoneNumberStore<ApplicationUser, int>, IUserSecurityStampStore<ApplicationUser, int>
        , IUserTwoFactorStore<ApplicationUser, int>, IUserClaimStore<ApplicationUser, int>
        , IQueryableUserStore<ApplicationUser, int>, IQueryableRoleStore<ApplicationRole, int>
    {

        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private IApplicationUserRepository userRepo;
        private IApplicationRoleRepository roleRepo;
        private IApplicationUserLoginRepository userloginRepo;

        private const string DefaultAdminsRoleName = "Admins";
        private const string DefaultUserRoleName = "Users";

        public OpenCoreWebUserStore(DbContext context)
        {
            userRepo = RepositoryHelper.GetApplicationUserRepository();
            roleRepo = RepositoryHelper.GetApplicationRoleRepository(userRepo.UnitOfWork);
            userloginRepo = RepositoryHelper.GetApplicationUserLoginRepository(userRepo.UnitOfWork);
        }

        #region 使用者
        public async Task CreateAsync(ApplicationUser user)
        {
            user = userRepo.Add(user);
            var role = roleRepo.FindByName("Users");

            if (role != null)
            {
                user.ApplicationRole.Add(role);
                //throw new Exception("Users Role is not existed.");
            }
            await userRepo.UnitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            user.Void = true;
            await UpdateAsync(user);
        }

        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return await userRepo.FindUserByIdAsync(userId, false);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await userRepo.FindUserByLoginAccountAsync(userName, false);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            user.LastActivityTime = DateTime.UtcNow;
            userRepo.Update(user);
            await userRepo.UnitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        #endregion

        #region User Role Store
        public async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }
            ApplicationRole role = roleRepo.FindByName(roleName);
            if (role == null)
            {
                throw new ArgumentException(string.Format("Role '{0}' does not exist!", roleName), "roleName");
            }
            user.ApplicationRole.Add(role);
            await UpdateAsync(role);
        }

        public Task<System.Collections.Generic.IList<string>> GetRolesAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.Run(() =>
            {
                var roles = from q in user.ApplicationRole
                            select q.Name;

                return roles.ToList() as System.Collections.Generic.IList<string>;
            });
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.Run(() =>
            {
                return user.ApplicationRole.Any(p => p.Name.Equals(roleName, StringComparison.InvariantCultureIgnoreCase));
            });
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            var role = user.ApplicationRole.SingleOrDefault(p => p.Name == roleName);

            if (role == null)
            {
                throw new ArgumentException(string.Format("User '{0}' does not exist in role '{1}'!", user.UserName, roleName), "roleName");
            }

            user.ApplicationRole.Remove(role);
            await UpdateAsync(user);
        }
        #endregion

        #region EMail Stroe
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var findemail = await userRepo
                .FindByEmailAsync(email);
            return findemail;
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.EMail);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.EMailConfirmed);
        }

        public async Task SetEmailAsync(ApplicationUser user, string email)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.EMail = email;
            await SetEmailConfirmedAsync(user, true);
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.EMailConfirmed = confirmed;
            user.LastUpdateTime = DateTime.Now.ToUniversalTime();
            await UpdateAsync(user);
        }
        #endregion

        #region Lockout Store
        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.LockoutEnabled ?? false);
        }

        public Task<System.DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }
            return Task.FromResult(user.LockoutEndDate ?? new System.DateTimeOffset(new DateTime(1754, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.AccessFailedCount += 1;
            await UpdateAsync(user);
            user = userRepo.Reload(user);

            return user.AccessFailedCount;

        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.AccessFailedCount = 0;
            user.LastActivityTime = DateTime.Now;

            user.LockoutEnabled = false;
            user.LockoutEndDate = DateTime.Now;
            await UpdateAsync(user);

        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }
            user.AccessFailedCount = 0;
            user.LastActivityTime = DateTime.Now;
            user.LastUpdateUserId = user.Id;
            user.LockoutEnabled = enabled;

            await UpdateAsync(user);

        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, System.DateTimeOffset lockoutEnd)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.AccessFailedCount = 0;
            user.LastActivityTime = DateTime.Now;

            user.LockoutEndDate = new DateTime(lockoutEnd.Ticks);

            await UpdateAsync(user);

        }
        #endregion

        #region Login Store
        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            if (login == null)
            {
                throw new NullReferenceException("The variable login can not be null!");
            }
            user.ApplicationUserLogin.Add(new ApplicationUserLogin()
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                UserId = user.Id
            });

            await UpdateAsync(user);
        }

        public Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new NullReferenceException("The variable login can not be null!");
            }

            ApplicationUserLogin founduserlogin = userloginRepo.Get(login.LoginProvider, login.ProviderKey);

            if (founduserlogin == null)
            {
                throw new Exception(string.Format("Can not find user for external sign-in provider '{0}'!", login.LoginProvider));
            }

            return Task.FromResult(founduserlogin.ApplicationUser);
        }

        public Task<System.Collections.Generic.IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }


            return Task.FromResult(user.ApplicationUserLogin
                .ToList()
                .ConvertAll(c=>new UserLoginInfo(c.LoginProvider,c.ProviderKey))
                as System.Collections.Generic.IList<UserLoginInfo>);

        }

        public async Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            if (login == null)
            {
                throw new NullReferenceException("The variable login can not be null!");
            }


            var foundlogininfo = user.ApplicationUserLogin.SingleOrDefault(q =>
                     q.LoginProvider == login.LoginProvider
                                  && q.ProviderKey == login.ProviderKey);

            if (foundlogininfo == null)
            {
                throw new Exception(string.Format("Can not remove user '{0}' from external sign-in provider '{1}'!",
                    user.UserName,
                    login.LoginProvider
                    ));
            }

            user.ApplicationUserLogin.Remove(foundlogininfo);

            await UpdateAsync(user);

        }
        #endregion

        #region Password Store
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            if (!string.IsNullOrEmpty(user.Password))
                return Task.FromResult(true);
            if (!string.IsNullOrEmpty(user.PasswordHash))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.PasswordHash = passwordHash;
            user.LastActivityTime = user.LastUpdateTime = DateTime.Now.ToUniversalTime();
            await UpdateAsync(user);

        }
        #endregion

        #region Phone Number Store
        public Task<string> GetPhoneNumberAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.PhoneConfirmed);

        }

        public async Task SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            var profile = user;

            profile.PhoneNumber = phoneNumber;
            profile.PhoneConfirmed = true;

            if (GetTwoFactorEnabledAsync(user).Result)
                profile.PhoneConfirmed = false;

            await UpdateAsync(user);

        }

        public async Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            var profile = user;

            profile.PhoneConfirmed = confirmed;

            await UpdateAsync(user);


        }
        #endregion

        #region Security Stamp Store
        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.SecurityStamp);
        }

        public async Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.SecurityStamp = stamp;
            await UpdateAsync(user);
        }
        #endregion

        #region TwoFactor
        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.FromResult(user.TwoFactorEnabled);
        }

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            user.TwoFactorEnabled = enabled;
            await UpdateAsync(user);
        }
        #endregion

        #region Role Store
        public async Task CreateAsync(ApplicationRole role)
        {
            if (role == null)
            {
                throw new NullReferenceException("The variable role can not be null!");
            }

            roleRepo.Add(role);
            await UpdateAsync(role);
        }

        public async Task DeleteAsync(ApplicationRole role)
        {
            if (role == null)
            {
                throw new NullReferenceException("The variable role can not be null!");
            }

            role.Void = true;
            roleRepo.UnitOfWork.Context.Entry(role).State = EntityState.Modified;
            await UpdateAsync(role);
        }

        Task<ApplicationRole> IRoleStore<ApplicationRole, int>.FindByIdAsync(int roleId)
        {
            return Task.Run(() =>
            {
                return roleRepo.FindById(roleId);
            });
        }

        Task<ApplicationRole> IRoleStore<ApplicationRole, int>.FindByNameAsync(string roleName)
        {
            return Task.Run(() =>
            {
                return roleRepo.FindByName(roleName);
            });
        }

        public async Task UpdateAsync(ApplicationRole role)
        {
            if (role == null)
            {
                throw new NullReferenceException("The variable role can not be null!");
            }

            roleRepo.UnitOfWork.Context.Entry(role).State = EntityState.Modified;
            await roleRepo.UnitOfWork.CommitAsync();
        }
        #endregion

        #region 可用來查詢的使用者清單屬性
        public System.Linq.IQueryable<ApplicationUser> Users
        {
            get { return userRepo.All(); }
        }
        #endregion

        #region 可用來查詢的角色清單
        public System.Linq.IQueryable<ApplicationRole> Roles
        {
            get { return roleRepo.All(); }
        }
        #endregion

        public async Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            if (claim == null)
            {
                throw new NullReferenceException("The variable claim can not be null!");
            }

            user.ApplicationUserClaim.Add(new ApplicationUserClaim()
            {
                ClaimType = claim.ValueType,
                ClaimValue = claim.Value,
                UserId = user.Id
            });

            userRepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userRepo.UnitOfWork.CommitAsync();
        }

        public Task<System.Collections.Generic.IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }

            return Task.Run(() =>
            {
                return user.ApplicationUserClaim.ToList().ConvertAll<Claim>(c => new Claim(c.ClaimType, c.ClaimValue)) as System.Collections.Generic.IList<Claim>;
            });
        }

        public async Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            if (user == null)
            {
                throw new NullReferenceException("The variable user can not be null!");
            }
            if (claim == null)
            {
                throw new NullReferenceException("The variable claim can not be null!");
            }

            ApplicationUserClaim userclaim = user.ApplicationUserClaim.SingleOrDefault(s => s.ClaimType == claim.ValueType
              && s.ClaimValue == claim.Value);

            if (userclaim == null)
            {
                throw new Exception(string.Format("ClaimType '{0}' not found.", claim.ValueType));
            }

            user.ApplicationUserClaim.Remove(userclaim);
            await UpdateAsync(user);
        }
    }
}