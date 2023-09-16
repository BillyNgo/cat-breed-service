# [Cat Breed Service](https://github.com/BillyNgo/CatBreedService)

[![LICENSE](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://raw.githubusercontent.com/dpedwards/dotnet-core-blockchain-advanced/master/LICENSE)
[![.NET Core](https://img.shields.io/badge/.NET-6-blue.svg)](https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
[![Swagger](https://img.shields.io/badge/Swagger-lightgreen.svg)](https://swagger.io/)
[![CosmosDb](https://img.shields.io/badge/Cosmos-Db-orange.svg)](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator)
[![CQRS pattern](https://img.shields.io/badge/CQRS-pattern-blue.svg)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
[![Mediator pattern](https://img.shields.io/badge/Mediator-pattern-blue.svg)](https://en.wikipedia.org/wiki/Mediator_pattern)
[![DDD pattern](https://img.shields.io/badge/DDD-pattern-blue.svg)](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

Sample .NET Core Web API application implemented with CQRS, Mediator Pattern approach and Domain Driven Design using Clean Architecture.

Give a Star! ⭐
----------------------------------------------------------------------------------------------------------------------
If you like this project, learn something or you are using it in your applications, please give it a star. Thanks!

Description
----------------------------------------------------------------------------------------------------------------------
Everyone loves cats. To meet the high demand for beautiful cat images, we need
to be able to provide pictures of cats at a moment's notice whenever someone
requests them via the internet. The primary goal of this exercise is to structure
and build an API that allows users to upload and receive cute cat images.

Sample .NET Core Web API application implemented with CQRS, Mediator Pattern approach and Domain Driven Design using Clean Architecture.

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Validations
- CQRS (Imediate Consistency)
- Inversion of Control / Dependency injection
- Azure Cosmos Db Emulator
- Mediator
  
![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/project-architecture.png)
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
- Configure the database connection in `appsettings.Development.json` file before creating a needed database for project. 
- Database and seed data will be created automatically the first time you run the application.
![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/azure-cosmosdb-emulator.png)
![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/azure-cosmosdb-emulator-config.png)

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

- Navigate to `http://localhost:7045/swagger/index.html` to check the API documentation and test all endpoints.

![alt text](https://github.com/BillyNgo/CatBreedService/blob/main/demo.png)

---

## Credits

### Creator

**Billy Ngo**

- <https://github.com/billyngo>

### Requirements

- [Visual Studio](https://visualstudio.microsoft.com/de/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET Core](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/de-de/sql-server/sql-server-downloads)

### Packages:

- [Microsoft.NETCore.App](https://dotnet.microsoft.com/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Microsoft.Extensions.DependencyInjection](https://dotnet.microsoft.com/apps/aspnet)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Microsoft.EntityFrameworkCore](https://docs.microsoft.com/de-de/ef/core/)
- [Microsoft.EntityFrameworkCore.Cosmos](https://docs.microsoft.com/de-de/ef/core/)
- [Microsoft.EntityFrameworkCore.Inmemory](https://docs.microsoft.com/de-de/ef/core/)
- [XUnit](https://xunit.net/)
- [Moq](https://www.nuget.org/packages/Moq)
- [AutoFixture](https://github.com/AutoFixture/AutoFixture)


## Acknowledgments

Inspiration, code snippets, etc.

* [DDD Patern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
* [Mediator Pattern](https://en.wikipedia.org/wiki/Mediator_pattern)
* [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

## References

- Microsoft Documentation [Microservice DDD CQRS Patterns](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
- Microsoft Documentaton - [EF Core Azure Cosmos DB Provider](https://docs.microsoft.com/en-us/ef/core/providers/cosmos/)
- YouTube Video - [Access Azure Cosmos DB with Entity Framework Core](https://www.youtube.com/watch?v=oyJSk-TV7_M)
- YouTube Video - [Using Entity Framework Core with Azure SQL DB and Azure Cosmos DB | Azure Friday](https://www.youtube.com/watch?v=FFgS_k_Muk8)

---

## License

MIT License

Copyright (c) 2023 Billy Ngo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.





