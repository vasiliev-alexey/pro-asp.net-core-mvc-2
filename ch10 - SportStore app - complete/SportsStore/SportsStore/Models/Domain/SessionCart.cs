using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SportsStore.Models.Domain
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    using SportsStore.Infrastructure;

    /// <summary>
    /// The session cart.
    /// </summary>
    public class SessionCart : Cart
    {
        /// <summary>
        /// The cart key.
        /// </summary>
        private const string CartKey = "Cart";

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>(CartKey)
                               ?? new SessionCart();
            cart.Session = session;
            return cart;
        }



        /// <summary>
        /// Gets or sets the session.
        /// </summary>

        [JsonIgnore]
        public ISession Session { get; set; }

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <param name="quantity">
        /// The quantity.
        /// </param>
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson(CartKey, this);
        }

        /// <summary>
        /// The remove line.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson(CartKey, this);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            Session.Remove(CartKey);
        }
    }
}