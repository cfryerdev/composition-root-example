# What is this?
This is an example project that demonstrates Composition Root using Autofac and .net core 2.0.

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