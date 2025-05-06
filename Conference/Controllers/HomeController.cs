using System.Diagnostics;
using Conference.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
// checking git repo push!
namespace Conference.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Past data to the View using ViewBag 
            ViewBag.ConferenceName = "Tech summit 2025";
            ViewBag.ConferenceDate = "June 15-17, 2025";
            ViewBag.ConferenceLocation = "San Francisco, CA";

            return View();
         
        }

        // GET: Home/Register
        [HttpGet]
        public IActionResult Register()
        {
            // Create a list of workshop options to display in the form
            ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };

            return View();
        }

        // POST : Home/Register
        [HttpPost]
        public ActionResult Register(RegistrationViewModels registrationViewModels)
        {
            if (ModelState.IsValid)
            {
                // In a real application, we would save to a database here
                // For this demo, we'll just set an ID and registration date
                registrationViewModels.ID = new Random().Next(1000, 9999); // Generate a random ID
                registrationViewModels.RegistrationDate = DateTime.Now;

                ViewBag.Registration = registrationViewModels;

                return View("Confirmation", registrationViewModels); /*go to the registration model without go to the action */
            }

            // Create a list of workshop options to display in the form
            ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };
            return View(registrationViewModels);
        }

        // GET: Home/Confirmation/123
        public ActionResult Confirmation()
        {
            var registration = ViewBag.Registration;
            if (registration == null)
            {
                return RedirectToAction("Index");
            }
            return View(registration);
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
        public IActionResult Hello()
        {
            return View();
        }

    }
}
