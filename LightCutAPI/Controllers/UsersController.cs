using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightCutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightCutAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
    }
}