using GameZone.Configuration.BaseNodelConfig;
using GameZone.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Configuration.ModelConfig
{
    public class CategoryConfig : BaseModelConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
        }
    }
}
