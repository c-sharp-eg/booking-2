using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using booking.flight.Abstract;
using booking.flight.Model;
using booking.client.ViewModel;

namespace booking.flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightRepository flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }

        // GET
        [HttpGet]
        public ActionResult<Flight> Get([FromQuery]String id)
        {
            var flight = flightRepository.Get(id);
            if (flight == null)
            {
                return BadRequest();
            }
            return Ok(flight);
        }

        // добавить рейс
        [HttpPost]
        public ActionResult Post([FromBody] FlightModel model)
        {
            var flight = new Flight
            {
                AircraftId = model.AircraftId,
                Date = model.Date,
                Number = model.Number            
            };

            flightRepository.Add(flight);
            return Ok();
        }

        // обновить рейс
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] FlightModel model)
        {
            var flight = flightRepository.Get(id);
            if (flight == null)
            {
                return NotFound();
            }

            flight.AircraftId = model.AircraftId;
            flight.Date = model.Date;
            flight.Number = model.Number;

            flightRepository.Update(flight);

            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            flightRepository.Delete(id);
            return Ok();
        }
    }
}
