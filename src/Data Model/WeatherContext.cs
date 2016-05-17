using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCoreWebAPI.Data
{
    public class WeatherContext : DbContext
    {
           private WeatherContext()
        { }
        
         public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options){}
     
//causing error in RC2 but need this for my tests : deal with it later
        // public WeatherContext(IServiceProvider serviceProvider, DbContextOptions<WeatherContext> options)
        //     : base(serviceProvider, options)
        // { }
        public DbSet<WeatherEvent> WeatherEvents { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //quick and dirty takes care of my entities not all scenarios
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entity.Name).ToTable(entity.ClrType.Name + "s");
        }
        }
    }
}