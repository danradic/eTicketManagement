<img src="https://github.com/danradic/eTicketManagement/blob/main/src/Presentation/eTicketManagement.BlazorWasm/wwwroot/img/eTicketlogo2.png" width="300">

This is a real-world ticket sales back office application built with `ASP.NET Core 6 Web API` and `Blazor WebAssembly` as the UI and consumer of the API.
This repository's goal is mainly for learning purposes and to propose a solid solution structure for future projects. 
Using an `Onion Architecture` aka `Clean Architecture` based on [architectural principles](https://github.com/danradic/eTicketManagement/edit/main/README.md#the-architecture-is-based-on-the-following-architectural-principles), the end goal is to have a testable and maintainable application architecture.


### Solution structure

<img src="https://github.com/danradic/eTicketManagement/blob/main/src/Presentation/eTicketManagement.BlazorWasm/wwwroot/img/solution_structure.PNG" width="350">

### Architecture overview

With Onion Architecture aka Clean Architecture, the `Domain` and `Application` layers are at the center of the design. This is known as the `Core` of the system. 

The Domain layer contains enterprise logic and types and the Application layer contains business logic and types.
The Core shouldn’t be dependent on concerns such as `Persistence` (Data Access) and `Infrastructure`, so we invert those dependencies. Therefore, Infrastructure and `Presentation` depend on the Core.

This is achieved by adding interfaces and abstractions within Core, which are implemented by layers outside Core such as Infrastructure.  

All dependencies flow inwards, and Core has no dependencies on any other layers.
Infrastructure and Presentation depend on Core, but not on one another.

#### The architecture is based on the following architectural principles:
- Separation of concerns
- Dependency Inversion
- Single Responsibility
- DRY
- Persistence Ignorance

This results in a design that is: 
- Independent of UI, databases, frameworks
- Clean, maintainable, testable
- The difference between an application that will last 3 years and an application that will last 20 years

### Goal
- Have a solid foundation for future projects

### Technologies
- ASP.NET Core 6 Web API
- Blazor WebAssembly
- Onion Architecture
- CQRS with MediatR
- Fluent Validation
- Automapper
- Feature‑based folder organization
- Entity Framework Core - Code First
- Repository Pattern
- Serilog
- Swagger UI
- NSwag client code generation
- Response wrappers
- Pagination
- In-Memory Database for Integration Tests
- Microsoft Identity with JWT Authentication
- Database Seeding
- Custom Exception Handling Middlewares
- Sendgrid Email Service
- Register / Login & Generate Token

### Resources
- [Architecting ASP.NET Core Applications: Best Practices - Gill Cleeren](https://www.pluralsight.com/courses/architecting-asp-dot-net-core-applications-best-practices)
- [Clean Architecture - Jason Taylor](https://www.youtube.com/watch?v=dK4Yb6-LxAk)
- [ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0)
- [Call a Web API from ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/call-web-api?pivots=webassembly&view=aspnetcore-6.0)
- [Get started with NSwag](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-6.0&tabs=visual-studio)

### Suggestions for Improvement?
[Please raise a bug or feature request](https://github.com/danradic/eTicketManagement/issues/new).

