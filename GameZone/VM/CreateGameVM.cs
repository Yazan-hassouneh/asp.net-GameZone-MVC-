using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModel
{
    public class CreateGameVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<int> SelectedDevices { get; set; }
        public IEnumerable<SelectListItem> Devices { get; set; }
    }
}
