using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dependencyinjection.Models;

namespace Dependencyinjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  IRepository repository;
    public HomeController(ILogger<HomeController> logger , IRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

        public IActionResult Index()
        {
            var repository2 =
                (IRepository)HttpContext.RequestServices.GetService(typeof(IRepository));

            return View(repository2.Products);
        }

        public IActionResult Index2([FromServices]IRepository repository2)
        {
           

            return View("Index",repository2.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
