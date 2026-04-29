using Microsoft.AspNetCore.Mvc;
using MVCObligatorio2.Models;
using System.Diagnostics;

namespace MVCObligatorio2.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            if(HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                return RedirectToAction("Index","Login");
            }
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
