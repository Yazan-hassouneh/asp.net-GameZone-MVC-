using GameZone.Configuration.BaseNodelConfig;
using GameZone.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Configuration.ModelConfig
{
    public class GameConfig : BaseModelConfig<Game>
    {
        public override void Configure(EntityTypeBuilder<Game> builder)
        {
            base.Configure(builder);
            builder.Property(model => model.Description).HasMaxLength(2500);
            builder.Property(model => model.Cover).HasMaxLength(255);
        }
    }
}
