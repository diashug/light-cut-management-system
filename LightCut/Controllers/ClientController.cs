using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LightCut.Models;
using LightCut.Data.Repository;
using System.Linq;

namespace LightCut.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientRepository _clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            if (id != null)
            {
                var client = await _clientRepository.Get(id);

                return client;
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            var clients = await _clientRepository.GetAll();

            return clients.ToArray();
        }

        [HttpPost]
        public ActionResult<Client> Create(string inputData)
        {
            Client client = JsonConvert.DeserializeObject<Client>(inputData);

            if (client != null)
            {
                _clientRepository.Add(client);

                return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(string inputData)
        {
            Client client = JsonConvert.DeserializeObject<Client>(inputData);

            if (client != null)
            {
                if (await _clientRepository.Update(client))
                {
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (id != null)
            {
                if (await _clientRepository.Remove(id))
                {
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest();
        }

        #endregion
    }
}