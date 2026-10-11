# Phase 13 — Catalog CQRS and Command Handlers

## Goal

Introduce CQRS using MediatR in the Application layer and implement the initial Catalog command use cases for creating and updating Catalog items and types.

## 1 - Configure MediatR

Add the MediatR dependency to the Application project.

Register MediatR in the Application dependency injection configuration using `<span>AddMediatR</span>` and scan the Application assembly to discover and register request handlers.

## 2 - Establish the Feature Structure

Create the `<span>Features</span>` directory in the Application project.

Organize Catalog use cases under `<span>Features/Catalog</span>`, keeping each use case and its related components grouped by feature.

## 3 - Implement Create Catalog Item

Create the following components:

* `<span>CreateCatalogItemCommand</span>`
* `<span>CreateCatalogItemCommandHandler</span>`

Implement the command handler to create a `<span>CatalogItem</span>`, add it through `<span>ICatalogItemRepository</span>`, persist changes using Unit of Work, and return the generated identifier.

## 4 - Implement Create Catalog Type

Create the following components:

* `<span>CreateCatalogTypeCommand</span>`
* `<span>CreateCatalogTypeCommandHandler</span>`

Implement the command handler to create a `<span>CatalogType</span>` and persist it through its repository and Unit of Work.

## 5 - Implement Update Catalog Item

Create the following components:

* `<span>UpdateCatalogItemCommand</span>`
* `<span>UpdateCatalogItemCommandHandler</span>`

Implement the command handler to retrieve the existing Catalog item, apply the requested updates through the domain model, and persist the changes.

## 6 - Implement Update Catalog Type

Create the following components:

* `<span>UpdateCatalogTypeCommand</span>`
* `<span>UpdateCatalogTypeCommandHandler</span>`

Implement the command handler to retrieve the existing Catalog type, apply the requested updates, and persist the changes.

## 7 - Verify Command Execution

Verify that all four commands can be dispatched through MediatR and that their handlers execute the corresponding operations using the repository and Unit of Work abstractions.

## Result

MediatR is configured in the Application layer, the Catalog feature structure is established, and the initial Create and Update command handlers are implemented.

## Related Files

* [DependencyInjection.cs](../../src/Services/Catalog/Catalog.Application/DependencyInjection.cs)
* [Catalog Features](../../src/Services/Catalog/Catalog.Application/Features/)
