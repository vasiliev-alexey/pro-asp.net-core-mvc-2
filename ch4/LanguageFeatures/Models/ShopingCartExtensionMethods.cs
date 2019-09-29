using System.Linq;

namespace LanguageFeatures.Models
{
    public static class ShopingCartExtensionMethods
    {
        public static decimal TotalPrice(this ShoppingCart shoppingCart)
        {
            var total = shoppingCart.Products.Sum(_ => _?.Price ?? 0);
            return total;
        }
    }
}