using Microsoft.AspNetCore.Mvc;

namespace LightCutManagement.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}