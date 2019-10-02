namespace SportsStore.Controllers
{
    using System.Linq;
    using Newtonsoft.Json;


    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;
    using SportsStore.Models.ViewModels;

    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;

        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public RedirectToActionResult AddtoCart(int productId , string returnUrl)
        {
            Product product = this.productRepository.Products.FirstOrDefault(_ => _.ProductID == productId);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = this.productRepository.Products.FirstOrDefault(_ => _.ProductID == productId);

            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// The save cart.
        /// </summary>
        /// <param name="cart">
        /// The cart.
        /// </param>
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        /// <summary>
        /// The get cart.
        /// </summary>
        /// <returns>
        /// The <see cref="Cart"/>.
        /// </returns>
        private Cart GetCart()
        {
            var cartstring = HttpContext.Session.GetString("Cart") ;
            if (!string.IsNullOrEmpty(cartstring))
            {
                var cart = JsonConvert.DeserializeObject<Cart>(cartstring);
                return cart;
            }

            return new Cart();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        public ViewResult Index(string returnUrl)
        {
            var cart = this.GetCart();

            return View(new CartindexViewModel
                            {
                                Cart = cart,
                                ReturnUrl = returnUrl
                            });
        }
    }
}