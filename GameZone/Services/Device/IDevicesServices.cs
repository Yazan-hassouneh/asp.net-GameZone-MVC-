using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Device
{
	public interface IDevicesServices
	{
		IEnumerable<SelectListItem> GetSelectListItems();
	}
}
