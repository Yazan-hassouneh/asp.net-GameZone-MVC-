using GameZone.Configuration.ModelConfig;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options) : base(options)
        {    
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevice { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new DeviceConfig());
            modelBuilder.ApplyConfiguration(new GameDeviceConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }

    }
}
