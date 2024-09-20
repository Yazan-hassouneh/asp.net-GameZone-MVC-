using GameZone.Services.GameServices;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameServices _gameServices;
        public HomeController(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }
        public IActionResult Index()
        {
            var games = _gameServices.GetAll();
            return View(games);
        }
    }
}
