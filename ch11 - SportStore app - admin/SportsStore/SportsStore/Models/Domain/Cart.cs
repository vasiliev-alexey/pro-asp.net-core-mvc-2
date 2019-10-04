using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.Domain
{
    public class Cart
    {
        /// <summary>
        /// The line collection.
        /// </summary>
        private readonly List<CartLine> lineCollection = new List<CartLine>();
        
        /// <summary>
        /// The lines.
        /// </summary>
        public virtual IEnumerable<CartLine> Lines => lineCollection;

        public virtual void AddItem(Product product, int quantity)
        {
            var line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// The remove line.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);

        /// <summary>
        /// The clear.
        /// </summary>
        public virtual void Clear() => lineCollection.Clear();

     
    }
}