
using GameZone.Settings;
using GameZone.VM;
using Microsoft.EntityFrameworkCore;

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
		public Game? GetById(int id)
		{
			return _db.Games
				.Include(game => game.Category)
				.Include(game => game.Devices)
				.ThenInclude(device => device.device)
				.AsNoTracking()
				.FirstOrDefault(game => game.Id == id);
		}
		public IEnumerable<Game> GetAll()
		{
			return _db.Games
				.Include(game => game.Category)
				.Include(game => game.Devices)
				.ThenInclude(device => device.device)
				.AsNoTracking()
				.ToList();	
		}
		public async Task Create(CreateGameVM newGame)
		{
			string coverName = await SaveCover(newGame.Cover);

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
		public async Task<Game?> Update(UpdateGameVM model)
		{
			var game = _db.Games.Include(g => g.Devices).SingleOrDefault(g => g.Id == model.Id);

			if (game is null) return null;

			bool hasNewCover = model.Cover is not null;
			string oldCover = game.Cover;

			game.Name = model.Name;
			game.Description = model.Description;
			game.CategoryId = model.CategoryId;
			game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d}).ToList();

			if(hasNewCover) game.Cover = await SaveCover(model.Cover!);
			
			int effectedRows = _db.SaveChanges();

			if(effectedRows > 0)
			{
				if(hasNewCover) DeleteCover(oldCover);
				return game;
			}

			DeleteCover(game.Cover);
			return null;
		}
		public bool Delete(int id)
		{
			bool isDeleted = false;
			var game = _db.Games.SingleOrDefault(g => g.Id == id);

			if(game is null) return isDeleted;

			_db.Games.Remove(game);

			int effectedRows = _db.SaveChanges();
			if(effectedRows > 0)
			{
				isDeleted = true;
				DeleteCover(game.Cover);
			}

			return isDeleted;
		}
		private async Task<string> SaveCover(IFormFile cover)
		{
			string coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_gameCoversPath, coverName);

			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);
			stream.Dispose();

			return coverName;
		}
		private void DeleteCover(string coverName)
		{
			var cover = Path.Combine(_gameCoversPath, coverName);
			File.Delete(cover);
		}

	}
}
