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
        private ServiceCollection _services;
        private readonly ITestOutputHelper _output; //xunit for writeline
        WeatherContext context;


        public FancierControllerTests(ITestOutputHelper output)
        {
            _output = output;
            _services = new ServiceCollection();
            _services.AddDbContext<WeatherContext>(options => options.UseInMemoryDatabase());


        }
        [Fact]
        public void CanGetWeatherEvents()
        {
            var context = CreateAndSeedContext();
            using (var controller = new WeatherController(context, null))
            {
                var results = controller.Get();
                Assert.Equal(8, results.Count());
            }
        }

        [Fact]
        public void CanGetWeatherEventsFilteredByDate()
        {
            var context = CreateAndSeedContext();
            using (var controller = new WeatherController(context, null))
            {
                var results = controller.Get(DateTime.Now.Date);
                Assert.Equal(2, results.Count());
            }
        }


        private WeatherContext CreateAndSeedContext()
        {
            // All contexts that share the same service provider will share the same InMemory database
            var serviceProvider = _services.BuildServiceProvider();
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            context = serviceScope.ServiceProvider.GetService<WeatherContext>();

            context.WeatherEvents.AddRange(BuildWeatherEvents());
            context.SaveChanges();

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