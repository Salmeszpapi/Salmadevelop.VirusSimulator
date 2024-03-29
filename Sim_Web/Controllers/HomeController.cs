﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
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
        [Route("Home/Panel")]
        public IActionResult Panel()
        {
            //if (HttpContext.Session.Get("Login") is null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            var simulationCounts = dataContext.simulationRuns.ToList().Count;
            var virusTyepsCount = dataContext.VirusData.ToList().Count;
            ViewData["simulationCounts"] = simulationCounts;
            ViewData["virusTyepsCount"] = virusTyepsCount;

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
                var solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                startInfo.Arguments = $@"cd {solutionPath}\VirusSimulator-UI\bin\Debug\net6.0;& {solutionPath}\VirusSimulator-UI\bin\Debug\net6.0\VirusSimulator_UI.exe";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Panel");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CreateVirus(string Name, int ProbabilityToDead,int IncubationTime,int InfectionSeverity, int ProbabilityToCure)
        {
            ViewData["Error"] = "";
            if (string.IsNullOrEmpty(Name))
            {
                ViewData["Error"] = "Please set password or user correctly";
            }
            else
            {
                var virusName = dataContext.VirusData.Where(x => x.Name == Name).FirstOrDefault();
                if (virusName is null)
                {
                    var a = (double)ProbabilityToCure / 10;
                    dataContext.VirusData.Add(new Virus()
                    {
                        Name = Name,
                        IncubationTime = (double)IncubationTime,
                        ProbabilityToDead = (double)ProbabilityToDead / 100,
                        ProbabilityToCure = (double)ProbabilityToCure / 100,
                        InfectionSeverity = (double)InfectionSeverity / 100,
                    });
                    dataContext.SaveChanges();

                }
                else
                {
                    ViewData["Error"] = "Bad username or password";
                }
                
            }
            return View();

        } 
        public IActionResult Result(int id)
        {
            ViewData["SimulationIdList"] = SimulationIdreturner();
            if (id == 0)
            {
                return View();
            }
            return View(SeparateVirusRuns(id));
        }

        private List<SimulationData> SeparateVirusRuns(int id)
        {
            var myAllSimulatedData = dataContext.simulationDatas.Where(x => x.SimulationId == id).ToList();
            List<List<SimulationData>> simulationDatasList = new List<List<SimulationData>>();
            
            return myAllSimulatedData;
        }
        private List<int> SimulationIdreturner()
        {
            var mySimulatedRuns = dataContext.simulationRuns.Select(x =>x.Id).ToList();
            //var myAllSimulatedData = dataContext.simulationDatas.ToList();
            //List<int> mySimulationIds = new List<int>();
            //int? a = null; 

            //foreach (var item in myAllSimulatedData)
            //{
            //    if(a is null)
            //    {
            //        a = item.SimulationId;
            //        mySimulationIds.Add(item.SimulationId);
            //    }
                
            //    if(a != item.SimulationId)
            //    {
            //        a = item.SimulationId;
            //        mySimulationIds.Add(item.SimulationId);
            //    }
                
            //}


            return mySimulatedRuns;
        }
    }
}