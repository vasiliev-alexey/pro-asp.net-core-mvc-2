namespace SportsStore.Models.Interfaces
{
    using System.Linq;

    using SportsStore.Models.Domain;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        IQueryable<Product> Products { get; }
    }
}