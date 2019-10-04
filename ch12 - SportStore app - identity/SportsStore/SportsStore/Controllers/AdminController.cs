using System.Linq;

namespace SportsStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SportsStore.Models;
    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    using Controller = Microsoft.AspNetCore.Mvc.Controller;
    using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;

        public AdminController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult Index() => this.View(productRepository.Products);

        public ViewResult Edit(int productid) =>
            View(productRepository.Products.FirstOrDefault(p => p.ProductID == productid));

        [HttpPost]
        public IActionResult Edit(Product product) { 
            if (ModelState.IsValid) {
                productRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} сохранен в БД";
                return RedirectToAction("Index");
            }
            else
            {

                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productid) { 
        Product deletedProduct = this.productRepository.DeleteProduct(productid);
        if (deletedProduct != null)
        {
            TempData["message"] = $"{deletedProduct.Name} удален их БД";
        }

        ;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SeedDatabase()
        {
            SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
    }
}