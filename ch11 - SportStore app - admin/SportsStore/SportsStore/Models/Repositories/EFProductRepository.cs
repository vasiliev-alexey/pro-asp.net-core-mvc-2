namespace SportsStore.Models.Repositories
{
    using System.Linq;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    public class EfProductRepository : IProductRepository
    {
        /// <summary>
        /// The DB context.
        /// </summary>
        private readonly ApplicationDbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfProductRepository"/> class.
        /// </summary>
        /// <param name="ctx">
        /// The DB context.
        /// </param>
        public EfProductRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        public IQueryable<Product> Products => ctx.Products;

        /// <summary>
        /// The save product.
        /// </summary>
        /// <param name="product">
        /// The product.
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                var dbEntry = ctx.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }

            ctx.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            var dbEntry = ctx.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                this.ctx.Products.Remove(dbEntry);
                ctx.SaveChanges();
            }

            return dbEntry;
        }
    }
}