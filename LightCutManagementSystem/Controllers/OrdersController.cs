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
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public ActionResult<Order> Get(string id)
        {
            var order = _service.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public ActionResult<Order> Create(Order order)
        {
            _service.Create(order);

            return CreatedAtRoute("GetOrder", new { id = order.Id.ToString() }, order);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Order orderInput)
        {
            var order = _service.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            _service.Update(id, orderInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var order = _service.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return NoContent();
        }
    }
}