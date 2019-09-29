namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public string Category { get; set; } = "Watersports";
        public bool InStock { get; } = true;


        public Product(bool stock = true)
        {
            InStock = stock;
        }
        

        public static Product[] GetProducts()
        {
            var lifejacket = new Product(false)
            {
                Name = "Lifejacket", Price = 48.95M
            };
            var kayak = new Product
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M, 
                Related = lifejacket
            };

            return new[] {kayak, lifejacket, null};
        }
    }
}