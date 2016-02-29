# ef7osxtest

Current status:   

Master branch uses RC1 and PostgreSQL RC2 branch uses pre-RC2 with EFCore, ASPCore, CLI and SQLite via nighty builds
MovingToDocker branch is setup to push the webapi into a docker container, create a 2nd container for postgresql via docker-compose. This is currently using RC1.

 
This is just testing. Nothing too exciting. It is using EF7 RC1, ASP.NET 5 RC1 and the postgresql provider.

Right after I got this sorted, we got the big name (and namespace) changes to Aspnet Core and EF Core. 

RC2 (not yet released) is using these namespaces but also now things are shifting from dnx to corecli and it's getting trickier. At the moment, the postgresql provider isn't aligned with those bits. 

I found Shayne Boyer's blog post, "Legion of Heroes: haproxy, nginx, Angular 2, ASP.NET Core, Redis and Docker" (http://tattoocoder.azurewebsites.net/legion-of-heroes-haproxy-nginx-angular2-aspnetcore-redis-docker/) really helpful for figuring out the docker deployment.

I also played "one of these things is not like the other" with the cli-samples (https://github.com/aspnet/cli-samples) to help me move the RC1 version of this to the RC2/cli version in "RC2" repository.
