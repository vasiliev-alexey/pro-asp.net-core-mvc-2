using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    using Microsoft.Extensions.Logging;

    using SportsStore.Models.Interfaces;
    using SportsStore.Models.ViewModels;

    /// <summary>
    /// The product controller.
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// The page size.
        /// </summary>
        public int PageSize = 4;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IProductRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public ProductController(ILogger<HomeController> logger, IProductRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public ViewResult List(int productPage = 1)
        {
            return View(
                new ProductsListViewModel
                    {
                        Products = repository.Products.OrderBy(p => p.ProductID)
                            .Skip((productPage - 1) * PageSize).Take(PageSize),
                        PagingInfo = new PagingInfo
                                         {
                                             CurrentPage = productPage,
                                             ItemsPerPage = PageSize,
                                             Totalitems = repository.Products.Count()
                                         }
                    });
        }
    }
}