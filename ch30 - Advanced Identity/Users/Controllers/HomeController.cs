using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Users.Models;
using System.ComponentModel.DataAnnotations;

namespace Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> userМanager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userМgr)
        {
            _logger = logger;
            this.userМanager = userМgr;
        }

       [Authorize]
        public IActionResult Index()
        {
           return  View(GetData(nameof(Index)));

        }

        // [Authorize(Roles = "users")]
        [Authorize(Policy = "DCUsers")]
        public IActionResult OtherAction() => View("Index",
            GetData(nameof(OtherAction)));


        [Authorize]
        public async Task<IActionResult> UserProps() =>
              View(await CurrentUser);

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps(
            [Required] Cities city,
            [Required] QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {

                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await this.userМanager.UpdateAsync(user);
                return RedirectToAction("Index");
          
            }
            return View(await CurrentUser);
        }

        [Authorize(Policy = "NotBob")]
        public IActionResult NotBob() => View("Index", GetData(nameof(NotBob)));


        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
                {
                    ["Action"] = actionName,
                    ["User"] = HttpContext.User.Identity.Name,
                    ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                    ["Auth Туре"] = HttpContext.User.Identity.AuthenticationType,
                    ["In Users Role"] = HttpContext.User.IsInRole("users"),
                    ["City"] = CurrentUser.Result.City,
                    ["Qualification"] = CurrentUser.Result.Qualifications
            };





        private Task<AppUser> CurrentUser =>
            this.userМanager.FindByNameAsync(HttpContext.User.Identity.Name);


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
