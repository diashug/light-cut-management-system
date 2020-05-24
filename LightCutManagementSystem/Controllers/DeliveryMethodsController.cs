using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightCutAPI.Models;
using LightCutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightCutAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DeliveryMethodsController : ControllerBase
    {
        private readonly DeliveryMethodService _service;

        public DeliveryMethodsController(DeliveryMethodService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<DeliveryMethod>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetDeliveryMethod")]
        public ActionResult<DeliveryMethod> Get(string id)
        {
            var deliveryMethod = _service.Get(id);

            if (deliveryMethod == null)
            {
                return NotFound();
            }

            return deliveryMethod;
        }

        [HttpPost]
        public ActionResult<Client> Create(DeliveryMethod deliveryMethod)
        {
            _service.Create(deliveryMethod);

            return CreatedAtRoute("GetDeliveryMethod", new { id = deliveryMethod.Id.ToString() }, deliveryMethod);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, DeliveryMethod deliveryMethodInput)
        {
            var deliveryMethod = _service.Get(id);

            if (deliveryMethod == null)
            {
                return NotFound();
            }

            _service.Update(id, deliveryMethodInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var deliveryMethod = _service.Get(id);

            if (deliveryMethod == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}