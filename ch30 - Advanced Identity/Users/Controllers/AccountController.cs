using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Users.Models;

    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userMgr;

        private readonly SignInManager<AppUser> signinМgr;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinМgr)
        {
            this.userMgr = userMgr;
            this.signinМgr = signinМgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await this.userMgr.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await this.signinМgr.SignOutAsync();
                    SignInResult result = await this.signinМgr.PasswordSignInAsync(
                                              user,
                                              details.Password,
                                              false,
                                              false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginModel.Email), "Invalid user or password");
            }

            return View(details);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied() { 
            return View();
    }


    [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signinМgr.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}