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
    public class MaterialsController : ControllerBase
    {
        private readonly MaterialService _service;

        public MaterialsController(MaterialService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Material>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetMaterial")]
        public ActionResult<Material> Get(string id)
        {
            var material = _service.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        [HttpPost]
        public ActionResult<Material> Create(Material material)
        {
            _service.Create(material);

            return CreatedAtRoute("GetMaterial", new { id = material.Id.ToString() }, material);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Material materialInput)
        {
            var material = _service.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            _service.Update(id, materialInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var material = _service.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}