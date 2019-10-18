﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository repository;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            this.repository = repo;
        }

      
         

        public IActionResult Index([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                return View(this.repository[id.Value]);
            }

            return this.View("Title");


        }

        public ViewResult Create() => View(new Person());
        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);


        public ViewResult DisplaySummary(
            [Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))]
            AddressSummary summary) => View(summary);
        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) =>
            View(addresses ?? new List<AddressSummary>());
       // public string Header([FromHeader(Name = "Accept-Language")] string accept) => $"Header: {accept}" ;

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();
        [HttpPost]
        public Person Body([FromBody] Person model) => model;

    }
}
