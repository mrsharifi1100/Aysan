# Phase 06 — Domain Building Blocks

## Goal

Introduce the foundational building blocks required for modeling domain entities and aggregate roots in the Catalog service.

## 1 - Create the Entity Base Class

Create a base `Entity` class in the Domain project.

The class provides:

* Entity identity through the `Id` property.
* Transient entity detection through `IsTransient()`.
* Equality comparison based on entity identity.
* Hash code generation.

## 2 - Create the Aggregate Root Interface

Create the `IAggregateRoot` marker interface in the Domain project.

This interface identifies domain entities that serve as aggregate roots.

## Result

The Catalog Domain now has foundational abstractions for defining entities and identifying aggregate roots.

These building blocks can be reused as the domain model grows.

## Related Files

* [Entity.cs](../../src/Services/Catalog/Catalog.Domain/Common/Entity.cs)
* [IAggregateRoot](../../src/Services/Catalog/Catalog.Domain/Common/IAggregateRoot.cs)
