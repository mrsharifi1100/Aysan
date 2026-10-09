# Phase 06 — SQL Server Infrastructure

## Goal

Set up SQL Server for the Catalog service and establish the initial EF Core infrastructure, including database connectivity, `DbContext` registration, and design-time configuration for future migrations.

## 1 - Add SQL Server to Docker Compose

Add the SQL Server container to `<span>docker-compose.yml</span>`.

Configure environment variables, port mapping, and persistent storage.

## 2 - Configure Connection String

Add the SQL Server connection string to the application configuration in :

`appsettings.Development.json`

Configure the connection settings for local development and Docker environments.

## 3 - Create DbContext

Create `CatalogContext` in the Infrastructure project.

Place the context inside the `Database` folder.

## 4 - Register Database Services

Configure EF Core and SQL Server in the Infrastructure dependency injection setup.

Register `<span>CatalogContext</span>` for use by the application.

## 5 - Configure Design-Time DbContext

Implement `IDesignTimeDbContextFactory<CatalogContext>`

Prepare EF Core tooling to create the context for migration commands.

## Result

SQL Server is configured through Docker Compose, and the Catalog service has the initial EF Core infrastructure required for database access and future migrations.

## Related Files

[Dependency Injection](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/DependencyInjection.cs)

[CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)

[appsettings.Development.Json](../../src/Services/Catalog/Catalog.Api/appsettings.Development.json)

[docker-compose.yml](../../docker-compose.yml)
