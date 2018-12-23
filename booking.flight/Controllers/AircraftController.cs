using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using booking.flight.Abstract;
using booking.flight.Model;
using booking.common.ViewModel;

namespace booking.flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private IAircraftRepository aircraftRepository;

        public AircraftController(IAircraftRepository aircraftRepository)
        {
            this.aircraftRepository = aircraftRepository;
        }

        // GET
        [HttpGet]
        public ActionResult<Aircraft> Get([FromQuery]String id)
        {
            var aircraft = aircraftRepository.Get(id);
            if (aircraft == null)
            {
                return BadRequest();
            }
            return Ok(aircraft);
        }

        // добавить рейс
        [HttpPost]
        public ActionResult Post([FromBody] AircraftModel model)
        {
            var aircraft = new Aircraft
            {
                Name = model.Name,
                NumberOfSeats = model.NumberOfSeats
            };

            aircraftRepository.Add(aircraft);
            return Ok();
        }

        // обновить рейс
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] AircraftModel model)
        {
            var aircraft = aircraftRepository.Get(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            aircraft.Name = model.Name;
            aircraft.NumberOfSeats = model.NumberOfSeats;

            aircraftRepository.Update(aircraft);

            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            aircraftRepository.Delete(id);
            return Ok();
        }
    }
}
