using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StateManagementMVC.Models;
using System.Diagnostics;

namespace StateManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }




        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string email = form["email"];
            //set cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            options.Path = "/";
            //options.Secure = true;
            //options.HttpOnly = true; // cookie can be read using client side script --> javascript / vbscript
            // Response property is used to write to cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("email", email, options);

            return RedirectToAction("ReadCookie", "ReadCookieSession");
        }

        public IActionResult WorkingWithSession()
        {

            return View();
        }
        [HttpPost]
        public IActionResult WorkingWithSession(IFormCollection form)
        {
            string email = form["email"];
            HttpContext.Session.SetString("email", email);
            //  HttpContext.Session.SetString("roleId", "2");

            // clear the value from session
            //HttpContext.Session.Clear();
            return RedirectToAction("ReadSession", "ReadCookieSession");
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
    /*public void Test()
    {
        //write-->Can be write on any action
        Users users = new Users();
        users.Id = 1;
        users.EName = "Rohit@gmail.com";
        string str = JsonConvert.SerializeObject(users);
        HttpContext.Session.setString("users", str);
        //Read--> can be o anather action

        var key = HttpContext.Session.GetString("users");
        var result = JsonConvert.DeserializeObject<Users>(Key);

    }
    public class Users
    {
        public int Id { get; set; }
        public string EName { get; set; }
    }*/
}