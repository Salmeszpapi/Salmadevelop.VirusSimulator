using Microsoft.AspNetCore.Mvc;
using Simulation_Web.Db;
using Simulation_Web.Models;
using System.Diagnostics;

namespace Simulation_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(DataContext dataContext)
        {
            dataContext.simulationRuns.Add(new SimulationRun()
            {
                DateOfRun = DateTime.Now,
            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}