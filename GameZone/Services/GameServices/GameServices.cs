
using GameZone.Settings;

namespace GameZone.Services.GameServices
{
	public class GameServices : IGameServices
	{
		private readonly GameZoneDbContext _db;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _gameCoversPath;
		public GameServices(GameZoneDbContext db, IWebHostEnvironment webHostEnvironment)
		{
			_db = db;
			_webHostEnvironment = webHostEnvironment;
			_gameCoversPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.GamesCoversPath}";
		}
		public async Task Create(CreateGameVM newGame)
		{
			string coverName = $"{Guid.NewGuid()}{Path.GetExtension(newGame.Cover.FileName)}";
			var path = Path.Combine(_gameCoversPath, coverName);

			using var stream = File.Create(path);
			await newGame.Cover.CopyToAsync(stream);
			stream.Dispose();

			Game game = new()
			{
				Name = newGame.Name,
				Description = newGame.Description,
				Cover = coverName,
				CategoryId = newGame.CategoryId,
				Devices = newGame.SelectedDevices.Select(device => new GameDevice
				{
					DeviceId = device
				}).ToList()
			};

			_db.Games.Add(game);
			_db.SaveChanges();
		}
	}
}
