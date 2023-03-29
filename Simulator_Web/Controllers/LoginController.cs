using Microsoft.AspNetCore.Mvc;
using Simulator_Web.Db;
using Simulator_Web.Models;
using System.Xml.Linq;

namespace Simulator_Web.Controllers
{
    public class LoginController : Controller
    {
        DataContext dataContext = new DataContext(); 

        public ActionResult Index()
        {
            if(HttpContext.Session.Get("Login") is not null)
            {
                return RedirectToAction("Index","Home");
            }

            //var a = HttpContext.Session.Get("Login");
            //HttpContext.Session.SetString("Login", "True");
            //var ab = HttpContext.Session.Get("Login");
            string name = "New Name";
            return View("Login");
        }

        public ActionResult Login()
        {
        
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {

            }
            else
            {
                var a = dataContext.loginDatas.Where(x => x.usr == Email).FirstOrDefault();
                if (a is not null)
                {
                    Password = Hasher.HashData(Password);
                    if (a.pw == Password)
                    {
                        HttpContext.Session.SetString("Login", "True");
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewData["Error"] = "Bad username or password";
            }
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(string Email, string Password1, string Password2)
        {

            if (Password1.Equals(Password2))
            {
                var myUser = dataContext.loginDatas.Where(x=>x.usr == Email).FirstOrDefault();
                if(myUser is null) 
                {
                    Password1 = Hasher.HashData(Password1);
                    dataContext.loginDatas.Add(new LoginData()
                    {
                        usr = Email,
                        pw = Password1,

                    });
                    dataContext.SaveChanges();
                    HttpContext.Session.SetString("Login", "True");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Error"] = "User name is already taken";
                }
            }
            else
            {
                ViewData["Error"] = "The two passwords were not match";
            }
            return View("Register");
        }
    }
}
