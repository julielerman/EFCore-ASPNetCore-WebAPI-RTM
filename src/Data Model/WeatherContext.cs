using Microsoft.Data.Entity;
namespace EF7WebAPI.Data
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherEvent> WeatherEvents { get; set; }
    }
}