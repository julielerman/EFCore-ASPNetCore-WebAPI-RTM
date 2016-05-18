using EFCoreWebAPI;
using EFCoreWebAPI.Data;
using EFCoreWebAPI.Controllers;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using Xunit;
using System.Linq;
using Xunit.Abstractions;


namespace EFTests
{

    public class FancierControllerTests
    {
        private ServiceCollection _serviceCollection;
        private DbContextOptions<WeatherContext> _contextOptions;
        private readonly ITestOutputHelper _output; //xunit for writeline


        public FancierControllerTests(ITestOutputHelper output)
        {
            _output = output;
            // Create a service collection that we can create service providers from
            // A service collection defines the services that will be available in service 
            // provider instances (think of it as ServiceProviderBuilder)
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddEntityFramework().AddInMemoryDatabase();

            // Create options to tell the context to use the InMemory database
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseInMemoryDatabase();
            _contextOptions = optionsBuilder.Options;
        }
        [Fact]
        public void CanGetWeatherEvents()
        {
            // All contexts that share the same service provider will share the same InMemory database
            var serviceProvider = _serviceCollection.BuildServiceProvider();
            var context = CreateAndSeedContext();
            using (var controller = new WeatherController(context))
            {
                var results = controller.Get();
                Assert.Equal(7, results.Count());
            }
        }
        
        [Fact]
        public void CanGetWeatherEventsFilteredByDate()
        {
            // All contexts that share the same service provider will share the same InMemory database
            var serviceProvider = _serviceCollection.BuildServiceProvider();
            var context = CreateAndSeedContext();
            using (var controller = new WeatherController(context))
            {
                var results = controller.Get(DateTime.Now.Date);
                Assert.Equal(2, results.Count());
            }
        }


        private WeatherContext CreateAndSeedContext()
        {
            // All contexts that share the same service provider will share the same InMemory database
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
         // var context = new WeatherContext(serviceProvider, _contextOptions);
              var context = serviceScope.ServiceProvider.GetService<WeatherContext>();
           
            context.WeatherEvents.AddRange(BuildWeatherEvents());
            context.SaveChanges();
            }
            return context;

        }
        private List<WeatherEvent> BuildWeatherEvents()
        {
            var events = new List<WeatherEvent>
            {
                WeatherEvent.Create(DateTime.Now,WeatherType.Sun,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-1),WeatherType.Snow,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-2),WeatherType.Rain,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-3),WeatherType.Sleet,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-4),WeatherType.Hail,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-5),WeatherType.Snow,false),
                WeatherEvent.Create(DateTime.Now,WeatherType.Rain,false)
            };
            return events;
        }
    }
}