using Microsoft.EntityFrameworkCore;

namespace EFCoreWebAPI.Data
{
    public class WeatherContext : DbContext
    {
        private WeatherContext()
        { }

        public WeatherContext(DbContextOptions<WeatherContext> options)
       : base(options) { }

        public DbSet<WeatherEvent> WeatherEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //quick and dirty takes care of my entities not all scenarios
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.ClrType.Name + "s");
            }
        }
    }
}