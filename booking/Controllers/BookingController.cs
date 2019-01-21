using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using booking.client.Model;
using booking.flight.Model;

namespace booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public BookingController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public class Res
        {
            public string res1 { get; set; }
            public string res2 { get; set; }
            public string res3 { get; set; }
            public string res4 { get; set; }
            
        }
        //вывести все данные
        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAll()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response1 = await client.GetStringAsync("http://localhost:5010/api/client/getall");
                var response2 = await client.GetStringAsync("http://localhost:5020/api/flight/GetAllFlights");
                //var response3 = Redirect("/api/flight/getallaircrafts");
                //var response4 = Redirect("/api / order / GetAllOrders");
                var response3 = await client.GetStringAsync("http://localhost:5000/api/flight/getallaircrafts");
                var response4 = await client.GetStringAsync("http://localhost:5000/api/order/GetAllOrders");

                var res = new Res();
                res.res1 = response1;
                res.res2 = response2;
                res.res3 = response3;
                res.res4 = response4;
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }

           

        }

        public async Task<ActionResult<int>> DeleteFlight([FromBody]String id)
        {

            try
            {
                var client = clientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/getflight");

                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/delete");
                var res = await client.SendAsync(request);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
    }

    // GET api/values/5 
    [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
