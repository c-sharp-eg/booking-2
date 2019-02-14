using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using booking.common.ViewModel;
using Newtonsoft.Json;
using System.Text;
using booking.order.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace booking.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IHttpClientFactory clientFactory;

        public OrderController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public OrderController()
        {
        }


        // GET api/values
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody]OrderModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5030/api/order")
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
        public async Task<ActionResult<int>> GetAllOrders()
        {
            try
            {
                var client = clientFactory.CreateClient();
                var response = await client.GetStringAsync("http://localhost:5030/api/order/GetAllOrders");
                var tt = JsonConvert.DeserializeObject<IEnumerable<Order>>(response);
                return Ok(tt);
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
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5030/api/order");

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
        
        //http://localhost:5000/api/order/getbyflightid?id=<id>
        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetbyFlightId([FromQuery]String id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5030/api/order/GetbyFlightId" +"?flightId=" + id);

                var client = clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                var result = response.Content.ReadAsAsync<int>();
                return Ok(result); 
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
        public async Task<ActionResult> Update(string id, [FromBody]ClientModel model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:5030/api/order" + "/" + id)
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

        // DELETE http://localhost:5000/api/order/<id>
        [HttpDelete("{id}")]
        public async void Delete(string  id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5030/api/order" + "/" + id)
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
