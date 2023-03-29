using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulator_Web.Db;
using Simulator_Web.Models;

namespace Simulator_Web.Controllers
{
    public class HomeController : Controller
    {
        DataContext dataContext = new DataContext();
        // GET: HomeController
        public ActionResult Index()
        {
            //if (HttpContext.Session.Get("Login") is null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            var myListObjects = dataContext.simulationRuns.ToList();
            ViewData["SiteName"] = "Home page";
            return View(myListObjects);
        }
    }
}
