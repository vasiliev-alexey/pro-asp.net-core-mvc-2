using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConfiguringApps.Models;

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
        public ViewResult Index() => View(new Dictionary<string, string> { ["Message"] = "This is the Index action" , 
                                         ["Uptime"] = $"{this.uptimeService.Uptime}ms" });

   
    }
}
