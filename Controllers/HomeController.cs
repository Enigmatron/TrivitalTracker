using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrivitalTracker.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


//NOTE Cookies:https://docs.microsoft.com/en-us/previous-versions/aspnet/ms178194(v=vs.100)
namespace TrivitalTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            //NOTE https://stackoverflow.com/questions/14138872/how-to-use-sessions-in-an-asp-net-mvc-4-application
            //NOTE https://docs.microsoft.com/en-us/previous-versions/aspnet/ms178581(v=vs.100)?redirectedfrom=MSDN
            //TODO redirect and add cookie for the session
            //Session["User"] != null
            return View();
        } 
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var context = new UserContext();

            //TODO Add authentication
            var auth = context.User
                        .Where(user => user.Username == username && user.Password == password)
                        .Single<User>();
            if(auth != null)
            {
                return Redirect("Account/Index");
            }
            // TempData["loginMessage"] = "error: username or password is incorrect"; //flash memory that has to be typecasted
            // TempData.Keep("loginMessage"); //ensures temp data of the name is kept between calls
            ViewBag.Message = "error: username or password is incorrect";
            return RedirectToAction("Login");
        }

        //NOTE https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(string username, string password, string email, string displayName)
        {
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
