namespace GameZone.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game game { get; set; }
        public int DeviceId { get; set; }
        public Device device { get; set; }
    }
}
