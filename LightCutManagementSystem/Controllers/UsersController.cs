using LightCutAPI.Models;
using LightCutAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightCutAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(IConfiguration config)
        {
            _service = new UserService(config);
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{username}/{password}", Name = "Login")]
        public ActionResult<bool> Get(string username, string password)
        {
            if (_service.Get(username, password))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _service.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, User userIn)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            if (_service.Update(id, userIn))
            {
                return Ok();
            }

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Remove(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            if (_service.Remove(id))
            {
                return Ok();
            }

            return NoContent();
        }
    }
}