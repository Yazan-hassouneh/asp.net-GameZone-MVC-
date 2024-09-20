namespace GameZone.Models
{
    public class Game : BaseModel
    {
        public string Description { get; set; }
        public string Cover { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<GameDevice> Devices { get; set; } 
    }
}
