using Microsoft.AspNetCore.Mvc;

namespace mom2spexet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Save title to ViewData
            ViewData["Title"] = "Välkommen";

            return View();
        }
    }
}