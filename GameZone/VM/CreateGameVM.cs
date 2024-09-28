using GameZone.Attributes;
using GameZone.Settings;
using GameZone.VM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
    public class CreateGameVM : GameVM
    {
		[AllowedExtentions(FileSettings.AllowedExtension)]
		[FileMaxSize(FileSettings.CoverMaxSizeInBytes)]
		public IFormFile Cover { get; set; }
	}
}
