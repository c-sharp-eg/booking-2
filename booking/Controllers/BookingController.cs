using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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
        
        // GET api/values
        [HttpGet]
        public async Task< ActionResult<int>> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5010/api/client");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var count = await response.Content.ReadAsAsync<int>();
            return count;
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
