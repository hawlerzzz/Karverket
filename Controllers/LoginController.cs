using Karverket.DAL;
using Karverket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Karverket.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;

            // Check if there is a user with the ADMIN role
            if (!_context.Users.Any(u => u.Role == "ADMIN"))
            {
                var adminUser = new User
                {
                    Name = "Admin",
                    SurName = "User",
                    Email = "admin@kartverket.no",
                    Password = "1234", // Replace with hashed password in production
                    Role = "ADMIN",
                    Fylke = "Agder"
                };

                _context.Users.Add(adminUser);
                _logger.LogInformation("Created default admin user: admin@kartverket.no");
            }

            if (!_context.Users.Any(u => u.Role == "SAKSBEHANDLER"))
            {
                var fylker = new List<string>
                {
                    "Oslo",
                    "Viken",
                    "Innlandet",
                    "Vestfold og Telemark",
                    "Agder",
                    "Rogaland",
                    "Vestland",
                    "Møre og Romsdal",
                    "Trøndelag",
                    "Nordland",
                    "Troms og Finnmark"
                };

                foreach (var fylke in fylker)
                {
                    var saksbehandler = new User
                    {
                        Name = $"Saksbehandler-{fylke}",
                        SurName = "User",
                        Email = $"{fylke.Replace(" ", "").ToLower()}@kartverket.no",
                        Password = "1234", // Replace with hashed password in production
                        Role = "SAKSBEHANDLER",
                        Fylke = fylke
                    };

                    _context.Users.Add(saksbehandler);
                }

                //_context.SaveChanges(); // Save all new users to the database
            }

            _context.SaveChanges();
        }

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
