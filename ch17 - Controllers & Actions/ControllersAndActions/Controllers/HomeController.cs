using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ControllersAndActions.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControllersAndActions.Controllers
{
    using System.Text;

    using ControllersAndActions.Infrastructure;

    using Microsoft.AspNetCore.Http;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index() => View("SimpleForm");

        /*public ViewResult ReceiveForm()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("Result", $"{name} lives in {city}");
        }*/
        /*
        public void ReceiveForm(string name, string city)
        {
            // => View("Result", $"{name} lives in {city}");
            Response.StatusCode = 200;
            Response.ContentType = "text/ht.ml";

            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }
        */
        public IActionResult ReceiveForm(string name, string city)
        {
            // =>new CustomHtmlResult { Content = $"{name} lives in {city}" };
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data));
        }

        public ViewResult Data()
        {
            var name = TempData["name"] as string;
            var city = TempData["city"] as string;
            return View("Result", $" {name} lives in {city} ");
            return View("Result", $" {name} lives in {city} ");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}