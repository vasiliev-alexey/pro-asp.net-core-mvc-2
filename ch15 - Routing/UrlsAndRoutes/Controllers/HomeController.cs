using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    using Microsoft.AspNetCore.Routing;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });
        }

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result { Controller = nameof(this.GetType), Action = nameof(this.CustomVariable), };
            //r.Data["Id"] = RouteData.Values["id"];
            r.Data["Id"] = id ?? "<novalue>";
            return View("Result", r);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}