using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller__API.Controllers
{
    using System.IO;

    using Controller__API.Models;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRepository repository;

        public ReservationController(IRepository repository) => this.repository = repository;

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation res) =>
            repository.AddReservation(new Reservation { ClientName = res.ClientName, Location = res.Location });

        [HttpPut("{id}")]
        public async Task<Reservation> Put(int id, [FromBody] Reservation res)
        {

            return   repository.UpdateReservation(res);
        }
           


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Reservation> patch)
        {
            Reservation res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
               

            }
            return NotFound();
    }


        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);



}
}