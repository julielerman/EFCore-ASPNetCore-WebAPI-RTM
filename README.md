# ef7osxtest

Current status: Master branch uses RC1 and PostgreSQL 
                RC2 branch uses pre-RC2 with EFCore, ASPCore, CLI and SQLite 
                
This is just testing. Nothing too exciting. It is using EF7 RC1, ASP.NET 5 RC1 and the postgresql provider.

Right after I got this sorted, we got the big name (and namespace) changes to Aspnet Core and EF Core. 

RC2 (not yet released) is using these namespaces but also now things are shifting from dnx to corecli and it's getting trickier. At the moment, the postgresql provider isn't aligned with those bits. I'll push up waht I'm working on iwth that version soon.
