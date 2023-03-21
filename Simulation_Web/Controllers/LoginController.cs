using Microsoft.AspNetCore.Mvc;

namespace Simulation_Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
