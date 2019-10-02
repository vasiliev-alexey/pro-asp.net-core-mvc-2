namespace SportsStore.Models.Domain
{
    /// <summary>
    /// The product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }
    }
}