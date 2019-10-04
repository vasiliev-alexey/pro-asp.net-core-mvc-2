namespace SportsStore.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;
    using SportsStore.Models.ViewModels;

    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;

        private readonly Cart cart;

        public CartController(IProductRepository productRepository, Cart cartService)
        {
            this.productRepository = productRepository;
            this.cart = cartService;
        }

        public RedirectToActionResult AddtoCart(int productId, string returnUrl)
        {
            Product product = this.productRepository.Products.FirstOrDefault(_ => _.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = this.productRepository.Products.FirstOrDefault(_ => _.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
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
            return View(new CartindexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
    }
}