using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using booking.order.Abstract;
using booking.order.Model;
using booking.common.ViewModel;

namespace booking.order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET 
        [HttpGet]
        public ActionResult<Order> Get([FromQuery]String id)
        {
            var order = orderRepository.Get(id);
            if (order == null)
            {
                return BadRequest();
            }
            return Ok(order);
        }

        
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] OrderModel model)
        {
            var order = new Order
            {
                ClientId = model.ClientId,
                FlightId = model.FlightId,
                Status = model.Status,
                Summ = model.Summ
            };

            orderRepository.Add(order);
            return Ok();
        }

        // обновить заказ
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] OrderModel model)
        {
            var order = orderRepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            order.ClientId = model.ClientId;
            order.FlightId = model.FlightId;
            order.Status = model.Status;
            order.Summ = model.Summ;

            orderRepository.Update(order);
            
            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            orderRepository.Delete(id);
            return Ok();
        }
    }
}
