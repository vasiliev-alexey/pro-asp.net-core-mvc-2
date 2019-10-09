using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller__API.Controllers
{
    using Controller__API.Models;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Reservations);

        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}