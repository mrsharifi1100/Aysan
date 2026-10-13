# Phase 14 — Transaction Management Pipeline

## Goal

Centralize database transaction management using Entity Framework Core and MediatR pipeline behaviors. Ensure that database changes are saved and committed consistently without requiring each command handler to manage transactions manually.

## 1. Implement Transaction Management in CatalogContext

Extend `CatalogContext` in `Catalog.Infrastructure` with transaction management methods.

* Add a field to track the current `IDbContextTransaction`.
* Add `HasActiveTransaction` to determine whether a transaction is already active.
* Add `GetCurrentTransaction()` to retrieve the current transaction.
* Implement `BeginTransactionAsync()` to begin a transaction using `IsolationLevel.ReadCommitted`.
* Implement `CommitTransactionAsync()` to save pending changes, commit the transaction, and dispose of transaction resources.
* Implement `RollbackTransaction()` to roll back the active transaction and release its resources.
* Ensure that transaction methods handle failures safely and preserve the original exception.

## 2. Implement TransactionBehaviour

Create `TransactionBehaviour<TRequest, TResponse>` in `Catalog.Application.Behaviors`.

* Implement `<span>IPipelineBehavior<TRequest, TResponse></span>`.
* Inject `CatalogContext`, `ILogger`, and `ICatalogIntegrationEventService` where required.
* Check whether a transaction is already active before starting a new one.
* Use EF Core's execution strategy to support configured database retry policies.
* Begin a transaction before executing the request handler.
* Execute the handler and commit the transaction after successful execution.
* Roll back the transaction when execution fails.
* Log transaction start, commit, and failure events.

## 3. Restrict Transactions to Commands

Apply transaction management only to requests that modify database state and require transactional consistency.

* Introduce a command or transactional request marker interface if needed.
* Avoid opening unnecessary transactions for read-only queries.
* Ensure that transaction behavior is consistent with the application's MediatR pipeline configuration.

## 4. Register TransactionBehaviour

Register the behavior in the MediatR dependency injection configuration.

* Register `TransactionBehaviour<,>` as an open generic pipeline behavior.
* Ensure that `CatalogContext` and `ICatalogIntegrationEventService` are registered in dependency injection.
* Configure the pipeline so validation executes before the transaction begins.

## 5. Centralize Database Persistence

Use `CommitTransactionAsync()` to call `SaveChangesAsync()` before committing the active transaction.

* Remove redundant calls to `SaveChangesAsync()` from handlers that rely on the centralized transaction pipeline.
* Keep handlers focused on executing application use cases.
* Retain explicit persistence logic only when a use case genuinely requires special transaction or save behavior.

## 6. Handle Integration Events

Integrate transaction completion with `ICatalogIntegrationEventService`.

* Publish integration events only after the database transaction has committed.
* Do not publish events when the database transaction fails.
* Consider the Outbox pattern to improve reliability when database commits succeed but event publication fails.
* Ensure transaction retries do not result in duplicate or inconsistent side effects.

## 7. Validate the Implementation

Test transaction behavior through the Catalog application.

* Verify that successful commands save changes and commit the transaction.
* Verify that failed commands do not commit their changes.
* Verify that active transactions are not unnecessarily nested.
* Verify that read-only queries do not open unnecessary transactions.
* Verify that database execution strategies work correctly with explicit transactions.
* Verify that integration events are not published before a successful commit.

## Out of Scope

* Distributed transactions across multiple services.
* Full Outbox implementation, which can be introduced in a dedicated phase.
* Domain event dispatching unrelated to database transaction completion.

## Result

Database transaction management is centralized in `CatalogContext` and `TransactionBehaviour`. Command handlers no longer need to manage ordinary transaction lifecycles or call `SaveChangesAsync()` explicitly when persistence is handled by the pipeline. Database changes are committed consistently, and integration event publication occurs after successful transaction completion.

## Related files

* [CatalogContext](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/Context/CatalogContext.cs)
* [TransActionBehavior](../../src/Services/Catalog/Catalog.Infrastructure/Behavior/TransactionBehaviour.cs)
* [DependencyInjection.cs](../../src/Services/Catalog/Catalog.Infrastructure/Features/Database/DependencyInjection.cs)
