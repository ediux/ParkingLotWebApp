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

        IApplicationUserRoleRepository userrolerepo;


        public OpenCoreWebUserStore(DbContext context)
        {
            userrolerepo = RepositoryHelper.GetApplicationUserRoleRepository();
            userrolerepo.UnitOfWork.Context = context;
            userrolerepo.UnitOfWork.ConnectionString = context.Database.Connection.ConnectionString;
        }

        #region 使用者
        public async Task CreateAsync(ApplicationUser user)
        {
            user = userrolerepo.ApplicationUserRepository.Add(user);

            if (Roles.SingleOrDefault(s => s.Name == "Users") != null)
            {
                await AddToRoleAsync(user, "Users");
                throw new Exception("Users Role is not existed.");
            }          
            await userrolerepo.UnitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            user.Void = true;
            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
        }

        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return await userrolerepo.ApplicationUserRepository.FindUserByIdAsync(userId, false);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await userrolerepo.ApplicationUserRepository.FindUserByLoginAccountAsync(userName, false);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            var oriuser = userrolerepo.ApplicationUserRepository.Get(user.Id);
            var pwdhasher = new PasswordHasher();

            if (!string.IsNullOrEmpty(user.Password) || oriuser.PasswordHash != user.PasswordHash)
            {
                user.PasswordHash = pwdhasher.HashPassword(user.Password ?? "");

                if (oriuser.PasswordHash != user.PasswordHash)
                {
                    oriuser.Password = string.Empty;
                    oriuser.PasswordHash = user.PasswordHash;

                }
            }


            oriuser.UserName = user.UserName;
            oriuser.DisplayName = user.DisplayName;
            oriuser.Address = user.Address;
            oriuser.EMail = user.EMail;
            oriuser.EMailConfirmed = false;
            oriuser.LastUpdateTime = DateTime.UtcNow;
            
            if (user.TwoFactorEnabled)
            {
                oriuser.PhoneNumber = user.PhoneNumber;
                oriuser.PhoneConfirmed = false;
            }

            userrolerepo.UnitOfWork.Context.Entry(oriuser).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
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
            int roleid = userrolerepo.ApplicationRoleRepository.FindByName(roleName).Id;
            userrolerepo.Add(new ApplicationUserRole() { UserId = user.Id, RoleId = roleid, Void = false });
            await userrolerepo.UnitOfWork.CommitAsync();
        }

        public Task<System.Collections.Generic.IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return Task<System.Collections.Generic.IList<string>>.Run(() =>
            {
                var roles = from q in user.ApplicationUserRole
                            select q.ApplicationRole.Name;

                return (System.Collections.Generic.IList<string>)roles.ToList();
            });
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            return Task<bool>.Run(() =>
            {
                var userinroles = from q in user.ApplicationUserRole
                                  where q.ApplicationRole.Name.Equals(roleName, StringComparison.InvariantCultureIgnoreCase)
                                  select q;
                return userinroles.Any();
            });
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            var role = userrolerepo.ApplicationRoleRepository.FindByName(roleName);

            if (role == null)
            {
                throw new ArgumentException(string.Format("Role {0} not existed.", roleName), "roleName");
            }

            if (user == null)
                throw new ArgumentNullException("user");

            var r = userrolerepo.Get(user.Id, role.Id);
            userrolerepo.Delete(r);
            await userrolerepo.UnitOfWork.CommitAsync();
        }
        #endregion

        #region EMail Stroe
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var findemail = await userrolerepo
                .ApplicationUserRepository
                .FindByEmailAsync(email);
            return findemail;
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                try
                {
                    return user.EMail;
                }
                catch (Exception)
                {
                    return string.Empty;
                }

            });
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            return Task<bool>.Run(() =>
            {
                return user.EMailConfirmed;
            });
        }

        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            //userrolerepo.ApplicationUserRepository.ApplicationUserProfileRefRepository.UserProfileRepository.
            return Task.Run(() =>
            {
                user.EMail = email;
                user.LastUpdateTime = DateTime.Now.ToUniversalTime();
                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            return Task.Run(() =>
            {

                user.EMailConfirmed = confirmed;
                user.LastUpdateTime = DateTime.Now.ToUniversalTime();
                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }
        #endregion

        #region Lockout Store
        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return Task<int>.Run(() =>
            {
                return user.AccessFailedCount;
            });
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return Task<bool>.Run(() =>
            {
                return user.LockoutEnabled.HasValue ? user.LockoutEnabled.Value : false;
            });
        }

        public Task<System.DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            return Task<System.DateTimeOffset>.Run(() =>
            {
                return user.LockoutEndDate.HasValue ? user.LockoutEndDate.Value : new System.DateTimeOffset(new DateTime(1754, 1, 1).ToUniversalTime());
            });
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            return Task<int>.Run(() =>
            {
                user.AccessFailedCount += 1;
                user.LastActivityTime = DateTime.Now;
                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
                user = userrolerepo.ApplicationUserRepository.Reload(user);

                return user.AccessFailedCount;
            });
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                user.AccessFailedCount = 0;
                user.LastActivityTime = DateTime.Now;

                user.LockoutEnabled = false;
                user.LockoutEndDate = DateTime.Now;
                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            return Task.Run(() =>
            {
                user.AccessFailedCount = 0;
                user.LastActivityTime = DateTime.Now;
                user.LastUpdateUserId = user.Id;
                user.LockoutEnabled = enabled;

                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, System.DateTimeOffset lockoutEnd)
        {
            return Task.Run(() =>
            {
                user.AccessFailedCount = 0;
                user.LastActivityTime = DateTime.Now;

                user.LockoutEndDate = new DateTime(lockoutEnd.Ticks);
                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }
        #endregion

        #region Login Store
        public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            return Task.Run(() =>
            {
                user.ApplicationUserLogin.Add(new ApplicationUserLogin()
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey,
                    UserId = user.Id
                });

                userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
                userrolerepo.UnitOfWork.Commit();
            });
        }

        public Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                var founduser = from q in userrolerepo.ApplicationUserRepository.All()
                                from l in q.ApplicationUserLogin
                                where l.LoginProvider == login.LoginProvider
                                && l.ProviderKey == login.ProviderKey
                                select q;

                return founduser.SingleOrDefault();
            });
        }

        public Task<System.Collections.Generic.IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            return Task<System.Collections.Generic.IList<UserLoginInfo>>.Run(() =>
            {
                var founduser = from q in userrolerepo.ApplicationUserRepository.All()
                                from l in q.ApplicationUserLogin
                                select l;

                return (System.Collections.Generic.IList<UserLoginInfo>)(founduser.ToList()
                    .ConvertAll(c => new UserLoginInfo(c.LoginProvider, c.ProviderKey)));
            });
        }

        public async Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            var foundlogininfo = (from q in user.ApplicationUserLogin
                                  where q.LoginProvider == login.LoginProvider
                                  && q.ProviderKey == login.ProviderKey
                                  select q).Single();

            user.ApplicationUserLogin.Remove(foundlogininfo);
            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();

        }
        #endregion

        #region Password Store
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task<string>.Run(() =>
            {
                return user.PasswordHash;
            });
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task<bool>.Run(() =>
            {
                if (!string.IsNullOrEmpty(user.Password))
                    return true;
                if (!string.IsNullOrEmpty(user.PasswordHash))
                    return true;
                return false;
            });
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            user.LastActivityTime = user.LastUpdateTime = DateTime.Now.ToUniversalTime();
            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();

        }
        #endregion

        #region Phone Number Store
        public Task<string> GetPhoneNumberAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                return user.PhoneNumber;
            });
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user)
        {
            return Task<bool>.Run(() =>
            {
                return user.PhoneConfirmed;
            });
        }

        public async Task SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
        {
            var profile = user;

            profile.PhoneNumber = phoneNumber;
            profile.PhoneConfirmed = true;

            if (GetTwoFactorEnabledAsync(user).Result)
                profile.PhoneConfirmed = false;

            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();

        }

        public async Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            var profile = user;

            profile.PhoneConfirmed = confirmed;

            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();


        }
        #endregion

        #region Security Stamp Store
        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                return user.SecurityStamp;
            });
        }

        public async Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
        }
        #endregion

        #region TwoFactor
        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return Task<bool>.Run(() =>
            {
                return user.TwoFactorEnabled;
            });
        }

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
        }
        #endregion

        #region Role Store
        public async Task CreateAsync(ApplicationRole role)
        {
            userrolerepo.ApplicationRoleRepository.Add(role);
            await userrolerepo.UnitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(ApplicationRole role)
        {
            role.Void = true;
            await UpdateAsync(role);
        }

        Task<ApplicationRole> IRoleStore<ApplicationRole, int>.FindByIdAsync(int roleId)
        {
            return Task<ApplicationRole>.Run(() =>
            {
                return userrolerepo.ApplicationRoleRepository.FindById(roleId);
            });
        }

        Task<ApplicationRole> IRoleStore<ApplicationRole, int>.FindByNameAsync(string roleName)
        {
            return Task<ApplicationRole>.Run(() =>
            {
                return userrolerepo.ApplicationRoleRepository.FindByName(roleName);
            });
        }

        public async Task UpdateAsync(ApplicationRole role)
        {
            userrolerepo.UnitOfWork.Context.Entry(role).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
        }
        #endregion

        #region 可用來查詢的使用者清單屬性
        public System.Linq.IQueryable<ApplicationUser> Users
        {
            get { return userrolerepo.ApplicationUserRepository.All(); }
        }
        #endregion

        #region 可用來查詢的角色清單
        public System.Linq.IQueryable<ApplicationRole> Roles
        {
            get { return userrolerepo.ApplicationRoleRepository.All(); }
        }
        #endregion

        public async Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            user.ApplicationUserClaim.Add(new ApplicationUserClaim()
            {
                ClaimType = claim.ValueType,
                ClaimValue = claim.Value,
                UserId = user.Id
            });

            userrolerepo.UnitOfWork.Context.Entry(user).State = EntityState.Modified;
            await userrolerepo.UnitOfWork.CommitAsync();
        }

        public Task<System.Collections.Generic.IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            return Task<System.Collections.Generic.IList<Claim>>.Run(() =>
            {
                return user.ApplicationUserClaim.ToList().ConvertAll<Claim>(c => new Claim(c.ClaimType, c.ClaimValue)) as System.Collections.Generic.IList<Claim>;
            });
        }

        public Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            return Task.Run(() =>
            {

            });
        }
    }
}