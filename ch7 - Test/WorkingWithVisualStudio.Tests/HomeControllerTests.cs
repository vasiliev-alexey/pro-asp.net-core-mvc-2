// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTests.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ModelCompleteFakeRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WorkingWithVisualStudio.Tests
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using WorkingWithVisualStudio.Controllers;
    using WorkingWithVisualStudio.Models;
    using Xunit;

    /// <summary>
    /// The home controller tests.
    /// </summary>
    public class HomeControllerTests
    {
        /// <summary>
        /// The index action modells complete.
        /// </summary>
        [Fact]
        public void IndexActionModellsComplete()
        {
            var logger = Mock.Of<ILogger<HomeController>>();
            var irep = new ModelCompleteFakeRepository();
            var controller = new HomeController(logger, irep);

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(
                irep.Products,
                model,
                Comparer.Get<Product>((pl, р2) => pl.Name == р2.Name && pl.Price == р2.Price));
        }

        /// <summary>
        /// The index action modells complete price under 50.
        /// </summary>
        [Fact]
        public void IndexActionModellsCompletePriceUnder50()
        {
            var logger = Mock.Of<ILogger<HomeController>>();
            var irep = new ModelCompleteFakeRepositoryUnder50();
            var controller = new HomeController(logger, irep);
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(
                irep.Products,
                model,
                Comparer.Get<Product>((pl, р2) => pl.Name == р2.Name && pl.Price == р2.Price));
        }

        /// <summary>
        /// The index actionмodelis complete.
        /// </summary>
        /// <param name="pricel">
        /// The pricel.
        /// </param>
        /// <param name="price2">
        /// The price 2.
        /// </param>
        /// <param name="priceЗ">
        /// The priceз.
        /// </param>
        /// <param name="price4">
        /// The price 4.
        /// </param>
        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionМodelisComplete(decimal pricel, decimal price2, decimal priceЗ, decimal price4)
        {
            var logger = Mock.Of<ILogger<HomeController>>();
            var irep = new ModelCompleteFakeRepository
            {
                Products = new Product[]
                                              {
                                                  new Product { Name = "Pl", Price = pricel },
                                                  new Product { Name = "Р2", Price = price2 },
                                                  new Product { Name = "РЗ", Price = priceЗ },
                                                  new Product { Name = "Р4", Price = price4 }
                                              }
            };
            var controller = new HomeController(logger, irep);
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(
                irep.Products,
                model,
                Comparer.Get<Product>((pl, р2) => pl.Name == р2.Name && pl.Price == р2.Price));
        }

        /// <summary>
        /// The repository property called once.
        /// </summary>
        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            var logger = Mock.Of<ILogger<HomeController>>();
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new[] { new Product { Name = "Pl", Price = 100m } });
            var controller = new HomeController(logger, mock.Object);

            var result = controller.Index();

            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }

    /// <summary>
    /// The model complete fake repository.
    /// </summary>
  internal  class ModelCompleteFakeRepository : IRepository
    {
        public IEnumerable<Product> Products { get; set; } = new Product[]
                                                                 {
                                                                     new Product { Name = "P1", Price = 275m },
                                                                     new Product { Name = "P2", Price = 48.95m },
                                                                     new Product { Name = "P3", Price = 19.50m },
                                                                     new Product { Name = "P4", Price = 34.95m }
                                                                 };

        public void AddProduct(Product р)
        {
        }
    }

    /// <summary>
    /// The model complete fake repository under 50.
    /// </summary>
    class ModelCompleteFakeRepositoryUnder50 : IRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        public IEnumerable<Product> Products { get; } = new Product[]
                                                            {
                                                                new Product { Name = "P1", Price = 5m },
                                                                new Product { Name = "P2", Price = 48.95m },
                                                                new Product { Name = "P3", Price = 19.50m },
                                                                new Product { Name = "P4", Price = 34.95m }
                                                            };

        public void AddProduct(Product р)
        {
        }
    }
}