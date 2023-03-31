using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using Sim_Web.Db;
using Sim_Web.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

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
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";

                startInfo.Arguments = @"cd C:\Diploma\ApplicationCore\VirusSimulator-UI\bin\Debug\net6.0;& C:\Diploma\ApplicationCore\VirusSimulator-UI\bin\Debug\net6.0\VirusSimulator_UI.exe";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                string errors = process.StandardError.ReadToEnd();
            }
            catch(Exception ex)
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