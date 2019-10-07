

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using UrlsAndRoutes.Areas.Admin.Models;

    [Area("Admin")]
    public class HomeController:Controller
    {

        private Person[] data = new Person[]
                                    {
                                        new Person { Name = "Alice", City = "London" },
                                        new Person { Name = "ВоЬ", City = "Paris" },
                                        new Person { Name = "Joe", City = "New York" }
                                    };

        public ViewResult Index() => View(data);

    }
}
