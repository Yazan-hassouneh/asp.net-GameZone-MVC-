

using GameZone.Services.GameServices;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameServices _gameServices;
		public GamesController(ICategoriesServices categoriesServices, IDevicesServices devicesServices, IGameServices gameServices)
		{
			_categoriesServices = categoriesServices;
			_devicesServices = devicesServices;
            _gameServices = gameServices;
		}
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            CreateGameVM vm = new()
            {
                Categories = _categoriesServices.GetSelectListItems(),
                Devices =  _devicesServices.GetSelectListItems()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateGameVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectListItems();
                model.Devices = _devicesServices.GetSelectListItems();
                return View(model);
            }

            await _gameServices.Create(model);

            return RedirectToAction(nameof(Index));
        }
	}
}
