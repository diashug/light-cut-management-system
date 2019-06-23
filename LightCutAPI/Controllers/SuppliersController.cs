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
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _service;

        public SuppliersController(SupplierService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Supplier>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetSupplier")]
        public ActionResult<Supplier> Get(string id)
        {
            var client = _service.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Supplier> Create(Supplier supplier)
        {
            _service.Create(supplier);

            return CreatedAtRoute("GetSupplier", new { id = supplier.Id.ToString() }, supplier);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Supplier supplierInput)
        {
            var supplier = _service.Get(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _service.Update(id, supplierInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var supplier = _service.Get(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}