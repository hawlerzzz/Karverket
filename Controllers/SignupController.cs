using Microsoft.AspNetCore.Mvc;

namespace Karverket.Controllers
{

    [AutoValidateAntiforgeryToken]
    public class SignupController : Controller
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

        public IActionResult Signup(string error)
        {
            ViewData["error"] = error;
            return View();
        }

        //[HttpPost]
        //public IActionResult CreateAccount(string name, string surname, string email, string password) // makes a a new user
        //{
        //    try
        //    {
        //        CreateUser(name, surname, email, password);
        //    }
        //    catch (EmailExists ex)
        //    {
        //        //return Json("Email exists man");
        //        return RedirectToAction("signup", new {error = "Epost er allerede brukt!"});
        //    }
        //    // Then Login to this user
        //    LogUserIn(email, password);
        //    return RedirectToAction("kart");
        //}
    }
}
