namespace SportsStore.Models.Domain
{
    public class CartLine
    {
        /// <summary>
        /// Gets or sets the cart line id.
        /// </summary>
        public int CartLineID { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}