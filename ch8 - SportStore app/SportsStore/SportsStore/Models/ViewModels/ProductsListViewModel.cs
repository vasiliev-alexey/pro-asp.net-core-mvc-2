namespace SportsStore.Models.ViewModels
{
    using System.Collections.Generic;

    using SportsStore.Models.Domain;

    /// <summary>
    /// The products list view model.
    /// </summary>
    public class ProductsListViewModel
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the paginglnfo.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}