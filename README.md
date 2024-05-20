# ManpowerManagement

## Description
Sample .NET Core REST API application implemented with basic [CQRS](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/cqrs) approach.

Use Asp.net Core WebApp for UI.

## Architecture [Clean Architecture](http://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
<img src = "https://github.com/Amirejazi/ManpowerManagement/blob/master/docs/clean_architecture.jpg" width = 450px>

## CQRS
Read & Write Model - SqlServer (using Entity Framework Core).

Commands/Queries handling using [MediatR](https://github.com/jbogard/MediatR) library.

## Validation
Data validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
