using FluentValidation;
using GameZone.VM;

namespace GameZone.Configuration.VMConfig
{
	public class GameVMConfig<T> : AbstractValidator<T> where T : GameVM 
	{
		public GameVMConfig()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Required !").MaximumLength(40).WithMessage("Name Should Not Be More Than 40 Character");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description Is Required !").MaximumLength(1024).WithMessage("Description Should Not Be More Than 1024 Character");
		}
	}
}
