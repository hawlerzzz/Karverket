using Karverket.DAL;
using Karverket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Karverket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private static List<AreaChange> changesList = new List<AreaChange>();
        private static List<PositionModel> positions = new List<PositionModel>();
        private static List<User> users = new List<User>();
        private static User? currentUser;
        private static bool isPrioritisedUser = false;
        private static bool isInternalUser = false;

        // private method that creates user 
        private User
            CreateUser(string name, string surname, string email,
                string password) /* Skal ligge i signup controller n r databasen er klar */
        {

            var User1 = new User
            {
                Name = name,
                SurName = surname,
                Email = email,
                Password = password
            };
            _context.Users.Add(User1);
            _context.SaveChanges();
            return User1;
        }

        private User LogUserIn(string email, string password) /* Skal ligge i login controller n r databasen er klar */
        {
            // Get from db a user with this email
            User? user = _context.Users.SingleOrDefault(u => u.Email == email);

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

            if (user.Role == "SAKSBEHANDLER" || user.Role == "ADMIN")
            {
                isInternalUser = true;
            }
            if (email.EndsWith("@politi.no", StringComparison.OrdinalIgnoreCase))
            {
                isPrioritisedUser = true;
            }
            if (email.EndsWith("@brannvesen.no", StringComparison.OrdinalIgnoreCase))
            {
                isPrioritisedUser = true;
            }
            if (email.EndsWith("@ambulanse.no", StringComparison.OrdinalIgnoreCase))
            {
                isPrioritisedUser = true;
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
            isPrioritisedUser = false;
            isInternalUser = false;
        }


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            if (currentUser == null)
            {
                return RedirectToAction("index", "login");
            }


            var newChange = new AreaChange
            {
                Id = Guid.NewGuid().ToString(),
                Type = "land",
                Fylke = "fylke",
                Date = DateTime.Today,
                GeoJson = "geoJson",
                Description = "description"
            };

            //Save the change in the static in-memory list
            //changesList.Add(newChange);
            //changesList.Add(newChange);
            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;
            return View("kart");
        }


        public IActionResult SeIKart(int Id)
        {




            var innmelding = _context.Innmeldinger1
            .Where(i => i.Id == Id)
            .FirstOrDefault();
            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;
            ViewBag.Geojson = innmelding.GeoJson;
            return View("kart");
        }

        [HttpPost]
        public IActionResult RegisterAreaChange(string geoJson, string type, string fylke, string description)
        {
            var caseManager = _context.Users
            .FirstOrDefault(u => u.Role == "SAKSBEHANDLER" && u.Fylke == fylke);

            var newChange = new Innmelding
            {
                Type = type,
                Fylke = fylke,
                Date = DateTime.Today,
                GeoJson = geoJson,
                Description = description,
                UserId = currentUser.Id,
                Prioritised = isPrioritisedUser,
                CaseManagerId = caseManager.Id
            };


            _context.Innmeldinger1.Add(newChange);
            _context.SaveChanges();


            // Redirect to the overview of changes
            return RedirectToAction("innmeldingbekreftelse");
        }

        [HttpPost] /* Skal ligge i login controller n r databasen er klar */
        public IActionResult Login(string email, string password)
        {
            try
            {
                User? user = LogUserIn(email, password);
            }
            catch
            {
                return RedirectToAction("index", "login", new { error = "feil e-post eller passord" });
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
        public IActionResult
            CreateAccount(string name, string surname, string email,
                string password) // makes a a new user. skal ligge i signup controller n r DB er klar
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

        public IActionResult admin()
        {
            
            if (currentUser == null || currentUser.Role != "ADMIN")
            {
                return RedirectToAction("index", "Login");
            }
            var innmeldinger = _context.Users
            .ToList();
            return View(innmeldinger);
        }


        public IActionResult Logout()
        {
            LogUserOut();
            return RedirectToAction("index", "login");
        }

        public IActionResult Profile()

        {
            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;

            return View(currentUser);




        }

        public IActionResult Inbox()
        {
            var innmeldinger = _context.Innmeldinger1
            .Where(i => i.UserId == currentUser.Id)
            .ToList();

            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;

            return View(innmeldinger);
        }

        public IActionResult Innmeldinger(string? type, string? fylke)
        {
            // Redirect if not an internal user
            if (!isInternalUser)
            {
                return RedirectToAction("index");
            }

            // Filter innmeldinger based on current user, status, type, and fylke
            var innmeldinger = _context.Innmeldinger1
                .Where(i => i.CaseManagerId == currentUser.Id)
                .Where(i => i.Status == "Pending")
                .Where(i => string.IsNullOrEmpty(type) || i.Type == type)
                .Where(i => string.IsNullOrEmpty(fylke) || i.Fylke == fylke)
                .OrderByDescending(i => i.Date)
                .ToList();

            // Set ViewBag properties
            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;

            return View(innmeldinger);
        }

        public IActionResult Innmelding(string id, string color)
        {
            // Hent innmelding basert på id
            var innmelding = _context.Innmeldinger1.FirstOrDefault(i => i.Id == int.Parse(id));

            // Hent alle saksbehandlere fra databasen
            var saksbehandlere = _context.Users
                .Where(i => i.Role == "SAKSBEHANDLER")
                .ToList();

            var innmeldingOgSaksbehandlere = new InnmeldingerSaksbehandlere
            {
                Saksbehandlere = saksbehandlere,
                innmelding = innmelding
            };

            // Hvis ingen farge er angitt, sett standard til "yellow"
            color ??= "yellow";

            ViewBag.Id = id;
            ViewBag.Color = color;
            ViewBag.isPrioritisedUser = isPrioritisedUser;
            ViewBag.isInternalUser = isInternalUser;

            return View(innmeldingOgSaksbehandlere);
        }



        public IActionResult AvvisInnmelding(int id, string melding)
        {
            var innmelding = _context.Innmeldinger1
            .FirstOrDefault(i => i.Id == id);

            if (innmelding != null)
            {

                innmelding.Status = "Declined";
                innmelding.Answer = melding;

                _context.SaveChanges();
            }
            return RedirectToAction("Innmeldinger");
        }

        public IActionResult GodkjennInnmelding(int id, string melding)
        {
            var innmelding = _context.Innmeldinger1
            .FirstOrDefault(i => i.Id == id);

            if (innmelding != null)
            {

                innmelding.Status = "Accepted";
                innmelding.Answer = melding;

                _context.SaveChanges();
            }
            return RedirectToAction("Innmeldinger");
        }

        public IActionResult DelegerInnmelding(int id, int saksbehandler)
        {
            var innmelding = _context.Innmeldinger1
            .FirstOrDefault(i => i.Id == id);

            if (innmelding != null)
            {

                innmelding.CaseManagerId = saksbehandler;

                _context.SaveChanges();
            }
            return RedirectToAction("Innmeldinger");
        }


        public IActionResult AssignRole(int UserId, string Role, string fylke)
        {
            var user = _context.Users
            .FirstOrDefault(i => i.Id == UserId);

            if (user != null)
            {

                user.Role = Role;

                _context.SaveChanges();
            }
            return RedirectToAction("admin");
        }
    }




}
