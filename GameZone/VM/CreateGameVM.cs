using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
    public class CreateGameVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [AllowedExtentions(FileSettings.AllowedExtension)]
        [FileMaxSize(FileSettings.CoverMaxSizeInBytes)]
        public IFormFile Cover { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedDevices { get; set; } = [];
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>(); 
    }
}
