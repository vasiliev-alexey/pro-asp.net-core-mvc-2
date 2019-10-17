using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cities.Models;

namespace Cities.Controllers
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.Cities);
        }
        public ViewResult Create()
        {
            ViewBag.Countries = new SelectList(repository.Cities
                .Select(c => c.Country).Distinct());
            return this.View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {

            ViewBag.Countries = new SelectList(repository.Cities
                .Select(c => c.Country).Distinct());
            repository.AddCity(city);
            return RedirectToAction("Index");
        }
        public ViewResult Edit()
        {

            ViewBag.Countries = new SelectList(repository.Cities
                .Select(c => c.Country).Distinct());
            return this.View("Create", this.repository.Cities.First());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private void addList(dynamic viewBag)
        {
        }

    }
}
