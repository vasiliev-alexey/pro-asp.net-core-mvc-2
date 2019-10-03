namespace SportsStore.Models.Repositories
{
    using System.Linq;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    public class EfProductRepository :IProductRepository
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
    }
}