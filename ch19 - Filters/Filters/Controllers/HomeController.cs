using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Filters.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Filters.Controllers
{
    using Filters.Infrastructure;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;

    // [Profile]
    // [ViewResultDetails]
    // [RangeException]
    [TypeFilter(typeof(DiagnosticsFilter))]
    [TypeFilter(typeof(TimeFilter))]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        [HttpsOnly]
        public IActionResult IndexHttps()
        {
            return View("Message", "This is the Index(Https) action on the Home controller");
        }

        public IActionResult Index2()
        {
            if (!Request.IsHttps)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [RequireHttps]
        public IActionResult Index3()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", $"The value is {id}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}