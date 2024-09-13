using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Device
{
	public class DevicesServices : IDevicesServices
	{
		private readonly GameZoneDbContext _db;
        public DevicesServices(GameZoneDbContext db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
		{
			return [.._db.Devices.Select(d => new SelectListItem
			{
				Value = d.Id.ToString(),
				Text = d.Name,
			}).OrderBy(d => d.Text).AsNoTracking()];
		}
	}
}
