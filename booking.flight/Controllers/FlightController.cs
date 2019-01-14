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
    public class FlightController : ControllerBase
    {
        private IFlightRepository flightRepository;

        public IAircraftRepository aircraftRepository { get; }

        public FlightController(IFlightRepository flightRepository, IAircraftRepository aircraftRepository)
        {
            this.flightRepository = flightRepository;
            this.aircraftRepository = aircraftRepository;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Flight>> GetAllFlights([FromQuery]int page, [FromQuery]int amount)
        {
            var flights = flightRepository.GetAll();
            if (page != 0 && amount != 0)
            {
                flights = flights.Skip(page * (amount - 1)).Take(amount);
            }
            if (flights == null)
            {
                return BadRequest();
            }
            return Ok(flights);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Flight>> GetAllAircrafts([FromQuery]int page, [FromQuery]int amount)
        {
            var aircrafts = aircraftRepository.GetAll();
            if (page != 0 && amount != 0)
            {
                aircrafts = aircrafts.Skip(page * (amount - 1)).Take(amount);
            }
            if (aircrafts == null)
            {
                return BadRequest();
            }
            return Ok(aircrafts);
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
                FreeSeats = model.FreeSeats,
                Sum = model.Sum,
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
            flight.FreeSeats = model.FreeSeats;
            flight.Sum = model.Sum;
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
