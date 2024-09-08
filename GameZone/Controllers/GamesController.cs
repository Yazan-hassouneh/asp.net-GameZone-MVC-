using GameZone.Data;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameZoneDbContext _db;
        public GamesController(GameZoneDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            CreateGameVM vm = new()
            {
                Categories = _db.Categories.Select(c => new SelectListItem { 
                    Value = c.Id.ToString(),
                    Text = c.Name,
                })
                .OrderBy(c => c.Text)
                .ToList(),

                Devices = _db.Devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                })
                .OrderBy(d => d.Text)
                .ToList(),
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(CreateGameVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
	}
}
