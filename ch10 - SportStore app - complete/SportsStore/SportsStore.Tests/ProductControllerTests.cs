﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Tests
{
    using System.Linq;

    using Moq;

    using SportsStore.Controllers;
    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    using Xunit;

    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                (new Product[]
                     {
                         new Product { ProductID = 1, Name = "P1" }, new Product { ProductID = 2, Name = "P2" },
                         new Product { ProductID = 3, Name = "P3" }, new Product { ProductID = 4, Name = "P4" },
                         new Product { ProductID = 5, Name = "P5" }
                     }).AsQueryable<Product>());

            ProductController controller = new ProductController(null, mock.Object) { PageSize = 3 };

            // Act
            var result = controller.List(null,2).ViewData.Model as IEnumerable<Product>;

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}