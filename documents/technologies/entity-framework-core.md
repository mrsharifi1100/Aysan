# Entity Framework Core (EF Core)

Entity Framework Core is an Object-Relational Mapper (ORM) used to interact with relational databases through .NET objects and database contexts.

In Aysan, EF Core is used as the database access technology for the Catalog service.

## Why EF Core?

EF Core provides:

* Database access through .NET objects.
* Entity mapping using conventions and Fluent API.
* Database schema management through migrations.
* Integration with ASP.NET Core dependency injection.

## Installation

The Catalog service uses EF Core with the SQL Server provider.

Required packages depend on the project responsibilities:

* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Microsoft.EntityFrameworkCore.Design`
* `Microsoft.EntityFrameworkCore.Tools` (if required by the chosen tooling workflow)

## Project Structure

EF Core infrastructure is located in the Catalog Infrastructure project.

```text
Catalog.Infrastructure/
      |___Features
      |    |___ Database/
      |    |___ Context/
      |    |    |___ CatalogContext.cs
      |    |___ Migrations/
  
```

The Infrastructure project owns the database access implementation and EF Core configuration.

## DbContext

`CatalogContext` is the EF Core database context.

It provides the entry point for database operations and will contain the entity sets and configurations required by the Catalog service.

Implementation:

`src/Services/Catalog/Catalog.Infrastructure/Database/CatalogContext.cs`

## Dependency Injection

The database context and SQL Server provider are registered through the Infrastructure dependency injection configuration.

This allows the application to obtain `CatalogContext` through dependency injection instead of creating it manually during normal application execution.

Implementation:

`src/Services/Catalog/Catalog.Infrastructure/DependencyInjection.cs`

## Design-Time DbContext Factory

`IDesignTimeDbContextFactory<CatalogContext>` is used by EF Core design-time tools to create the database context when executing commands such as migrations.

The factory is useful when the tooling cannot easily create the context through the application's normal startup process or when explicit design-time configuration is required.

Implementation:

`src/Services/Catalog/Catalog.Infrastructure/Database/CatalogContextFactory.cs`

The factory is intended for design-time operations; normal application requests use the context registered through dependency injection.

## Entity Configuration

Entity mapping will be added as Catalog domain entities are introduced.

EF Core Fluent API configurations can be kept in separate configuration classes implementing `IEntityTypeConfiguration<TEntity>`.

Example future structure:

```text
Database/
|___ Features
|        |___ Configurations/
|                |__ CatalogItemConfiguration.cs
|                |__ CatalogTypeConfiguration.cs
```

No entity configurations have been added yet.

## Migrations

EF Core migrations will be used to track and apply database schema changes.

The initial migration will be created after the first persistent domain entities and their configurations are ready.

Migration commands and the final migration location will be documented when this workflow is implemented.

## Related Documentation

* `documents/technologies/sql-server.md`
* `documents/phases/06-sql-server-infrastructure.md`
