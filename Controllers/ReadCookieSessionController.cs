using Microsoft.AspNetCore.Mvc;

namespace StateManagementMVC.Controllers
{
    public class ReadCookieSessionController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor1;  
        public ReadCookieSessionController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor1 = httpContextAccessor;
        }
        public IActionResult ReadCookie ()
        {
            if(_httpContextAccessor1.HttpContext != null)
            {
                ViewBag.Email = _httpContextAccessor1.HttpContext.Request.Cookies["email"];
            }
            return View();
        }
        public IActionResult ReadSession()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            //string role=HttpContext.Session.GetString("roleId");
            return View();
        }

    }
}
