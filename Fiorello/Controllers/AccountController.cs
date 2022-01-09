using Fiorello.Email;
using Fiorello.Models;
using Fiorello.ViewModel.Auth;
using Fiorello.ViewModel.UserProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Fiorello.Utilities.File.Helper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Fiorello.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> _userManager { get; }
        private SignInManager<ApplicationUser> _signInManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }

        public AccountController(UserManager<ApplicationUser> usermanager , 
                               SignInManager<ApplicationUser> signInManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            IsAuthenticated();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            ApplicationUser newUser = new ApplicationUser
            {
                Fullname = register.Fullname,
                Email = register.Email,
                UserName = register.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = register.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(register.Email, confirmationLink);

            if (emailResponse)
            {
                ModelState.AddModelError(string.Empty, "Succesed");
                return View();
            }

            await _userManager.AddToRoleAsync(newUser, UserRoles.Admin.ToString());
            //await _signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login , string ReturnUrl)
        {
            if (!ModelState.IsValid) return View(login);

            ApplicationUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email adres or Password is Incorrect");
                return View(login);
            }

            if (!user.IsActivated)
            {
                ModelState.AddModelError("", "Your account isn't active");
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "You blocked for 10 minutes");
                return View(login);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email adress or Password is incorrect");
                return View(login);
            }

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
            {
                throw new Exception("You already authenticated");
            }
        }

        #region Create role

        //public async Task CreateRole()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }
        //}
        #endregion

        /* Password Reset start*/
        public IActionResult ResetPassword(string token , string email)
        {
            if (token == null || email == null )
            {
                ModelState.AddModelError(string.Empty, "Invalid operation");
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        {
            if (!ModelState.IsValid) return View(reset);

            var user = await _userManager.FindByEmailAsync(reset.Email);

            var result = await _userManager.ResetPasswordAsync(user, reset.Token, reset.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forget)
        {
            if (!ModelState.IsValid) return View(forget);
            var user = await _userManager.FindByEmailAsync(forget.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Your account is incorrect");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var confirmationLink = Url.Action("ResetPassword", "Account", new { token, email = forget.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(forget.Email, confirmationLink);


            if (emailResponse)
            {
                ModelState.AddModelError(string.Empty, "Succesed , Please confirm from email");
                return View();
            }

            return View();
        }


        /* Password Reset end*/

        
        public async Task<IActionResult>  UserProfile()
        {
            var userName = User.Identity.Name;

            var user = await _userManager.FindByNameAsync(userName);

            UserProfileVM userProfile = new UserProfileVM
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Username = user.UserName
            };
            
            return View(userProfile);
        }

        public async Task<IActionResult> UserProfilSetting()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);

            UserProfileVM userProfile = new UserProfileVM
            {
                Fullname = user.Fullname,
                Username = user.UserName
            };

            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserProfilSetting(UserProfileVM userProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(userProfile);
            }


            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Your account is not found");
            }

            user = new ApplicationUser
            {
                Fullname = userProfile.Fullname,
                UserName = userProfile.Username
            };

            var result  = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
