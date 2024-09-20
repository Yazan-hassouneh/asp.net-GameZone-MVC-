namespace GameZone.Settings
{
	public static class FileSettings
	{
		public const string GamesCoversPath = "/Assets/Img/GamesCovers/";
		public const string AllowedExtension = ".jpeg,.jpg,.png";
		public const int CoverMaxSizeInMB = 1;
		public const int CoverMaxSizeInBytes = CoverMaxSizeInMB * 1024 * 1024;
	}
}
