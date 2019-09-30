using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            var myProduct = new Product
            {
                ProductID = 1,
                Name = "Kayak",
                Description = "А boat for one person",
                Category = "Watersports",
                Price = 275M
            };
            ViewBag.StockLevel = 3;
            return View(myProduct);
        }

        public ViewResult List()
        {
            Product[] array =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flaq", Price = 34.95M}
            };
            return View(array);
        }
    }
}