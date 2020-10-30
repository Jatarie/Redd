using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AuthBasic.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;

namespace AuthBasic.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> AppUserManager { get; set; }
        public SignInManager<AppUser> AppSignInManager { get; set; }
        public RoleManager<AppRole> AppRoleManager { get; set; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            AppUserManager = userManager;
            AppRoleManager = roleManager;
            AppSignInManager = signInManager;
        }

        private async Task<IdentityResult> AddRole(string roleName)
        {
            if (!await AppRoleManager.RoleExistsAsync(roleName))
            {
                AppRole role = new AppRole();
                role.Name = "Admin";
                return await AppRoleManager.CreateAsync(role);
            }
            else
            {
                return null;
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Register([FromForm] UserRegistrationModel userRegistration)
        {
            AppUser user = await AppUserManager.FindByNameAsync(userRegistration.UserName);
            if (user == null)
            {
                user = new AppUser();
                user.PasswordHash = AppUserManager.PasswordHasher.HashPassword(user, userRegistration.Password);
                user.UserName = userRegistration.UserName;
                await AppUserManager.CreateAsync(user);
                await AppUserManager.AddToRoleAsync(user, "Admin");
            }
        }

        [AllowAnonymous]
        public async Task<string> Validate_Username(string UserName)
        {
            if (await AppUserManager.FindByNameAsync(UserName) == null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromForm] UserLogInModel userLogIn)
        {
            AppUser user = await AppUserManager.FindByNameAsync(userLogIn.UserName);
            if (user != null)
            {
                if (await AppUserManager.CheckPasswordAsync(user, userLogIn.Password))
                {
                    await AppSignInManager.SignInAsync(user, isPersistent: true);
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        [Authorize]
        public async void LogOut()
        {
            await AppSignInManager.SignOutAsync();
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = AppSignInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await AppSignInManager.GetExternalLoginInfoAsync();
            var result = await AppSignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return LocalRedirect("/");
            else
            {
                AppUser user = new AppUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                };

                IdentityResult identResult = await AppUserManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await AppUserManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await AppSignInManager.SignInAsync(user, false);
                        return LocalRedirect("/");
                    }
                }
                return LocalRedirect("/");
            }
        }
    }
}
