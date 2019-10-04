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

        public ViewResult List(string category, int productPage = 1)
        {
            return this.View(
                new ProductsListViewModel
                    {
                        Products = this.repository.Products.Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductID).Skip((productPage - 1) * this.PageSize).Take(this.PageSize),
                        PagingInfo = new PagingInfo
                                         {
                                             CurrentPage = productPage,
                                             ItemsPerPage = this.PageSize,
                                             Totalitems = this.repository.Products.Where(
                                                 p => category == null || p.Category == category).Count()
                                         },
                        CurrentCategory = category
                    });
        }
    }
}