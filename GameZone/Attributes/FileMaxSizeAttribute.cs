using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class FileMaxSizeAttribute : ValidationAttribute
	{
		private readonly int _maxSize;
		public FileMaxSizeAttribute(int maxSize) 
		{ 
			_maxSize = maxSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;

			if(file is not null)
			{
				if(file.Length > _maxSize)
				{
					return new ValidationResult("File Is Too Large");
				}
			}
			return ValidationResult.Success;
		}

	}
}
