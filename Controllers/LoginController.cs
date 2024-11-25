using Microsoft.AspNetCore.Mvc;

namespace Karverket.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LoginController : Controller
    {
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
