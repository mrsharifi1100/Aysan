## Phase - 18 — Domain Events Infrastructure

### Goal

Implement Domain Events infrastructure in the Catalog service, including domain event tracking in entities, defining domain events, publishing events through MediatR, and handling them in the Application layer.

## 1. Add Domain Event Tracking to the Base Entity

Add the following members to the base `Entity` class:

* A private collection of `INotification` to store domain events.
* A read-only `DomainEvents` property.
* An `AddDomainEvent` method.
* A `RemoveDomainEvent` method.
* A `ClearDomainEvents` method.

## 2. Create the Domain Events Folder

Create a `Events` folder in the Domain layer.

Define `ProductPriceChangedDomainEvent` as a MediatR `INotification` to represent a product price change. Include the properties required by the event handler, such as the catalog item and its old and new prices.

## 3. Raise the Domain Event in the Domain Model

Update the relevant domain operation, such as `CatalogItem.UpdatePrice`, to raise `ProductPriceChangedDomainEvent` when the price changes.

Use `AddDomainEvent` to register the event on the entity. Do not publish the event directly from the entity.

## 4. Update CatalogContext

Add the required domain event dispatching infrastructure to `CatalogContext`.

Ensure that domain events are collected from tracked entities, published through MediatR, and cleared at the appropriate point in the persistence workflow.

## 5. Implement NoMediator for Design-Time DbContext Creation

Create `NoMediator` as a minimal `IMediator` implementation for Entity Framework Core design-time operations.

Use it when constructing `CatalogContext` for design-time purposes, so migrations can be created without requiring the real MediatR pipeline.

Ensure all interface members match the installed MediatR version.

## 6. Update CatalogContextFactory

Update `CatalogContextFactory` to pass `NoMediator` when creating `<span>CatalogContext</span>` for design-time operations.

Keep the real MediatR registration in the application's Dependency Injection configuration.

## 7. Create MediatorExtension

Create a `MediatorExtension` class to publish domain events through MediatR.

The extension should collect domain events from entities, publish them, and clear the dispatched events. Integrate it into the appropriate `CatalogContext` persistence workflow.

## 8. Create the Domain Event Handler

Create a `DomainEventHandler` folder in the Application layer.

Implement `ProductPriceChangedEventHandler` using `INotificationHandler<ProductPriceChangedDomainEvent>`.

For the initial implementation, log the product ID and the old and new prices. Integration Event publishing can be added in a later phase.

## 9. Register and Verify the Infrastructure

Ensure MediatR discovers the domain event handlers and that the required services are registered in Dependency Injection.

Test the workflow by updating a product's price and verifying that:

* The domain event is raised when the price changes.
* The event is published through MediatR.
* The corresponding handler executes.
* The database changes are persisted successfully.

### Important Notes

* Domain Events represent facts that occurred within the domain.
* Domain entities should raise events, not publish them directly.
* `NoMediator` is intended for design-time use, not normal application execution.
* Define and verify the transaction and event-dispatching order to avoid publishing events for changes that ultimately fail to commit.
