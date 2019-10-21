using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ConventionsAndConstraints.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConventionsAndConstraints.Controllers
{
    using ConventionsAndConstraints.Infrastructure;
   // [AdditionalActions]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ActionName("Index")]
        [UserAgent("Edge")]
        public IActionResult Other() => View("Result", new Result {
            Controller = nameof(HomeController),
            Action = nameof(Other)
        } ) ;

        [UserAgent("Edge")]
        public IActionResult Index() =>
            View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });

        //[ActionName("Details")]
       // [ActionNamePrefix("Do")]
       // [AddAction("Details")]
        public IActionResult List() =>
            View("Result", new Result { Controller = nameof(HomeController), Action = nameof(List) });
    }
}