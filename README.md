# .NET Clean Architecture Solution

A Clean Architecture solution template for .NET applications.

## What's included in the template?

```
- SharedKernel project with common Domain-Driven Design abstractions.
- Domain layer with sample entities.
- Application layer with abstractions for:
  - CQRS
  - Example use cases
  - Cross-cutting concerns (logging, validation)
- Infrastructure layer with:
  - Authentication
  - Permission authorization
  - EF Core, PostgreSQL
  - Serilog
- Seq for searching and analyzing structured logs
  - Seq is available at http://localhost:8081 by default
- Testing projects
  - Architecture testing
```

## Prerequisites

- .NET 9.0 SDK or later
- Docker (optional, for containerized development)
- Visual Studio 2022 / VS Code / JetBrains Rider

## Getting Started

### Build and Run

1. Clone the repository
2. Build the solution:

```bash
dotnet build
```

3. Run the application:

```bash
dotnet run --project src/Web.Api
```

### Docker Support

To run the application using Docker:

```bash
docker-compose up -d
```

## Development

This solution follows Clean Architecture principles with a clear separation of concerns:

- **Domain Layer**: Contains enterprise business rules and entities
- **Application Layer**: Contains business rules and use cases

## Configuration

The solution uses the following configuration files:

- `Directory.Build.props`: Common build properties
- `Directory.Packages.props`: Centralized package management
- `docker-compose.yml`: Docker composition setup
