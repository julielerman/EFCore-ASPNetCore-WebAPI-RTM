# EF Core, ASPNETCore on CoreCLR RTM, Uses PostgreSQL and InMemory for tests

**Current status (June 29, 2016):**

*Master branch uses RTM that was released on June 27.
*Temporarily switched to SQLIte while waiting for updated PostgreSQL packages.
*Added settings in startup and appsettings.json to work with docker. Docker file in root path will build a reusable dotnet core rc2 image. Docker file in src path is for running the app. Use docker-compose from src to run after modifying the app to use the two mods noted inthe startup and appsettings files.
*Removed the MovingToDocker branch that was old.

I wrote a detailed blog post about the steps (and some problems) I took to update my MacBook to use the new RC2 bits and to update this solution to use all of the new RC2 APIs.  

   **Updating to RC2: Changes to EFCore, ASPNETCore, PostgreSQL driver & XUnit**  
   http://thedatafarm.com/data-access/updating-to-rc2-changes-to-efcore-aspnetcore-postgresql-driver-xunit/

I found Shayne Boyer's blog post, "Legion of Heroes: haproxy, nginx, Angular 2, ASP.NET Core, Redis and Docker" (http://tattoocoder.azurewebsites.net/legion-of-heroes-haproxy-nginx-angular2-aspnetcore-redis-docker/) really helpful for figuring out the docker deployment.


