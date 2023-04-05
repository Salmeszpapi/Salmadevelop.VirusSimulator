using Microsoft.AspNetCore.Mvc;
using Sim_Web.Db;
using Sim_Web.Models;

namespace Sim_Web.Controllers
{
    public class LoginController : Controller
    {
        DataContext dataContext = new DataContext();
        [Route("")]
        public ActionResult Index()
        {
            if (HttpContext.Session.Get("Login") is not null)
            {
                return RedirectToAction("Panel", "Home");
            }
            ViewData["Title"] = "Login page";
            //var a = HttpContext.Session.Get("Login");
            //HttpContext.Session.SetString("Login", "True");
            //var ab = HttpContext.Session.Get("Login");
            return View("Login");
        }
        [Route("Login")]
        public ActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string Email, string Password1)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password1))
            {
                ViewData["Error"] = "Please set password or user correctly";
            }
            else
            {
                var user = dataContext.loginDatas.Where(x => x.usr == Email).FirstOrDefault();
                if (user is not null)
                {
                    Password1 = Hasher.HashData(Password1);
                    if (user.pw == Password1)
                    {
                        HttpContext.Session.SetString("Login", "True");
                        return RedirectToAction("Panel", "Home");
                    }
                }
                ViewData["Error"] = "Bad username or password";
            }
            return View("Login");
        }
        [Route("Register")]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(string Email, string Password1, string Password2)
        {
            if(Password1 is not null && Password2 is not null && Email is not null)
            {
                if (Password1.Equals(Password2))
                {
                    var myUser = dataContext.loginDatas.Where(x => x.usr == Email).FirstOrDefault();
                    if (myUser is null)
                    {
                        Password1 = Hasher.HashData(Password1);
                        dataContext.loginDatas.Add(new LoginData()
                        {
                            usr = Email,
                            pw = Password1,

                        });
                        dataContext.SaveChanges();
                        HttpContext.Session.SetString("Login", "True");
                        return RedirectToAction("Panel", "Home");
                    }
                    else
                    {
                        ViewData["Error"] = "User name is already taken";
                    }
                }
                else
                {
                    ViewData["Error"] = "The two passwords did not match";
                }
            }
            ViewData["Error"] = "Please set password or user correctly";
            return View("Register");
        }
    }
}
