using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using booking.client.Model;
using booking.flight.Model;
using booking.Services;
using booking.common.ViewModel;

namespace booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IFlightService _flightService;
        private readonly IAircraftService _aircraftService;

        public BookingController(IHttpClientFactory clientFactory,
            IOrderService orderService,
            IClientService clientService,
            IFlightService flightService,
            IAircraftService aircraftService)
        {
            this.clientFactory = clientFactory;
            _orderService = orderService;
            _clientService = clientService;
            _flightService = flightService;
            _aircraftService = aircraftService;
        }

        public class Res
        {
            public IEnumerable<ClientModel> Clients { get; set; }
            public IEnumerable<AircraftModel> Aircrafts { get; set; }
            public IEnumerable<FlightModel> Flights { get; set; }
            public IEnumerable<OrderModel> Orders { get; set; }

        }

        //вывести все данные
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var res = new Res();
            res.Clients = await _clientService.GetAll(0, 0);
            res.Aircrafts = await _aircraftService.GetAll(0, 0);
            res.Flights = await _flightService.GetAll(0, 0);
            res.Orders = await _orderService.GetAll(0, 0);
            return Ok(res);
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
                //1. Get заказов по полю id рейса.
                //это работает 
                var response1 = await client.GetStringAsync("http://localhost:5000/api/order/getbyflightid?id=" + id);
                //
                //var response2 = new HttpRequestMessage(HttpMethod.Get,"http://localhost:5000/api/order/getbyflightid?id=" + id);
                //var res2 = await client.SendAsync(response2);


                //var request1 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/getflight");
                //var res1 = await client.SendAsync(request1);
                //var request2 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5020/api/flight/delete");
                //var res2 = await client.SendAsync(request2);
                return Ok(response1);
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
