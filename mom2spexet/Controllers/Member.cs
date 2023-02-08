using Microsoft.AspNetCore.Mvc;

namespace mom2spexet.Controllers
{
    public class Member : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
