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
                var clientController = new ClientController();
                var flightController = new FlightController();
                var orderController = new OrderController();
                
                var response1 = await clientController.f_GetAllClients(client);
                var response2 = await flightController.f_GetAllFlights(client);
                var response3 = await flightController.f_GetAllAircrafts(client);
                var response4 = await orderController.f_GetAllOrders(client);

                var res = new Res();
                res.res1 = response1.ToString();
                res.res2 = response2.ToString();
                res.res3 = response3.ToString();
                res.res4 = response4.ToString();
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

        //http://localhost:5000/api/booking/<id>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteFlight(String id)
        {

            try
            {
                var client = clientFactory.CreateClient();

                
                var clientController = new ClientController();
                var flightController = new FlightController();
                var orderController = new OrderController();


                //1. Get заказов по полю id рейса.
                var response11 = await orderController.f_GetbyFlightId(client, id);
                //это работает 
                //var response1 = await client.GetStringAsync("http://localhost:5000/api/order/getbyflightid?id=" + id);
                //
                //var response2 = new HttpRequestMessage(HttpMethod.Get,"http://localhost:5000/api/order/getbyflightid?id=" + id);
                //var res2 = await client.SendAsync(response2);


                //var request1 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/getflight");
                //var res1 = await client.SendAsync(request1);
                //var request2 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/delete");
                //var res2 = await client.SendAsync(request2);
                return Ok(response11);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
      //  [HttpDelete("{id}")]
      //  public void Delete(int id)
      //  {
      //  }
    }
}
