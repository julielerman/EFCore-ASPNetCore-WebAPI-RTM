using EFCoreWebAPI.Data;
using EFCoreWebAPI.Internal;
using EFLogging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;





namespace EFCoreWebAPI
{
    public class Startup
    {
        private readonly Platform _platform;

        public Startup(IHostingEnvironment env)
        {
          var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WeatherContext>(options =>
              options.UseNpgsql(Configuration["Data:PostgreConnection:ConnectionString"]));
            services.AddScoped<WeatherDataRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new MyLoggerProvider2());

            app.UseStaticFiles();

            app.UseMvc();
            //Creates the database & populates the sample data
            SampleData.InitializeWeatherEventDatabaseAsync(app.ApplicationServices).Wait();
        }

        // Entry point for the application.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
               // .UseUrls("http://0.0.0.0:5002") //<-for docker
              .UseIISIntegration()
              .UseStartup<Startup>()
               .Build();

            host.Run();
        }
    }
}
