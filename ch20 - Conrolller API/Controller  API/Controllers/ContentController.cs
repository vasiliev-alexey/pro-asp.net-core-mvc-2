using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller__API.Controllers
{
    using Controller__API.Models;

    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]

    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "This is а string response";

        [HttpGet("object")]
        [Produces("application/json")]
        public Reservation GetObject() =>
            new Reservation { ReservationId = 100, ClientName = "Joe", Location = "Board Room" };
    }
}