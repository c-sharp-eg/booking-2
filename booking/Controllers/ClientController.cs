using booking.client.Model;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using booking.common.ViewModel;
using System.Collections;

namespace booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public ClientController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        // GET api/values

        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody]ClientModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5010/api/client")
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

        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5010/api/client");

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

        [HttpGet]
        public async Task<ActionResult<int>> GetCount()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5010/api/client/count");

                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var count = await response.Content.ReadAsAsync<int>();
                return Ok(count);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetAll()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5010/api/client/getall");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Client>>(response);
                return Ok(tt);
            }
            catch
            {
                return BadRequest();
            }
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
