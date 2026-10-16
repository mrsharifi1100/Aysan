# Phase 14 — Transaction Management with Pipeline

## Goal

Centralize database transaction management using Entity Framework Core and MediatR pipeline behaviors. Ensure that database changes are saved and committed consistently without requiring each command handler to manage transactions manually.

## Tip

Remember this package :

* System.Data

for :

`_currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);`

## 1 - Implement Transaction Management in CatalogContext

Extend `CatalogContext` in `Catalog.Infrastructure` with transaction management methods.

* Add a field to track the current `IDbContextTransaction`.
* Add `HasActiveTransaction` to determine whether a transaction is already active.
* Add `GetCurrentTransaction()` to retrieve the current transaction.
* Implement `BeginTransactionAsync()` to begin a transaction using `IsolationLevel.ReadCommitted`.
* Implement `CommitTransactionAsync()` to save pending changes, commit the transaction, and dispose of transaction resources.
* Implement `RollbackTransaction()` to roll back the active transaction and release its resources.
* Ensure that transaction methods handle failures safely and preserve the original exception.

## 2 - Implement TransactionBehaviour

Create `TransactionBehaviour<TRequest, TResponse>` in `Catalog.Infrastructure/Behaviors`.

* Implement `IPipelineBehavior<TRequest, TResponse>` to manage transactions around command execution.
* Use `CatalogContext` to begin, commit, and roll back transactions.
* Integrate EF Core's execution strategy to support configured retry policies.
* Ensure requests execute within the appropriate transaction scope.

## 3 - Register TransactionBehaviour

Register the behavior in the MediatR dependency injection configuration.

* Register `TransactionBehaviour<,>` as an open generic pipeline behavior.
* Ensure that `CatalogContext` and `ICatalogIntegrationEventService` are registered in dependency injection.
* Configure the pipeline so validation executes before the transaction begins.


## Result

Database transaction management is centralized in `CatalogContext` and `TransactionBehaviour`. Command handlers no longer need to manage ordinary transaction lifecycles or call `SaveChangesAsync()` explicitly when persistence is handled by the pipeline. Database changes are committed consistently, and integration event publication occurs after successful transaction completion.

## Related files

* [CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)
* [TransActionBehavior](../../src/Services/Catalog/Catalog.Infrastructure/Behavior/TransactionBehaviour.cs)
* [DependencyInjection.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/DependencyInjection.cs)
