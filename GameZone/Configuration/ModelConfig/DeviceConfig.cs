using GameZone.Configuration.BaseNodelConfig;
using GameZone.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Configuration.ModelConfig
{
    public class DeviceConfig : BaseModelConfig<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            base.Configure(builder);
            builder.Property(model => model.Icon).HasMaxLength(250);
        }
    }
}
