using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LightCutManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

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

        [HttpGet]
        public async Task<ActionResult> Login(string username, string password)
        {
            var response = await _httpClient.GetAsync(string.Format(_config["ApiBaseUrl"] + ":" + _config["ApiPort"] + "/v1/users/username={0}&password={1}", username, password));

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return dashboard.Index();
            } else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                ViewData["result"] = "Password errada.";
            } else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                ViewData["result"] = "Username não encontrado.";
            }

            return View("~/Views/Home/Index.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
