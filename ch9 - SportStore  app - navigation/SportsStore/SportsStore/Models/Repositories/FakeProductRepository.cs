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
    }
}