using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using booking.client.Abstract;
using booking.client.Model;
using booking.common.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace booking.client.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository clientRepository;

        [HttpGet]
        public ActionResult<Client> Get([FromQuery]String id)
        {
            var client = clientRepository.Get(id);
            if (client == null)
            {
                return BadRequest();
            }
            return Ok(client);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Client>> GetAll([FromQuery]int page, [FromQuery]int amount)
        {
            var clients = clientRepository.GetAll();
            if (page != 0 && amount != 0)
            {
                clients = clients.Skip(page * (amount - 1)).Take(amount);
            }
            if (clients == null)
            {
                return BadRequest();
            }
            return Ok(clients);
        }

        [HttpGet("[action]")]
        public ActionResult<int> Count()
        {
            var client = clientRepository.GetAll();
            if (client == null)
            {
                return BadRequest();
            }
            return Ok(client.Count());
        }


        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }


        // добавление клиента
        [HttpPost]
        public ActionResult Post([FromBody]ClientModel model)
        {
            var client = new Client
            {
                Age = model.Age,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Middlename = model.Middlename
            };

            clientRepository.Add(client);
            return Ok();
        }

        // обновление клиента
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody]ClientModel model)
        {
            var client = clientRepository.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Firstname = model.Firstname;
            client.Age = model.Age;
            client.Lastname = model.Lastname;
            client.Middlename = model.Middlename;
            clientRepository.Update(client);

            return Ok();
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            clientRepository.Delete(id);
            return Ok();
        }
    }
}
