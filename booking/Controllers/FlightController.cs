using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using booking.common.ViewModel;
using System.Text;
using booking.flight.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace booking.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        private IHttpClientFactory clientFactory;

        public FlightController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }


        // GET api/values
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateFlight([FromBody]FlightModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };
                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var create = await response.Content.ReadAsAsync<int>();
                return Ok(create);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateAircraft([FromBody]AircraftModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/aircraft")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };
                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var create = await response.Content.ReadAsAsync<int>();
                return Ok(create);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAllFlights()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/getall");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Flight>>(response);
                return Ok(tt);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAllAircrafts()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/getallaircrafts");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Flight>>(response);
                return Ok(tt);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
