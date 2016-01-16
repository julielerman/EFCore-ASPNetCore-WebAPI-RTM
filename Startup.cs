using EF7WebApi.Models;
using EF7WebAPI.Data;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;





namespace EF7WebAPI
{
    public class Startup
    {
         private readonly Platform _platform;

        public Startup(IHostingEnvironment env, IRuntimeEnvironment runtimeEnvironment)
        {
           
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
          // _platform=new Platform();
           
           
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            
            //note: see https://github.com/aspnet/MusicStore/blob/dev/src/MusicStore/Startup.cs
            //for post RC1 implementation of determining if this is a test
            //with the platform inspection
           services.AddEntityFramework()
               .AddSqlite()
                .AddDbContext<WeatherContext>(options =>
                    options.UseSqlite(Configuration["Data:SQLiteConnection:ConnectionString"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
             //Populates the MusicStore sample data
            SampleData.InitializeWeatherEventDatabaseAsync(app.ApplicationServices).Wait();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
