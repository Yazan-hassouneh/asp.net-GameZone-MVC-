using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Category
{
	public interface ICategoriesServices
	{
		public IEnumerable<SelectListItem> GetSelectListItems();
	}
}
