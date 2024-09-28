

using FluentValidation;
using GameZone.Services.GameServices;
using GameZone.VM;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameServices _gameServices;
        private readonly IValidator<CreateGameVM> _createGameValidator;
        private readonly IValidator<UpdateGameVM> _updateGameValidator;
		public GamesController(ICategoriesServices categoriesServices, IDevicesServices devicesServices, IGameServices gameServices, IValidator<CreateGameVM> createGameValidator, IValidator<UpdateGameVM> updateGameValidator)
		{
			_categoriesServices = categoriesServices;
			_devicesServices = devicesServices;
            _gameServices = gameServices;
            _createGameValidator = createGameValidator;
            _updateGameValidator = updateGameValidator;
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
        public IActionResult Details(int id)
        {
            var game = _gameServices.GetById(id);
            if (game is null) return NotFound();

            return View(game);
        }
        public IActionResult Update(int id)
        {
			var game = _gameServices.GetById(id);
			if (game is null) return NotFound();

            var updateGameView = new UpdateGameVM
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Categories = _categoriesServices.GetSelectListItems(),
                Devices = _devicesServices.GetSelectListItems(),
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(Device => Device.DeviceId).ToList(),
                coverPath = game.Cover,

			};
			return View(updateGameView);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(UpdateGameVM model)
		{
			var modelResult = _updateGameValidator.Validate(model);

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

			var updatedGame = await _gameServices.Update(model);
            if (updatedGame is null) return BadRequest(ModelState);

			return RedirectToAction(nameof(Index));
		}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gameServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
	}
}
