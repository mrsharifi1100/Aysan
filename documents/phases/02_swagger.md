# Phase 2 Swagger

## Goal

Add Swagger/OpenAPI documentation to the Catalog API to make the API endpoints easier to explore and test during development.

## 1 - Add Application Startup Configuration

Configure the application launch settings to start the Catalog API with the required development URL.

Configuration file:

`properties/launchSettings.json`

## 2 - Add Path Base

Add the `PATH_BASE` configuration setting to the development application settings.

Configuration file:

`appsettings.Development.json`

## 3 - Config Middleware Pipeline

Configure the Swagger middleware and request pipeline in:

`Program.cs`

## 4 - Add Registration Service

Register the required Swagger services through:

`DependencyInjection.cs`

## 5 - Run the Application

Run the Catalog API and open the Swagger UI.

```
https://localhost:5002/swagger
```

## Result

The Catalog API now provides an interactive Swagger UI for API exploration and testing.

Detailed Swagger documentation is available in:

`documents/technologies/aspnet-core/swagger.md`

## Related Files

* [Program.cs](../../src/Services/Catalog/Catalog.Api/Program.cs)
* [Dependency Injection](../../src/Services/Catalog/Catalog.Api/DependencyInjection.cs)
* [appsettings.Development.Json](../../src/Services/Catalog/Catalog.Api/appsettings.Development.json)
* [launchSettings.json](../../src/Services/Catalog/Catalog.Api/Properties/launchSettings.json)
