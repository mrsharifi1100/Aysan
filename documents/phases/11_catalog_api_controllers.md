# Phase 11— Catalog API Controllers

## Goal

Expose Catalog item and catalog type operations through separate versioned API controllers.

## 1. Create Catalog Item Controller

Add `CatalogItemController` to handle HTTP requests related to catalog items.

Use MediatR to dispatch requests to the corresponding Application handlers.

## 2. Create Catalog Type Controller

Add `CatalogTypeController` to handle HTTP requests related to catalog types.

Keep catalog item and catalog type endpoints separate to maintain clear responsibilities.

## 3. Configure API Endpoints

Define the required routes and HTTP methods for each controller.

Use the existing API versioning configuration and return appropriate HTTP status codes for successful operations.

## Result

Catalog items and catalog types are exposed through separate versioned API controllers, keeping HTTP concerns in the API layer and application logic in the Application layer.
