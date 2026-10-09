# API Versioning

API Versioning is the process of managing and tracking changes to an API while allowing different versions of the API to coexist.

## Why?

API Versioning allows the API contract to evolve without immediately breaking existing clients.

For example:

```text
/api/v1/products
/api/v2/products
```

A new API version can introduce changes while existing clients can continue using the previous version.

## Installation

The following packages are used for API Versioning:

* `Asp.Versioning.Http`
* `Asp.Versioning.Mvc.ApiExplorer`

## Configuration

API Versioning is registered and configured during application startup.

The service registration is located in:

`src/Services/Catalog/Catalog.Api/DependencyInjection.cs`

The configuration defines how API versions are handled by the application.

## Version Structure

API versions are organized inside the Controllers folder.

Current structure:

```text
Controllers/
└── V1/
```

When a new version is introduced:

```text
Controllers/
├── V1/
└── V2/
```

This keeps different versions of the API organized separately.

## Base Version Controller

A base controller is used to provide common versioning configuration for versioned controllers.

Version-specific controllers inherit from the base controller.

For example:

```text
V1/
└── ProductsController
        ↓
Base Version Controller
```

This allows common configuration to be defined once and reused by versioned controllers.

## API Version

Each controller is associated with an API version.

For example:

```text
V1
↓
/api/v1/...
```

A future version can be introduced without modifying the existing API version.

For example:

```text
/api/v1/products
/api/v2/products
```

## Swagger Integration

API Versioning is integrated with Swagger/OpenAPI so that API versions can be represented in the generated API documentation.

When multiple versions are introduced, Swagger can expose the available API versions separately.

Detailed Swagger documentation is available in:

`documents/technologies/aspnet-core/swagger.md`

## Future Versions

The current implementation starts with version `V1`.

Additional versions can be introduced when breaking changes or significant API contract changes are required.

For example:

```text
V1
↓
Existing API contract

V2
↓
New API contract
```

## Related Files

* [DependencyInjection.cs]()
* [Controllers]()
* [Swagger]()
