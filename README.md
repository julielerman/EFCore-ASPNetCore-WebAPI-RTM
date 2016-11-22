# EF Core, ASPNETCore on CoreCLR RTM, Uses PostgreSQL and InMemory for tests

**Current status (Nov 22, 2016):**

*Updated to .NET Core 1.1  
*Updated xunit version in tests project.json  
*Modified WeatherEvent to leverage IEnumerable mapping and encapsulate reactions  
*Modified repository to show that Find and Load were added to 1.1 (even though the single Include + FirstOrDefalt statement is more efficient!)  
*Updated seed method to read json, update dates with current dates, then read the json into weatherevent types  
  
**August 2 and earlier changes**   
*Replaced seed data class with a simpler method that uses JSON seed data. See http://thedatafarm.com/uncategorized/seeding-ef-with-json-data/ for details.
*Master branch uses RTM that was released on June 27.  
*The Npgsql driver is available for RTM so I've switched back to postgres. But left sqlite code in there so you can see it.  
*Added settings in startup and appsettings.json to work with docker. Docker file in root path will build a reusable dotnet core rc2 image. Docker file in src path is for running the app. Use docker-compose from src to run after modifying the app to use the two mods noted inthe startup and appsettings files.
*Removed the MovingToDocker branch that was old.

I wrote a detailed blog post about the steps (and some problems) I took to update my MacBook to use the new RC2 bits and to update this solution to use all of the new RC2 APIs.  

   **Updating to RC2: Changes to EFCore, ASPNETCore, PostgreSQL driver & XUnit**  
   http://thedatafarm.com/data-access/updating-to-rc2-changes-to-efcore-aspnetcore-postgresql-driver-xunit/

I found Shayne Boyer's blog post, "Legion of Heroes: haproxy, nginx, Angular 2, ASP.NET Core, Redis and Docker" (http://tattoocoder.azurewebsites.net/legion-of-heroes-haproxy-nginx-angular2-aspnetcore-redis-docker/) really helpful for figuring out the docker deployment.


