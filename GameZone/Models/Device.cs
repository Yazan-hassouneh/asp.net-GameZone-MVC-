namespace GameZone.Models
{
    public class Device : BaseModel
    {
        public string Icon { get; set; }
        public ICollection<GameDevice> Games { get; set; }
    }
}
