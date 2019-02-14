﻿using System;
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

        public FlightController()
        {
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
        
        /*
        [HttpGet]
        public async Task<ActionResult<int>> GetFlight()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5020/api/flight");

                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsAsync<int>();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        */

        [HttpGet]
        public async Task<ActionResult<int>> GetAircraft()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5020/api/aircraft");

                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsAsync<int>();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAllFlights()
        {
            var client = clientFactory.CreateClient();
            var x = await f_GetAllFlights(client);
            return Ok(x);

        }

        public async Task<IEnumerable<Flight>> f_GetAllFlights(HttpClient client)
        {
            try
            {
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/GetAllFlights");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Flight>>(response);
                return tt;
            }
            catch { return null; }

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAllAircrafts()
        {
            var client = clientFactory.CreateClient();
            var x = await f_GetAllAircrafts(client);
            return Ok(x);

        }

        public async Task<IEnumerable<Aircraft>> f_GetAllAircrafts(HttpClient client)
        {
            try
            {
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/getallaircrafts");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Aircraft>>(response);
                return tt;
            }
            catch { return null; }

        }
        /*
        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAllFlights()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/GetAllFlights");
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
        */

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetFlight(string id)
        {
            var client = clientFactory.CreateClient();
            var x = await f_GetFlight(client, id);
            return Ok(x);

        }

        public async Task<IEnumerable<Flight>> f_GetFlight(HttpClient client, string id)
        {
            try
            {
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/getflight"+ "?Id=" + id);
                var tt = JsonConvert.DeserializeObject<IEnumerable<Flight>>(response);
                return tt;
            }
            catch { return null; }

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAircraft(string id)
        {
            var client = clientFactory.CreateClient();
            var x = await f_GetAircraft(client, id);
            return Ok(x);

        }

        public async Task<IEnumerable<Aircraft>> f_GetAircraft(HttpClient client, string id)
        {
            try
            {
                var response = await client.GetStringAsync("http://localhost:5020/api/flight/getaircraft"+"?Id=" + id);
                var tt = JsonConvert.DeserializeObject<IEnumerable<Aircraft>>(response);
                return tt;
            }
            catch { return null; }

        }

        /*
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetFlight(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5020/api/getflight");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsAsync<int>();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetAircraft(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5010/api/getaircraft");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsAsync<int>();
            return Ok(result);
        }
        */

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFlight(string id, [FromBody]FlightModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:5020/api/flight" + "/" + id)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };
                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var update = await response.Content.ReadAsAsync<int>();
                return Ok(update);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAircraft(string id, [FromBody]AircraftModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:5020/api/aircraft" + "/" + id)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };
                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var update = await response.Content.ReadAsAsync<int>();
                return Ok(update);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void DeleteFlight(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5020/api/flight" + "/" + id)
            {
                Content = new StringContent(id, Encoding.UTF8, "application/json")
            };
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var create = await response.Content.ReadAsAsync<int>();
            return;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void DeleteAircraft(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5020/api/aircraft" + "/" + id)
            {
                Content = new StringContent(id, Encoding.UTF8, "application/json")
            };
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var create = await response.Content.ReadAsAsync<int>();
            return;
        }
    }
}
