# Phase 3 Api Versioning

API versioningis the process of managing and tracking changes to an API. It also involves communicating those changes to the API's consumers.

## Goal

Add API Versioning to the Catalog API to support multiple versions of the API and allow future changes to the API contract without breaking existing clients.

## 1 - Installation Packages

Packages need for Api Versioning :

* `Asp.Versioning.Http`
* `Asp.Versioning.Mvc.ApiExplorer`

## 2 - Add Service Registration

Register and configure API Versioning services in:add service and config in :

`DependencyInjection`

## 3 - Create Version Folder Structure

Create a version-specific folder structure for the controllers.

```text
Controllers/ 
└── V1/
```

Future versions can be added as needed:

## 4 - Create Base Version Controller

Create a base controller to provide common API versioning configuration for the Catalog controllers.

The version configuration is defined in the base controller so that individual controllers can inherit the common configuration.

## 5 - Inherit Controllers

Catalog controllers inherit from the base version controller.

For example:

```text
V1/ 
└── ProductsController 
            ↓ 
    Base Version Controller
```

This allows controllers to follow the versioning configuration defined by the base controller.

## 6 - Define API Version

Assign the appropriate API version to the controller endpoints.

For example:

```
V1 
  ↓ 
/api/v1/...
```

## Result

The Catalog API now has API Versioning configured and provides a clear structure for introducing and maintaining different API versions in the future.

Detailed API Versioning documentation is available in :

`documents/technologies/aspnet-core/api-versioning.md`

## Related Files :

* [Dependency Injection](../../../src/Services/Catalog/Catalog.Api/DependencyInjection.cs)
* [Controllers](../../../src/Services/Catalog/Catalog.Api/Controllers)
