using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ConfiguringApps.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    using ConfiguringApps.Infrastructure;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UptimeService uptimeService;

        public HomeController(ILogger<HomeController> logger, UptimeService uptimeService)
        {
            _logger = logger;
            this.uptimeService = uptimeService;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        public ViewResult Index(bool throwException = false)
        {

            _logger.LogDebug($"Handled {Request.Path} at uptime {uptimeService.Uptime}");

            if (throwException)
            {
                throw new NullReferenceException();
            }

            return View(
                new Dictionary<string, string>
                    {
                        ["Message"] = "This is the Index action", ["Uptime"] = $"{this.uptimeService.Uptime}ms"
                    });
        }

        public ViewResult Error() =>
            View(nameof(Index), new Dictionary<string, string> { ["Message"] = "This is the Error action " });
    }
}

