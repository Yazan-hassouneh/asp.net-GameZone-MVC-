namespace GameZone.Services.GameServices
{
	public interface IGameServices
	{
		IEnumerable<Game> GetAll();
		Task Create(CreateGameVM newGame);
	}
}
