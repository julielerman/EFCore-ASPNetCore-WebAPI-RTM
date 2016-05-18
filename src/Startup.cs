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

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
             _platform=new Platform();
            var platString= _platform.ToString();
             
 var _isMono = string.Equals(
                        PlatformServices.Default.Runtime.RuntimeType,
                        "Mono",
                        StringComparison.OrdinalIgnoreCase);
       
        }

        public IConfigurationRoot Configuration { get; set; }

         public void ConfigureServices(IServiceCollection services)
        {
                services.AddMvc();

            //note: see https://github.com/AspNetCore/MusicStore/blob/dev/src/MusicStore/Startup.cs
            //for post RC1 implementation of determining if this is a test
            //with the platform inspection


            services.AddDbContext<WeatherContext>(options =>
              options.UseNpgsql(Configuration["Data:PostgreConnection:ConnectionString"]));
            services.AddScoped<InternalServices>();
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
              .UseIISIntegration()
              .UseStartup<Startup>()
              .Build();

            host.Run();
        }
    }
}
