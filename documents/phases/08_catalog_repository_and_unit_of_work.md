# Phase 08 — Catalog Repository and Unit of Work

## Goal

Implement the Repository and Unit of Work patterns for the Catalog aggregates, define their contracts, configure their implementations in the Infrastructure layer, and register them with Dependency Injection.

## 1 - Define Unit of Work Abstractions

Create the shared abstractions:

* `IUnitOfWork`
* `IRepository<T>`

Define `SaveEntitiesAsync` in `IUnitOfWork` and expose `IUnitOfWork` through `<span>IRepository<T></span>` where required.

## 2 - Implement Unit of Work in CatalogContext

Implement `IUnitOfWork` in `CatalogContext`.

Implement `SaveEntitiesAsync` using EF Core's `SaveChangesAsync` to persist pending changes.

## 3 - Define Catalog Repository Contracts

Create the repository interfaces for their respective aggregate roots:

* `ICatalogItemRepository`
* `ICatalogTypeRepository`

Define the data access operations required by the Catalog domain and application use cases.

## 4 - Implement Catalog Repositories

Create the repository implementations in:

`<span>Infrastructure/Features/Database/Repositories</span>`

Implement:

* `CatalogItemRepository`
* `CatalogTypeRepository`

Use `CatalogContext` to access and persist aggregate data, and provide access to `IUnitOfWork` through `IRepository<T>` where required.

## 5 - Register Repository Dependencies

Register the repository implementations in Dependency Injection.

Ensure that application services can depend on the repository interfaces without referencing their Infrastructure implementations.

## 6 - Verify Repository and Unit of Work Behavior

Verify that:

* Repository implementations can access the corresponding Catalog entities.
* Changes can be persisted through `<span>IUnitOfWork</span>`.
* Repository interfaces resolve correctly through Dependency Injection.
* EF Core persistence works with the existing Catalog database schema.

## Result

The Catalog repository contracts and implementations are established, Unit of Work is integrated with `<span>CatalogContext</span>`, and repository dependencies are configured for use by the application layer.

## Related Files

* [CatalogItem.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogItemAggregate/CatalogItem.cs)
* [CatalogType.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogTypeAggregate/CatalogType.cs)
* [IUnitOfWork.cs](../../src/Services/Catalog/Catalog.Domain/Common/IUnitOfWork.cs)
* [IRepository.cs](../../src/Services/Catalog/Catalog.Domain/Common/IRepository.cs)
* [ICatalogItemRepository.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogItemAggregate/ICatalogItemRepository.cs)
* [ICatalogTypeRepository.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogTypeAggregate/ICatalogTypeRepository.cs)
* [CatalogItemRepository.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Repositories/CatalogItemRepository.cs)
* [CatalogTypeRepository.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Repositories/CatalogTypeRepository.cs)
* [DependencyInjection.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/DependencyInjection.cs)
