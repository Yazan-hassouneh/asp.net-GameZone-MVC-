using GameZone.Attributes;
using GameZone.Settings;

namespace GameZone.VM
{
	public class UpdateGameVM : GameVM
	{
        public int Id { get; set; }
        public string? coverPath { get; set; }
        [AllowedExtentions(FileSettings.AllowedExtension)]
		[FileMaxSize(FileSettings.CoverMaxSizeInBytes)]
		public IFormFile? Cover { get; set; }
	}
}
