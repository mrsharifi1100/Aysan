# Phase 07 — Catalog Domain and Database Setup

## Goal

Implement the initial Catalog domain model, configure its persistence using EF Core, and create the corresponding database schema through migrations.

## 1 - Create Catalog Domain Entities

Create the initial domain entities:

* `CatalogItem`
* `CatalogType`

Define their properties, constructors, and initial domain validation rules.

## 2 - Define Aggregate Roots

Identify the aggregate roots in the Catalog domain and implement `IAggregateRoot` where appropriate.

## 3 - Add Domain Exceptions

Create `CatalogDomainException` for domain rule violations shared by the Catalog domain entities.

## 4 - Configure EF Core Entity Mapping

Create entity configuration classes for `CatalogItem` and `CatalogType`.

Configure:

* Primary keys
* Property constraints
* Decimal precision for prices
* The relationship between `CatalogItem` and `CatalogType`

## 5 - Apply Entity Configurations

Register the entity configurations with `CatalogContext` so EF Core can build the database model.

## 6 - Create Initial Migration

Generate the initial EF Core migration for the Catalog entities.

Review the generated migration to verify the expected tables, columns, constraints, and foreign key relationship.

## 7 - Apply Migration

Apply the migration to SQL Server and verify that the database schema has been created successfully.

## Result

The Catalog domain model is implemented, its EF Core mappings are configured, and the initial database schema is created through migrations.

## Related Files

* [CatalogItem.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogItemAggregate/CatalogItem.cs)
* [CatalogType.cs](../../src/Services/Catalog/Catalog.Domain/AggregateModel/CatalogTypeAggregate/CatalogItem.cs)
* [CatalogItemConfiguration.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Congfigurations/CatalogItemConfiguration.cs)
* [CatalogTypeConfiguration.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Congfigurations/CatalogItemConfiguration.cs)
* [CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)
