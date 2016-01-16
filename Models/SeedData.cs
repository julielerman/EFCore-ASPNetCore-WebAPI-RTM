using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF7WebAPI;
using EF7WebAPI.Data;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace EF7WebApi.Models
{
    public static class SampleData
    {

        public static async Task InitializeWeatherEventDatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<WeatherContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestData(serviceProvider);

                }
            }
        }

        private static async Task InsertTestData(IServiceProvider serviceProvider)
        {
            var weatherEvents = GetWeatherEvents();

                  await AddOrUpdateAsync(serviceProvider, a => a.Id, weatherEvents);
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<WeatherContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<WeatherContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Creates a store manager user who can manage the inventory.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            var appEnv = serviceProvider.GetService<IApplicationEnvironment>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();
        }
        private static WeatherEvent[] GetWeatherEvents()
        {
            var events = new WeatherEvent[]
            {
                WeatherEvent.Create(DateTime.Now,WeatherType.Sun,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-1),WeatherType.Snow,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-2),WeatherType.Rain,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-3),WeatherType.Sleet,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-4),WeatherType.Hail,false)
            };
            return events;
        }
    }
}