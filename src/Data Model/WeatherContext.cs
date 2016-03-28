using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace EFCoreWebAPI.Data
{
    public class WeatherContext : DbContext
    {
           private WeatherContext()
        { }
        
         public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options){}
     

        public WeatherContext(IServiceProvider serviceProvider, DbContextOptions<WeatherContext> options)
            : base(serviceProvider, options)
        { }
        public DbSet<WeatherEvent> WeatherEvents { get; set; }
    }
}