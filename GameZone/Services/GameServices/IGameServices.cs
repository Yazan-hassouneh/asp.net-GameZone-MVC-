namespace GameZone.Services.GameServices
{
	public interface IGameServices
	{
		Task Create(CreateGameVM newGame);
	}
}
