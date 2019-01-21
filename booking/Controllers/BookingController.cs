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
        /*1. Get заказов по полю id рейса.
        2.Если не ноль, то запоминаем id заказа. (как тут? десериализовать строку и взять поле?) не совсем понятны действия
        3.Удаляем заказ
        4.Поиск заказа наверное надо зациклить, пока не 0
        5. Get рейса по id, если не 0, то update статус для жтого id
*/
        public async Task<ActionResult<int>> DeleteFlight([FromBody]String id)
        {

            try
            {
                var client = clientFactory.CreateClient();
                //1. Get заказов по полю id рейса.
                var response1 = await client.GetStringAsync("http://localhost:5000/api/order/getbyflightid");
                
                var request1 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/getflight");
                var res1 = await client.SendAsync(request1);
                var request2 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/delete");
                var res2 = await client.SendAsync(request2);
                return Ok(res1);
            }
            catch
            {
                return BadRequest();
            }
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
