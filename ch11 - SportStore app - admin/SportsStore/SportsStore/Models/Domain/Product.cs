namespace SportsStore.Models.Domain
{
    using System.ComponentModel.DataAnnotations;

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
      [Required(ErrorMessage = "Введите наименование товара")]
        
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите положительное значение для цены")]
        
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
       [Required(ErrorMessage = "Укажите категорию")]
        public string Category { get; set; }
    }
}