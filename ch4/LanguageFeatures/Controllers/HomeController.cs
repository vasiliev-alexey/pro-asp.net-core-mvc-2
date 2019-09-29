using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> rezult = new List<string>();

            foreach (var product in Product.GetProducts())
            {
                string name = product?.Name ?? "<No Name>";
                decimal? price = product?.Price ?? 0;
                var relatedName = product?.Related?.Name ?? "<None>";
                rezult.Add($"Name: {name} , Price: {price} Related: {relatedName}");
            }

            return View(rezult);
        }
    }
}