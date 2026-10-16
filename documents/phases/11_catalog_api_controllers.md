# Phase 11 — Catalog API Controllers

## Goal

Expose Catalog item and catalog type operations through separate versioned API controllers.

## 1. Create Catalog Item Controller

Add `CatalogItemController` to handle HTTP requests related to catalog items.

Define the required routes and HTTP methods, use MediatR to dispatch requests to the corresponding Application handlers, and return appropriate HTTP status codes.

## 2. Create Catalog Type Controller

Add `CatalogTypeController` to handle HTTP requests related to catalog types.

Define the required routes and HTTP methods, use MediatR to dispatch requests to the corresponding Application handlers, and return appropriate HTTP status codes.

Use the existing API versioning configuration for both controllers.

## Result

Catalog items and catalog types are exposed through separate versioned API controllers, keeping HTTP concerns in the API layer and application logic in the Application layer.
