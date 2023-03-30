using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sim_Web.Db;
using Sim_Web.Models;
using System.Diagnostics;

namespace Sim_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataContext dataContext = new DataContext();
        private readonly IWebHostEnvironment _env;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }

        public IActionResult Index()
        {
            
            //if (HttpContext.Session.Get("Login") is null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            return View();
        }
        public IActionResult Panel()
        {
            //if (HttpContext.Session.Get("Login") is null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            var simulationCounts = dataContext.simulationRuns.ToList().Count;
            ViewData["simulationCounts"] = simulationCounts;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult StartApp()
        {
            try
            {
                var content = _env.ContentRootPath;
                string webroot = _env.WebRootPath;


                var filename = "C:\\Diploma\\ApplicationCore\\VirusSimulator-UI\\bin\\Debug\\net6.0\\VirusSimulator_UI.exe";
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput= true;
                process.StartInfo.UseShellExecute= false;
                process.StartInfo.CreateNoWindow= true;
                process.StartInfo.FileName= filename;
                process.Start();

            }catch(Exception ex)
            {

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}