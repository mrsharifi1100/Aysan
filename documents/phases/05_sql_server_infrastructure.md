# Phase 05 — SQL Server Infrastructure

## Goal

Set up SQL Server for the Catalog service and establish the initial EF Core infrastructure, including database connectivity, `DbContext` registration, and design-time configuration for future migrations.

## Tip

You Need This Packages :

* Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.Design
  Microsoft.EntityFrameworkCore.SqlServer

## 1 - Add SQL Server Image to Docker Compose

Add the SQL Server container to `docker-compose.yml`.

Configure environment variables, port mapping, and persistent storage.

## 2 - Configure Connection String

Add the SQL Server connection string to the application configuration in :

`appsettings.Development.json`

Configure the connection settings for local development and Docker environments.

## 3 - Create and Configure CatalogContext

Before creating the `CatalogContext`, create a `Features` folder in the Infrastructure project, then create a `Database` folder inside it.

Create the `CatalogContext` class inside the `Features/Database` folder and configure it for use with Entity Framework Core.

## 4 - Configure Design-Time DbContext

Implement `IDesignTimeDbContextFactory<CatalogContext>` in `CatalogContext`

Prepare EF Core tooling to create the context for migration commands.

## 5 - Register Database Services

Configure the SQL Server connection and register `CatalogContext` in the Infrastructure dependency injection setup.

Register the required EF Core database services in the `DependencyInjection.cs` file.

## Result

SQL Server is configured through Docker Compose, and the Catalog service has the initial EF Core infrastructure required for database access and future migrations.

## Related Files

[Dependency Injection](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/DependencyInjection.cs)

[CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)

[appsettings.Development.Json](../../src/Services/Catalog/Catalog.Api/appsettings.Development.json)

[docker-compose.yml](../../docker-compose.yml)
