# Serilog

Serilog is used as the logging framework for the Aysan services.

## Why Serilog?

Serilog provides structured logging and integrates well with ASP.NET Core.

It allows logs to be written to different outputs (sinks), such as the console and files, while keeping the logging configuration centralized.

## Installation

The required Serilog packages are installed in the shared logging project:

`src/BuildingBlocks/Logging/Common.Logging/`

The logging infrastructure is implemented as a reusable BuildingBlock so that multiple services can use the same logging setup.

## Shared Logging Infrastructure

The shared logging configuration is located in:

`src/BuildingBlocks/Logging/Common.Logging/DependencyInjection.cs`

The project exposes an extension method for registering Serilog with the application's host.

This keeps the Serilog registration out of individual services and allows the same logging infrastructure to be reused by Catalog, Basket, Ordering, and other services.

## Configuration

Serilog settings are configured through the application's configuration system.

For the Catalog API:

`src/Services/Catalog/Catalog.Api/appsettings.json`

Environment-specific configuration can be placed in:

`src/Services/Catalog/Catalog.Api/appsettings.Development.json`

This allows logging behavior to be changed through configuration without changing the logging registration code.

## Configuration Options

The Serilog configuration can define:

* Minimum log level
* Console sink
* File sink
* Log output format
* Logging overrides
* Enrichment

Example categories that may require different log levels:

* `Microsoft`
* `Microsoft.AspNetCore`
* `Microsoft.EntityFrameworkCore`

## Log Context

The shared logging infrastructure enables:

`Enrich.FromLogContext()`

This allows contextual information to be added to log events and can later be used for information such as request or correlation identifiers.

## Usage

Application code uses the standard `Microsoft.Extensions.Logging` abstractions rather than depending directly on Serilog.

This keeps application code independent from the logging implementation.

Example:

```csharp
private readonly ILogger<ProductService> _logger;
```

Serilog acts as the logging provider behind the standard logging abstraction.

## BuildingBlock Structure

```text
src/
├── BuildingBlocks/
│   └── Logging/
│       └── Common.Logging/
│           └── DependencyInjection.cs
│
└── Services/
    └── Catalog/
        └── Catalog.Api/
            ├── Program.cs
            └── appsettings.json
```

The `Common.Logging` project contains shared logging infrastructure, while each service provides its own configuration values.

## Future Improvements

As the system grows, logging can be extended with:

* Correlation IDs
* Request logging
* Structured properties
* OpenTelemetry integration
* Centralized log collection
* Production-specific sinks

These features will be added when they become necessary for the system.

## Related Documentation

* [Logging Phase]()
* [ASP.NET Core]()
