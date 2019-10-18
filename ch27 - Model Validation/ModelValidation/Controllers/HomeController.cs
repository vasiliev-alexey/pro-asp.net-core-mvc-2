using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() =>
            View("MakeBooking", new Appointment { Date = DateTime.Now }) ;

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
           /*
            if (string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError(nameof(appt.ClientName), "Введите свое имя");
            }

            if (ModelState.GetValidationState("Date") == ModelValidationState.Valid && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError(nameof(appt.Date),
                    "Введите дату, относящуюся к будущему");
            }

            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted), "Вы должны принять условия");
            }
            */
            if (ModelState.GetValidationState(nameof(appt.Date)) == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName)) == ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            }

            if (ModelState.IsValid)
            {
                return this.View("Completed", appt);
            }
            else
            {
                return this.View();
            }

          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Пожалуйств введите дату (mm/dd/yyyy)");
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Пожалуйств введите дату в будущем json");
            }
            else
            {
                return Json(true);
            }
        }


    }
}
