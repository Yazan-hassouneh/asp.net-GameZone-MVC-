using FluentValidation;
using GameZone.VM;

namespace GameZone.Configuration.VMConfig
{
	public class UpdateGameVMConfig : GameVMConfig<UpdateGameVM>
	{
		public UpdateGameVMConfig() : base()
		{
			RuleFor(x => x.coverPath).Null().When(customer => customer.Name == null);
		}

	}
}
