using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Category
{
	public class CategoriesServices : ICategoriesServices
	{
		private readonly GameZoneDbContext _db;
		public CategoriesServices(GameZoneDbContext db) 
		{ 
			_db = db;
		}
		public IEnumerable<SelectListItem> GetSelectListItems()
		{
			return [.. _db.Categories.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			}).OrderBy(c => c.Text).AsNoTracking()];
		}
	}
}
