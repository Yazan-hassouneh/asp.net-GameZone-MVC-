

using FluentValidation;
using GameZone.Services.GameServices;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameServices _gameServices;
        private readonly IValidator<CreateGameVM> _createGameValidator;
		public GamesController(ICategoriesServices categoriesServices, IDevicesServices devicesServices, IGameServices gameServices, IValidator<CreateGameVM> createGameValidator)
		{
			_categoriesServices = categoriesServices;
			_devicesServices = devicesServices;
            _gameServices = gameServices;
            _createGameValidator = createGameValidator;
		}
		public IActionResult Index()
		{
			var games = _gameServices.GetAll();
			return View(games);
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
            var modelResult = _createGameValidator.Validate(model);
            if (!modelResult.IsValid)
            {
				foreach (var error in modelResult.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				model.Categories = _categoriesServices.GetSelectListItems();
				model.Devices = _devicesServices.GetSelectListItems();
				return View(model);
			}

            await _gameServices.Create(model);

            return RedirectToAction(nameof(Index));
        }
	}
}
