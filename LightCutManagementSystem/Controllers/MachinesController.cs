using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightCut.Management.System.Models;
using LightCutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightCutAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly MachineService _service;

        public MachinesController(MachineService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Machine>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetMachine")]
        public ActionResult<Machine> Get(string id)
        {
            var machine = _service.Get(id);

            if (machine == null)
            {
                return NotFound();
            }

            return machine;
        }

        [HttpPost]
        public ActionResult<Machine> Create(Machine machine)
        {
            _service.Create(machine);

            return CreatedAtRoute("GetMachine", new { id = machine.Id.ToString() }, machine);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Machine machineInput)
        {
            var machine = _service.Get(id);

            if (machine == null)
            {
                return NotFound();
            }

            _service.Update(id, machineInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var machine = _service.Get(id);

            if (machine == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}