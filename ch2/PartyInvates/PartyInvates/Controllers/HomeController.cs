using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvates.Models;

namespace PartyInvates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       // public string Index() => "Привет мир";
       
        public  ViewResult Index()
        {
            ViewBag.Greeting = DateTime.Now;
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            _logger.LogDebug(guestResponse.ToString());
            if (ModelState.IsValid)
            {
                Repositoty.AddResponse(guestResponse);
                return View("Thanks", guestResponse);

            }
            else
            {
                return View();
            }

            
            
        }

        public ViewResult ListResponces()
        {
            return View(Repositoty.Responses.Where(_ => _.WillAttend == true));
            
        }
    }
}
