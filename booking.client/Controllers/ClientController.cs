using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using booking.client.Abstract;
using booking.client.Model;
using booking.client.ViewModel;

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

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }


        // добавление клиента
        [HttpPost]
        public ActionResult Post([FromBody]CreateClient model)
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
        public ActionResult Put(String id, [FromBody]CreateClient model)
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
