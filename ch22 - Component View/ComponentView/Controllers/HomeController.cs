using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ComponentView.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComponentView.Controllers
{
    using UsingViewComponents.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.Products);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            _productRepository.AddProduct(newProduct);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}