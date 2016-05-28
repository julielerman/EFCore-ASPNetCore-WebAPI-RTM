#Note, Dockerfile.aspnetcorebase will create core base from aspnetcore and run dnu restore
#that is not part of docker-compose since it only needs to be built once
FROM corerc2

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

EXPOSE 5002/tcp
#ENTRYPOINT ["dnx", "-p", "project.json", "web"]
ENTRYPOINT ["dotnet", "run"]