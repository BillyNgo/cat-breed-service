# [Cat Breed Service](https://github.com/BillyNgo/CatBreedService)

[![LICENSE](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://raw.githubusercontent.com/dpedwards/dotnet-core-blockchain-advanced/master/LICENSE)
[![.NET Core](https://img.shields.io/badge/.NET-6-blue.svg)](https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
[![Swagger](https://img.shields.io/badge/Swagger-lightgreen.svg)](https://swagger.io/)
[![CosmosDb](https://img.shields.io/badge/Cosmos-Db-orange.svg)](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator)
[![CQRS pattern](https://img.shields.io/badge/CQRS-pattern-blue.svg)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
[![Mediator pattern](https://img.shields.io/badge/Mediator-pattern-blue.svg)](https://en.wikipedia.org/wiki/Mediator_pattern)
[![DDD pattern](https://img.shields.io/badge/DDD-pattern-blue.svg)](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

Sample .NET Core Web API CQRS implementation with Ef Core, Mediator, Cqrs and DDD using Clean Architecture.

Give a Star! ⭐
----------------------------------------------------------------------------------------------------------------------
If you like this project, learn something or you are using it in your applications, please give it a star. Thanks!

Description
----------------------------------------------------------------------------------------------------------------------
Sample .NET Core Web API application implemented with CQRS, Mediator Pattern approach and Domain Driven Design.

![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/mediatr.png)

## Techical Stack:
- .NET 6.0
- ASP.NET Core WebApi 
- Entity Framework Core
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI
- Azure Cosmos Db Emulator
- xUnit
- Moq
- Fluent Assertions
- Logging

## Installation

- Check if [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and [Azure Cosmos Db Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator) is installed on your machine. 
- Next configure the database connection string in `appsettings.Development.json` file before creating a needed database for project. 
- Database and seed data will be created automatically the first time you run the application.

To seed data for the first run:
- Uncomment line number 73 `app.UseDataSeeding();` in Startup.cs under **CatBreedService.Api** project
- For the next run please comment out line number 73 `app.UseDataSeeding();` in Startup.cs under **CatBreedService.Api** project

## How to Test

- Run the following commands, in sequence, inside the application directory:

```
dotnet restore
dotnet build
```
- Run the following commands, in sequence, inside the **CatBreedService.Api** project directory:

```
dotnet run
```
**CatBreedService.Api** project is listening on localhost port `7045` (https) and `5173` (http)

- Navigate to `http://localhost:5000/swagger/index.html` to check the API documentation and test all endpoints.

![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/demo.png)





