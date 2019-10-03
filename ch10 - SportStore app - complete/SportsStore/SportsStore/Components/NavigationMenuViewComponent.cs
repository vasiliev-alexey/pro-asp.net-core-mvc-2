namespace SportsStore.Components
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using SportsStore.Models.Interfaces;

    /// <summary>
    /// The navigation menu view component.
    /// </summary>
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository iProductRepository;

        public NavigationMenuViewComponent(IProductRepository iProductRepository)
        {
            this.iProductRepository = iProductRepository;
        }

        /// <summary>
        /// The invoke.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(this.iProductRepository.Products.Select(_ => _.Category).Distinct().OrderBy(_ => _));
        }
    }
}