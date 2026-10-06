# Swagger / OpenAPI

Swagger is used to provide interactive API documentation for the Aysan services.

## Why?

Swagger provides an interactive interface for exploring and testing HTTP APIs.

It allows developers to:

* View available API endpoints
* Inspect request and response models
* Send requests directly from the browser
* Understand API contracts
* Test APIs during development

## Installation

Swagger/OpenAPI support is added to the ASP.NET Core API project.

The required packages and configuration are defined in the Catalog API project

## Configuration

Swagger is configured during application startup.

The configuration includes:

* OpenAPI document generation
* API metadata
* Swagger UI
* Development environment configuration

### Application Startup

The application startup and launch configuration are defined in:The implementation is located in:

`src/services/catalog/catalog.api/propeties/launchsetting`

### Application Settings

Environment-specific application settings are defined in:

`src/services/catalog/catalog.api/appsetting.development.json`

### Middleware Pipeline

Swagger middleware and the HTTP request pipeline are configured in:

`src/services/catalog/catalog.api/program.cs`

### Service Registration

`src/services/catalog/catalog.api/dependencyinjection.cs`

## Swagger UI

Swagger UI provides a browser-based interface for interacting with the API.

The Swagger UI is available at:

`/swagger`

For local development:

`https://localhost:5002/swagger`

## API Documentation

As new endpoints are added to the services, they become part of the generated OpenAPI documentation.

For example:

```text
Catalog API 
├── Products 
│   ├── GET 
│   ├── POST 
│   ├── PUT 
│   └── DELETE
```

## API Versioning

If API versioning is introduced, the Swagger/OpenAPI configuration will be updated to expose the available API versions.

Production exposure of Swagger UI should be considered separately based on the deployment environment and security requirements.

## Authentication

Authentication and authorization support will be added to the Swagger configuration when authentication is introduced.

For example, JWT Bearer authentication can later be configured so authenticated endpoints can be tested through Swagger UI.

## Related Files

* [Program.cs](../../../src/Services/Catalog/Catalog.Api/Program.cs)
* [Dependency Injection](../../../src/Services/Catalog/Catalog.Api/DependencyInjection.cs)
* [appsettings.Development.Json](../../../src/Services/Catalog/Catalog.Api/appsettings.Development.json)
* [launchSettings.json](../../../src/Services/Catalog/Catalog.Api/Properties/launchSettings.json)
