# What is this?
This is an example project that demonstrates Composition Root using Autofac and .net core 3.1.

Medium Article: [Composition Root](https://medium.com/@cfryerdev/dependency-injection-composition-root-418a1bb19130)

# Structure
- Sample.API - This is the api project, this contains configuration and controllers.
- Sample.Composition - This is the composition root project which is responsible for building all dependencies for this stack.
- Sample.Domain - This is the domain project which houses all domain and business logic.

# Depedency Chain
```.
└── Sample.API
    └── SampleController
        └── SampleManager
            └── DBConnection

# Do I need a database?
Yes, I currently have it setup to connect to the database on start, you can disable this by editing the code in `DbConnectionInstaller.cs`, below is the docker command which makes things quite a bit easier.

# Docker Sql Server?
$ `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu`

# Ok, its running, now what?
Visit `http://localhost:5000/api/Sample` to see the dependency chain resolve!