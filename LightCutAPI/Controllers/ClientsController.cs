using System.Collections.Generic;
using LightCutAPI.Models;
using LightCutAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LightCutAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _service;

        public ClientsController(ClientService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _service.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            _service.Create(client);

            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Client clientIn)
        {
            var client = _service.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _service.Update(id, clientIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var client = _service.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}