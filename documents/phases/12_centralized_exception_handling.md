# Phase 12— Centralized Exception Handling

## Goal

Implement a reusable exception-handling infrastructure in BuildingBlocks to provide consistent error responses across Aysan microservices using ASP.NET Core `<span>IExceptionHandler</span>` and the `<span>ProblemDetails</span>` standard.

## 1. Create Common Error Handling BuildingBlock

Create a `Common.ErrorHandling` Class Library under `src/BuildingBlocks/`.

Include the following components:

* `GlobalExceptionHandler` to handle unhandled exceptions, log errors, and generate standardized HTTP error responses.
* `IExceptionToProblemDetailsMapper` to define a contract for mapping service-specific exceptions to `ProblemDetails`.
* `ExceptionHandlingExtensions` to register the shared exception handler and configure the middleware.

Use the `Microsoft.AspNetCore.App` framework reference to access the required ASP.NET Core APIs.

## 2. Implement Global Exception Handling

Implement `GlobalExceptionHandler` using ASP.NET Core's `IExceptionHandler`.

The handler must:

* Attempt to map exceptions using the registered exception mappers.
* Return the mapped `ProblemDetails` when an exception is recognized.
* Return a generic `500 Internal Server Error` response for unrecognized exceptions.
* Log unhandled exceptions.
* Include the request path in the `instance` property.
* Prevent sensitive implementation details from being exposed in error responses.

## 3. Create Catalog Exception Mapper

Add `CatalogExceptionMapper` under `Catalog.Api/ExceptionHandling/`.

Implement `IExceptionToProblemDetailsMapper` to map Catalog-specific exceptions to appropriate HTTP status codes and stable error codes.

Examples:

* `CatalogNotFoundException` → `404 Not Found`
* `CatalogItemAlreadyExistsException` → `409 Conflict`

Keep service-specific exception mapping inside `Catalog.Api` rather than the shared BuildingBlock.

## 4. Register Exception Handling

Register the shared exception handler and the Catalog exception mapper in `Catalog.Api` dependency injection.

Enable exception-handling middleware in the ASP.NET Core request pipeline before the middleware and endpoints whose exceptions need to be handled.

Keep the Application and Domain layers independent of ASP.NET Core and HTTP-specific response models.

## 5. Standardize Error Responses

Use `ProblemDetails` as the standard HTTP error response format.

Include the appropriate HTTP status code, a descriptive title, a safe detail message, the request path, and a stable error code in the response extensions.

Do not expose stack traces, database details, connection strings, or other sensitive information in Production responses.

## 6. Validate Exception Handling

Verify that:

* Known Catalog exceptions return their expected HTTP status codes and error codes.
* Unknown exceptions return a generic `500 Internal Server Error` response.
* The HTTP status code matches the `status` property in the response body.
* Error responses follow the `ProblemDetails` format.
* Exceptions are logged appropriately.
* Adding another microservice does not require duplicating `GlobalExceptionHandler`.

## Result

A reusable centralized exception-handling BuildingBlock is implemented and integrated into Catalog API.

Catalog-specific exceptions are mapped to consistent HTTP responses, while unhandled exceptions receive a safe default response. The design allows additional microservices to reuse the shared infrastructure while maintaining independent exception-mapping rules.

## Related Files

* [Common.ErroHandler](../../src/BuildingBlocks/ErrorHandler/Commo.ErrorHandler/)
* [Dependency Injection](../../src/Services/Catalog/Catalog.Api/DependencyInjection.cs)
* [Dependency Injection](../../src/Services/Catalog/Catalog.Api/ExceptionHandling/CatalogExceptionMapper.cs)
* [Program](../../src/Services/Catalog/Catalog.Api/Program.cs)
