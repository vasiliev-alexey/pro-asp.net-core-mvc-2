namespace SportsStore.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SportsStore.Models;
    using SportsStore.Models.ViewModels;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            IdentitySeedData.EnsurePopulated(userManager).Wait();
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return this.View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await this.signInManager.SignOutAsync();
                    if ((await this.signInManager.PasswordSignInAsync(user, loginModel.Password, false, false))
                        .Succeeded)
                        return this.Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Неправильное имя или пароль");
            return this.View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await this.signInManager.SignOutAsync();
            return this.Redirect(returnUrl);
        }
    }
}