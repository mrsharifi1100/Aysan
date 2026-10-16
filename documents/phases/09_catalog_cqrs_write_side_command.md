# Phase 09 — Cqrs Write Side — Command

## Goal

Introduce CQRS using MediatR in the Application layer and implement the initial Catalog command use cases for creating and updating Catalog items and types.

## 1 - Configure MediatR

Add the MediatR dependency to the Application project.

Register MediatR in the Application dependency injection configuration using `AddMediatR` and scan the Application assembly to discover and register request handlers.

## 2 - Establish the Feature Structure

Create the `Features` directory in the Application project.

Organize Catalog use cases under `Features/Catalog`, keeping each use case and its related components grouped by feature.

## 3 - Implement CreateCatalog Item

Create the following components:

* `CreateCatalogItemCommand`
* `CreateCatalogItemCommandHandler`

Implement the command handler to create a `CatalogItem`, add it through `ICatalogItemRepository`, persist changes using Unit of Work, and return the generated identifier.

## 4 - Implement CreateCatalogType

Create the following components:

* `CreateCatalogTypeCommand`
* `CreateCatalogTypeCommandHandler`

Implement the command handler to create a `CatalogType` and persist it through its repository and Unit of Work.

## 5 - Implement Update Catalog Item

Create the following components:

* `UpdateCatalogItemCommand`
* `UpdateCatalogItemCommandHandler`

Implement the command handler to retrieve the existing Catalog item, apply the requested updates through the domain model, and persist the changes.

## 6 - Implement Update Catalog Type

Create the following components:

* `UpdateCatalogTypeCommand`
* `UpdateCatalogTypeCommandHandler`

Implement the command handler to retrieve the existing Catalog type, apply the requested updates, and persist the changes.

## Result

MediatR is configured in the Application layer, the Catalog feature structure is established, and the initial Create and Update command handlers are implemented.

## Related Files

* [DependencyInjection.cs](../../src/Services/Catalog/Catalog.Application/DependencyInjection.cs)
* [Catalog Features/](../../src/Services/Catalog/Catalog.Application/Features/)
