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
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        public async Task<Dictionary<string, object>> Login(string username, string password)
        {
            var response = await _httpClient.GetAsync(string.Format(_config["ApiBaseUrl"] + ":" + _config["ApiPort"] + "/v1/users/{0}/{1}", username, password));

            var data = new Dictionary<string, object>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                data.Add("error", false);
            } else
            {
                data.Add("error", true);
                data.Add("message", "Username ou password incorrectos.");
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
