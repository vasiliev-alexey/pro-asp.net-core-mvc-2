namespace SportsStore.Models.Interfaces
{
    using System.Linq;

    using SportsStore.Models.Domain;

    /// <summary>
    /// The ProductRepository interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        IQueryable<Product> Products { get; }

        /// <summary>
        /// The save product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void SaveProduct(Product product);

        /// <summary>
        /// The delete product.
        /// </summary>
        /// <param name="productID">
        /// The product id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        Product DeleteProduct(int productID);
    }
}