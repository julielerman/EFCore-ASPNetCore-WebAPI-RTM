# EF Core, ASPNETCore on CoreCLR RC2, Uses PostgreSQL and InMemory for tests

Current status (May 28, 2016):   

*Master branch uses RC2 (final) and PostgreSQL 
*Added settings in startup and appsettings.json to work with docker. Docker file in root path will build a reusable dotnet core rc2 image. Docker file in src path is for running the app. Use docker-compose from src to run after modifying the app to use the two mods noted inthe startup and appsettings files.
*Removed the MovingToDocker branch that was old.

I found Shayne Boyer's blog post, "Legion of Heroes: haproxy, nginx, Angular 2, ASP.NET Core, Redis and Docker" (http://tattoocoder.azurewebsites.net/legion-of-heroes-haproxy-nginx-angular2-aspnetcore-redis-docker/) really helpful for figuring out the docker deployment.


