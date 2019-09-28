using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LightCutManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace LightCutManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly DashboardController dashboard = new DashboardController();
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("username={username}&password={password}", Name = "Login")]
        public async Task<Dictionary<string, object>> Login(string username, string password)
        {
            var response = await _httpClient.GetAsync(string.Format(_config["ApiBaseUrl"] + ":" + _config["ApiPort"] + "/v1/users/{0}/{1}", username, password));

            var data = new Dictionary<string, object>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                data.Add("error", false);
            } else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                data.Add("error", true);
                data.Add("message", "Acesso não autorizado.");
            } else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                data.Add("error", true);
                data.Add("message", "Username não encontrado.");
            }

            return data;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
