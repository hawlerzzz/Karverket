using Microsoft.AspNetCore.Mvc;

namespace Karverket.Controllers
{
    public class LoginController : Controller
    {
        //public IActionResult Index()
        //{
        //    return Json("login");
        //}
        [HttpGet]
        public IActionResult Index(string error)
        {
            ViewData["error"] = error;
            return View();
        }

        public IActionResult Login(string error)
        {
            ViewData["error"] = error;
            return View();
        }
    }
}
