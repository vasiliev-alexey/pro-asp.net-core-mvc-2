using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependencyinjection.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly IModelStorage modelStorage;

        private readonly Dictionary<string, Product> products;

        public MemoryRepository(IModelStorage modelStorage)
        {
            this.modelStorage = modelStorage;
            products = new Dictionary<string, Product>();
            new List<Product>
                {
                    new Product { Name = "Kayak", Price = 275m },
                    new Product { Name = "Lifejacket", Price = 48.95m },
                    new Product { Name = "Soccer ball", Price = 19.50m }
                }.ForEach(p => AddProduct(p));
        }

        public IEnumerable<Product> Products => modelStorage.Items;

        public Product this[string name] => modelStorage[name];

        public void AddProduct(Product product)
        {
            modelStorage[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            modelStorage.RemoveItem(product.Name);
        }
    }
}