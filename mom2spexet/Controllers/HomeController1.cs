using Microsoft.AspNetCore.Mvc;

namespace mom2spexet.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
