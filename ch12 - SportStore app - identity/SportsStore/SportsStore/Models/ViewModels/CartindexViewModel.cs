namespace SportsStore.Models.ViewModels
{
    using SportsStore.Models.Domain;

    /// <summary>
    /// The cartindex view model.
    /// </summary>
    public class CartindexViewModel
    {
        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the return url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}