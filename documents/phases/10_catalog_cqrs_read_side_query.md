# Phase 10 — Catalog Read Infrastructure

## Goal

Set up the Catalog read infrastructure using Dapper and integrate it with the Application layer for CQRS query operations.

## 1 - Define Read Repository Interfaces

Create `ICatalogItemReadRepository`and`ICatalogTypeReadRepository` in the Catalog Application layer.

These interfaces define the contracts for reading catalog items and catalog types.

## 2 - Implement Read Repositories

Implement both interfaces using Dapper in the Infrastructure layer.

Keep the SQL queries and database access logic inside the Infrastructure project.

## 3 - Configure Database Connection

Add the connection string configuration to the database options.

Configure the connection settings required by the Dapper read repositories.

## 4 - Register Services

Register the Dapper read repository implementations in the Infrastructure dependency injection configuration.

## 5 - Integrate with CQRS

Use the read repository interfaces in the Application layer to implement Catalog query handlers.

Define the required ViewModels for query responses and use the repositories to retrieve the data.

## Result

The Catalog service has a Dapper-based read infrastructure integrated with CQRS. The Application layer depends on read repository interfaces, while Infrastructure provides their implementations.

## Related Files

* [Catalog Features](../../src/Services/Catalog/Catalog.Application/Features/)
* [Dapper](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Dapper/Catalog/)
