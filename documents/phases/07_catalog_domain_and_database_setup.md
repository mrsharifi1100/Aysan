# Phase 07 — Catalog Domain and Database Setup

## Goal

Implement the initial Catalog domain model, configure its persistence using EF Core, and create the corresponding database schema through migrations.

## 1 - Create Catalog Domain Entities

In the Domain project, create an `AggregateModel` folder to organize domain aggregates.

Create the following folders inside `AggregateModel`:

* `CatalogItemAggregate`
* `CatalogTypeAggregate`

Create the `CatalogItem` entity inside `CatalogItemAggregate` and the `CatalogType` entity inside `CatalogTypeAggregate`.

Both entities should inherit from the `Entity` base class and implement the `IAggregateRoot` interface.

Define their properties, constructors, and initial domain validation rules.

## 2- Add Domain Exceptions

Create `CatalogDomainException` for domain rule violations shared by the Catalog domain entities.

## 3- Add Entities Configurations

Create entity configuration classes for `CatalogItem` and `CatalogType`.

Configurations folder located in :

`src/Services/Catalog/Catalog.Infrastructure/Features/Database/Configurations/`

Configure:

* Primary keys
* Property constraints
* Decimal precision for prices
* The relationship between `CatalogItem` and `CatalogType`

## 4 - Apply Configurations

Register the entity configurations with `CatalogContext` so EF Core can build the database model.

## 5 - Create Migration

Generate the initial EF Core migration for the Catalog entities.

> you must rund the migration at folder `src/Services/Catalog/`

Review the generated migration to verify the expected tables, columns, constraints, and foreign key relationship.

## 6 - Apply Migration

Apply the migration to SQL Server and verify that the database schema has been created successfully.

## Result

The Catalog domain model is implemented, its EF Core mappings are configured, and the initial database schema is created through migrations.

## Related Files

* [CatalogItem.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogItemAggregate/CatalogItem.cs)
* [CatalogType.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogTypeAggregate/CatalogType.cs)
* [CatalogItemConfiguration.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Configurations/CatalogItemConfiguration.cs)
* [CatalogTypeConfiguration.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Configurations/CatalogTypeConfiguration.cs)
* [CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)
