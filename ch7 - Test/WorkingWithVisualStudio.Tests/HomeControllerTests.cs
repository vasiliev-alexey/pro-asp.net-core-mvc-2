using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    class ModelCoшpleteFakeRepository : IRepository
    {
        public IEnumerable<Product> Products { get; } = new Product[]
        {
            new Product {Name = "P1", Price = 275m},
            new Product {Name = "P2", Price = 48.95m},
            new Product {Name = "P3", Price = 19.50m},
            new Product {Name = "P4", Price = 34.95m}
        };

        public void AddProduct(Product р)
        {
        }
    }

    class ModelCoшpleteFakeRepositoryUnder50 : IRepository
    {
        public IEnumerable<Product> Products { get; } = new Product[]
        {
            new Product {Name = "P1", Price = 5m},
            new Product {Name = "P2", Price = 48.95m},
            new Product {Name = "P3", Price = 19.50m},
            new Product {Name = "P4", Price = 34.95m}
        };

        public void AddProduct(Product р)
        {
        }
    }



    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModellsComplete()
        {
            var logger = Mock.Of<ILogger<HomeController>>();
            var irep = new ModelCoшpleteFakeRepository();
            var controller = new HomeController(logger, irep);

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(irep.Products, model,
                Comparer.Get<Product>((pl, р2) => pl.Name == р2.Name
                                                  && pl.Price == р2.Price));
        }


        [Fact]
        public void IndexActionModellsCompletePriceUnder50()
        {
            var logger = Mock.Of<ILogger<HomeController>>();
        var irep = new ModelCoшpleteFakeRepositoryUnder50();
        var controller = new HomeController(logger, irep);
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(irep.Products, model,
                Comparer.Get<Product>((pl, р2) => pl.Name == р2.Name
                                                  && pl.Price == р2.Price));
        }

    }
}