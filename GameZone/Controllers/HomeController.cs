using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
