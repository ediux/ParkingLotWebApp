using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ParkingLotWebApp.Models;
using My.Core.Infrastructures.Implementations;
using My.Core.Infrastructures.Implementations.Models;
using My.Core.Infrastructures.Implementations.Base;
using PagedList;
using System.Net;

namespace ParkingLotWebApp.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? new ApplicationRoleManager(new OpenCoreWebUserStore(OpenWebSiteEntities.Create()));
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "已變更您的密碼。"
                : message == ManageMessageId.SetPasswordSuccess ? "已設定您的密碼。"
                : message == ManageMessageId.SetTwoFactorSuccess ? "已設定您的雙因素驗證。"
                : message == ManageMessageId.Error ? "發生錯誤。"
                : message == ManageMessageId.AddPhoneSuccess ? "已新增您的電話號碼。"
                : message == ManageMessageId.RemovePhoneSuccess ? "已移除您的電話號碼。"
                : "";

            var userId = User.Identity.GetUserId<int>();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId<int>(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // 產生並傳送 Token
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId<int>(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "您的安全碼為: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId<int>(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId<int>(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId<int>(), phoneNumber);
            // 透過 SMS 提供者傳送 SMS，以驗證電話號碼
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId<int>(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // 如果執行到這裡，發生某項失敗，則重新顯示表單
            ModelState.AddModelError("", "無法驗證號碼");
            return View(model);
        }

        //
        // GET: /Manage/RemovePhoneNumber
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId<int>(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId<int>(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId<int>(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // 如果執行到這裡，發生某項失敗，則重新顯示表單
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "已移除外部登入。"
                : message == ManageMessageId.Error ? "發生錯誤。"
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId<int>());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // 要求重新導向至外部登入提供者，以連結目前使用者的登入
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId<int>(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        public ActionResult RegisterUserInAdminsMode()
        {
            ViewBag.RoleId = new SelectList(RoleManager.Roles.Where(w => w.Void == false), "Id", "Name");
            return View(new RegisterForAdminsViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUserInAdminsMode(RegisterForAdminsViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = ApplicationUser.Create();
                user.UserName = registerViewModel.UserName;
                user.DisplayName = registerViewModel.DisplayName;
                user.EMail = registerViewModel.Email;
                user.Password = string.Empty;
                user.PasswordHash = UserManager.PasswordHasher.HashPassword(registerViewModel.Password);

                IdentityResult result = UserManager.Create(user);
                if (result.Succeeded)
                {
                    user = UserManager.FindByName(registerViewModel.UserName);
                    if (user != null)
                    {
                        var role = RoleManager.FindById(registerViewModel.RoleId);
                        user.ApplicationUserRole.Add(new ApplicationUserRole()
                        {
                            UserId = user.Id,
                            RoleId = role.Id,
                            Void = false,
                            ApplicationRole = role,
                            ApplicationUser = user
                        });
                        UserManager.Update(user);

                        return RedirectToAction("AllUsers");
                    }
                }
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles.Where(w => w.Void == false), "Id", "Name");
            return View(registerViewModel);
        }

        public ActionResult AllUsers(int? pageid, int? pageSize)
        {
            return View(UserManager.Users.Where(w => w.Void == false).OrderBy(o => o.Id).ToPagedList(pageid ?? 1, pageSize ?? 10));
        }

        public async Task<ActionResult> UserDetails(int id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
                return HttpNotFound();

            var userrole = user.ApplicationUserRole.SingleOrDefault();
            var role = (userrole != null) ? userrole.ApplicationRole : null;
            ViewBag.RoleName = (role != null) ? role.Name : "訪客";
            return View(user);
        }

        public async Task<ActionResult> UserProfileEdit(int id)
        {
            ViewBag.RoleId = new SelectList(RoleManager.Roles.Where(w => w.Void == false), "Id", "Name");
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            UserProfileViewModel viewmodel = new UserProfileViewModel();
            viewmodel.Id = user.Id;
            viewmodel.AccessFailedCount = user.AccessFailedCount;
            viewmodel.Address = user.Address;
            viewmodel.CreateTime = user.CreateTime;
            viewmodel.CreateUserId = user.CreateUserId;
            viewmodel.DisplayName = user.DisplayName;
            viewmodel.EMail = user.EMail;
            viewmodel.EMailConfirmed = user.EMailConfirmed;
            viewmodel.LastActivityTime = user.LastActivityTime;
            viewmodel.LastLoginFailTime = user.LastLoginFailTime;
            viewmodel.LastUnlockedTime = user.LastUnlockedTime;
            viewmodel.LastUpdateTime = user.LastUpdateTime;
            viewmodel.LastUpdateUserId = user.LastUpdateUserId;
            viewmodel.LockoutEnabled = user.LockoutEnabled;
            viewmodel.LockoutEndDate = user.LockoutEndDate;
            viewmodel.Password = user.Password;
            viewmodel.PasswordHash = user.PasswordHash;
            viewmodel.PhoneConfirmed = user.PhoneConfirmed;
            viewmodel.PhoneNumber = user.PhoneNumber;
            viewmodel.ResetPasswordToken = user.ResetPasswordToken;
            viewmodel.SecurityStamp = user.SecurityStamp;
            viewmodel.TwoFactorEnabled = user.TwoFactorEnabled;
            viewmodel.UserName = user.UserName;
            viewmodel.Void = user.Void;
            var userrole = viewmodel.ApplicationUserRole.SingleOrDefault();
            var role = (userrole != null) ? userrole.ApplicationRole : null;
            viewmodel.RoleId = (role != null) ? role.Id : 0;
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfileEdit(UserProfileViewModel user)
        {
            if (ModelState.IsValid)
            {
                var dbuser = UserManager.FindById(user.Id);

                dbuser.Id = user.Id;
                dbuser.AccessFailedCount = user.AccessFailedCount;
                dbuser.Address = user.Address;
                dbuser.CreateTime = user.CreateTime;
                dbuser.CreateUserId = user.CreateUserId;
                dbuser.DisplayName = user.DisplayName;
                dbuser.EMail = user.EMail;
                dbuser.EMailConfirmed = user.EMailConfirmed;
                dbuser.LastActivityTime = user.LastActivityTime;
                dbuser.LastLoginFailTime = user.LastLoginFailTime;
                dbuser.LastUnlockedTime = DateTime.UtcNow;
                dbuser.LastUpdateTime = user.LastUpdateTime;
                dbuser.LastUpdateUserId = User.Identity.GetUserId<int>();
                dbuser.LockoutEnabled = user.LockoutEnabled;
                dbuser.LockoutEndDate = user.LockoutEndDate;
                dbuser.Password = user.Password;
                dbuser.PasswordHash = user.PasswordHash;
                dbuser.PhoneConfirmed = user.PhoneConfirmed;
                dbuser.PhoneNumber = user.PhoneNumber;
                dbuser.ResetPasswordToken = user.ResetPasswordToken;
                dbuser.SecurityStamp = user.SecurityStamp;
                dbuser.TwoFactorEnabled = user.TwoFactorEnabled;
                dbuser.UserName = user.UserName;
                dbuser.Void = user.Void;

                var userrole = dbuser.ApplicationUserRole.SingleOrDefault();
                var role = (userrole != null) ? userrole.ApplicationRole : null;
                var roleid = (role == null) ? -1 : role.Id;

                if (roleid <= 0)
                {
                    UserManager.RemoveFromRoles(dbuser.Id, dbuser.ApplicationUserRole.Select(s => s.ApplicationRole.Name).ToArray());
                }

                if (roleid != user.RoleId)
                {
                    UserManager.AddToRole(dbuser.Id, RoleManager.FindById(user.RoleId).Name);
                    //dbuser.ApplicationUserRole.Add(new ApplicationUserRole() { RoleId = user.RoleId, UserId = user.Id, Void = false });                    
                }


                IdentityResult result = UserManager.Update(dbuser);

                if (result.Succeeded)
                {

                    return RedirectToAction("AllUsers");
                }
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles.Where(w => w.Void == false), "Id", "Name");
            return View(user);
        }

        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = UserManager.FindById(id ?? 0);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteUser(int id)
        {
            ApplicationUser user = UserManager.FindById(id);
            user.Void = true;
            user.LockoutEnabled = true;
            user.LastUpdateUserId = User.Identity.GetUserId<int>();
            user.LastUnlockedTime = user.LastActivityTime = user.LastUpdateTime = DateTime.UtcNow;
            UserManager.Update(user);
            return RedirectToAction("AllUsers");
        }

        public ActionResult AllRoles()
        {
            return View(RoleManager.Roles.Where(w => w.Void == false).ToList());
        }

        public ActionResult RoleDetails(int id)
        {
            return View(RoleManager.FindById(id));
        }

        public ActionResult CreateRole()
        {
            return View(ApplicationRole.Create());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(ApplicationRole role)
        {
            var result = RoleManager.Create(role);

            if (result.Succeeded)
            {
                return RedirectToAction("AllRoles");
            }
            return View(role);
        }

        public ActionResult ListRoleMembers(int id)
        {
            var role = RoleManager.FindById(id);
            return View(role.ApplicationUserRole.Where(w => w.RoleId == id).Select(s => s.ApplicationUser));
        }

        public ActionResult DeleteRole(int? id)
        {
            return View(RoleManager.FindById(id ?? 0));
        }

        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleConfirmed(int id)
        {
            var role = RoleManager.FindById(id);
            role.Void = true;
            role.LastUpdateTime = DateTime.UtcNow;
            role.LastUpdateUserId = User.Identity.GetUserId<int>();
            var result = RoleManager.Update(role);
            if (result.Succeeded)
            {
                return RedirectToAction("AllRoles");
            }
            return View(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helper
        // 新增外部登入時用來當做 XSRF 保護
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId<int>());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId<int>());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}