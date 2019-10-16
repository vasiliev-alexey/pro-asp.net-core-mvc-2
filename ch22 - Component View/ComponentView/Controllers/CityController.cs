using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace UsingViewComponents.Controllers
{
    using Microsoft.AspNetCore.Mvc.ViewComponents;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    using UsingViewComponents.Models;
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private readonly ICityRepository repo;

        // GET: /<controller>/
        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repo.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() =>
            new ViewViewComponentResult()
                {
                    ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, repo.Cities)
                };
    };
}
 