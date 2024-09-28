namespace GameZone.VM
{
	public class GameVM
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int CategoryId { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
		public List<int> SelectedDevices { get; set; } = [];
		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
	}
}
