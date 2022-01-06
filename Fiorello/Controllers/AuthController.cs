using Fiorello.Email;
using Fiorello.Models;
using Fiorello.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class AuthController : Controller
    {

        private UserManager<ApplicationUser> _userManager { get; }
        private SignInManager<ApplicationUser> _signInManager { get; }

        public AuthController(UserManager<ApplicationUser> usermanager , 
                               SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            ApplicationUser newUser = new ApplicationUser
            {
                Fullname = register.Fullname,
                Email = register.Email,
                UserName = register.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);

            if (identityResult.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confimationLink = Url.Action("ConfirmEmail", "Email", new { token, email = register.Email }, Request.Scheme);
                EmailHelper emailHelper = new EmailHelper();
                bool emailResponse = emailHelper.SendEmail(register.Email, confimationLink);

                if (emailResponse)
                    return RedirectToAction("Index");
                else
                {
                    // log email failed 
                }
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(register);
            }


            await _signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
