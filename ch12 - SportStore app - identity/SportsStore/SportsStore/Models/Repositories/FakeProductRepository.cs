namespace SportsStore.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    public class FakeProductRepository : IProductRepository
    {
        /// <summary>
        /// The products.
        /// </summary>
        public IQueryable<Product> Products =>
            new List<Product>
                {
                    new Product { Name = "Football", Price = 25 },
                    new Product { Name = "Surfboard", Price = 179 },
                    new Product { Name = "Running shoes", Price = 95 }
                }.AsQueryable<Product>();

        public void SaveProduct(Product product)
        {
          var existsProduct = Products.FirstOrDefault(_ => _.ProductID == product.ProductID);

          if (existsProduct != null)
          {
              Products.ToList().Remove(existsProduct);
          }
          Products.ToList().Add(product);
        }

        /// <summary>
        /// The delete product.
        /// </summary>
        /// <param name="productID">
        /// The product id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        public Product DeleteProduct(int productID)
        {
            var existsProduct = Products.FirstOrDefault(_ => _.ProductID == productID);

            if (existsProduct != null)
            {
                Products.ToList().Remove(existsProduct);
            }

            return existsProduct;
        }
    }
}