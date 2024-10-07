using Karverket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Karverket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<AreaChange> changesList = new List<AreaChange>();

        private static List<PositionModel> positions = new List<PositionModel>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Kart()
        {
            return View();
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

        public IActionResult Endringer()
        {
            return View(changesList);
        }

        public IActionResult Privacy()
        {
            return View();

        }

        public IActionResult Signup()
        {
            return View();
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

    }
}
