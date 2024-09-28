using GameZone.VM;

namespace GameZone.Services.GameServices
{
	public interface IGameServices
	{
		Game? GetById(int id);
		IEnumerable<Game> GetAll();
		Task Create(CreateGameVM newGame);
		Task<Game?> Update(UpdateGameVM game);
		bool Delete(int id);
	}
}
