# Phase 12— Centralized Exception Handling

## Goal

Implement a reusable exception-handling infrastructure in BuildingBlocks to provide consistent error responses across Aysan microservices using ASP.NET Core `<span>IExceptionHandler</span>` and the `<span>ProblemDetails</span>` standard.

## 1 - Create Common Error Handling BuildingBlock

Create a `Common.ErrorHandling` Class Library under `src/BuildingBlocks/ErrorHandler`.

Include the following components:

* `GlobalExceptionHandler` to handle unhandled exceptions using ASP.NET Core's `IExceptionHandler`, log errors, and generate standardized `ProblemDetails` responses.
* `IExceptionToProblemDetailsMapper` to define a contract for mapping service-specific exceptions to HTTP error responses.
* `ExceptionHandlingExtensions` to register the shared exception handler and configure exception-handling middleware.

The handler must return mapped responses for recognized exceptions and a generic `500 Internal Server Error` response for unrecognized exceptions.

Include the request path in the `instance` property and prevent sensitive implementation details from being exposed.

Use the `Microsoft.AspNetCore.App` framework reference to access the required ASP.NET Core APIs.

## 2. Create Catalog Exception Mapper

Add `CatalogExceptionMapper` under `Catalog.Api/ExceptionHandling/`.

Implement `IExceptionToProblemDetailsMapper` to map Catalog-specific exceptions defined in `Catalog.Application/Features/Catalog/Exceptions/` to appropriate HTTP status codes and stable error codes.

Examples:

* `CatalogNotFoundException` → `404 Not Found`
* `CatalogItemAlreadyExistsException` → `409 Conflict`

Keep service-specific exception mapping inside `Catalog.Api` rather than the shared BuildingBlock.

> The Application layer defines the exceptions, while the API layer maps them to HTTP responses.

## 3. Register Exception Handling

Register the shared exception handler and the Catalog exception mapper in `Catalog.Api` dependency injection.

Enable exception-handling middleware in the ASP.NET Core request pipeline before the middleware and endpoints whose exceptions need to be handled.

Keep the Application and Domain layers independent of ASP.NET Core and HTTP-specific response models.

## Result

A reusable centralized exception-handling BuildingBlock is implemented and integrated into Catalog API.

Catalog-specific exceptions are mapped to consistent HTTP responses, while unhandled exceptions receive a safe default response. The design allows additional microservices to reuse the shared infrastructure while maintaining independent exception-mapping rules.

## Related Files

* [Common.ErroHandler/](../../src/BuildingBlocks/ErrorHandler/Common.ErrorHandler/)
* [Dependency Injection](../../src/Services/Catalog/Catalog.Api/DependencyInjection.cs)
* [Catalog Exception](../../src/Services/Catalog/Catalog.Api/ExceptionHandling/CatalogExceptionMapper.cs)
* [Program](../../src/Services/Catalog/Catalog.Api/Program.cs)
