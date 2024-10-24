using Karverket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Karverket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<AreaChange> changesList = new List<AreaChange>();

        private static List<PositionModel> positions = new List<PositionModel>();
        private static List<User> users = new List<User>();
        private static User? currentUser;




        // private method that creates user 
        private User CreateUser(string name, string surname, string email, string password) /* Skal ligge i signup controller når databasen er klar */
        {

            // check that the email does not exist
            //throw new EmailExists(email);

            // check that password length is correct
            //throw new ShortPassword(password);

            // check that name length is valid
            //throw new ShortName(name);

            // check that surname length is valid
            //throw new ShortName(surname);

            var User1 = new User
            {
                Id = 1, // should be auto increment in DB
                Name = name,
                SurName = surname,
                Email = email,
                Password = password
            };
            users.Add(User1);
            return User1;
        }

        private User LogUserIn(string email, string password) /* Skal ligge i login controller når databasen er klar */
        {
            // Get from db a user with this email
            User? user = users.Find(u => u.Email == email);

            if (user == null)
            {
                Console.WriteLine($"user does not exist  {email}");
                throw new UserDoesNotExist(email);
            }

            // check that the passwords match
            if (user.Password != password)
            {
                Console.WriteLine($"passwords don't match  {password}");
                throw new WrongPassword(password);
            }

            // set the current user to this user
            currentUser = user;
            Console.WriteLine($"Logged user in  {email}");
            Console.WriteLine(currentUser);

            return user;
        }

        private void LogUserOut()
        {
            // make currentUser empty
            currentUser = null;
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            //ViewData["error"] = error;
            //return View();
            if (currentUser == null)
            {
                return RedirectToAction("index", "login");
            }
            return View("kart");
        }

        [HttpPost]
        public IActionResult RegisterAreaChange(string geoJson, string description)
        {
            var newChange = new AreaChange
            {
                Id = Guid.NewGuid().ToString(),
                GeoJson = geoJson,
                Description = description
            };

            //Save the change in the static in-memory list
            changesList.Add(newChange);

            // Redirect to the overview of changes
            return RedirectToAction("endringer");
        }

        [HttpPost] /* Skal ligge i login controller når databasen er klar */
        public IActionResult Login(string email, string password)
        {
            try
            {
                User? user = LogUserIn(email, password);
            }
            catch
            {
                return RedirectToAction("index", "login",new { error = "feil e-post eller passord" });
            }

            return RedirectToAction("index");
        }

        public IActionResult Endringer()
        {
            return View(changesList);
        }

        public IActionResult Privacy()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateAccount(string name, string surname, string email, string password) // makes a a new user. skal ligge i signup controller når DB er klar
        {
            try
            {
                CreateUser(name, surname, email, password);
            }
            catch (EmailExists ex)
            {
                return RedirectToAction("index", "signup", new { error = "Epost er allerede brukt!" });
            }

            LogUserIn(email, password);

            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CorrectMap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CorrectMap(PositionModel model)
        {
            if (ModelState.IsValid)
            {
                positions.Add(model);

                return View("CorrectionOverview", positions);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CorrectionOverview()
        {
            return View(positions);
        }


        public IActionResult Logout() 
        {
            LogUserOut();
            return RedirectToAction("index", "login");
        }

        public IActionResult ViewUsers() /* for testing only */
        {
            return Json(users);
        }

        public IActionResult Profile()
        {
            return View(currentUser);
        }

    }
}
