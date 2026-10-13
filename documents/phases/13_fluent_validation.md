# Phase 13 — Request Validation

## Goal

Implement centralized request validation using FluentValidation and MediatR pipeline behaviors. Convert validation failures into standardized HTTP 400 ProblemDetails responses through the shared error-handling infrastructure.

## 1. Create Command Validators

Add FluentValidation validators in `<span>Catalog.Application</span>` for validating incoming commands.

* Create `<span>CreateCatalogCommandValidator</span>`.
* Define validation rules for command properties.
* Keep validation rules close to their corresponding features.

## 2. Register Validators

Register validators from the `<span>Catalog.Application</span>` assembly using `<span>AddValidatorsFromAssembly</span>`.

* Use `<span>ApplicationAssemblyMarker</span>` to identify the assembly.
* Avoid registering each validator manually.

## 3. Implement ValidationBehavior

Create `<span>ValidationBehavior<TRequest, TResponse></span>` in `<span>Catalog.Application.Behaviors</span>`.

* Implement `<span>IPipelineBehavior<TRequest, TResponse></span>`.
* Execute the validators associated with the incoming request.
* Throw `<span>FluentValidation.ValidationException</span>` when validation fails.
* Prevent the request handler from executing when validation fails.

## 4. Register ValidationBehavior

Register `<span>ValidationBehavior<,></span>` in the MediatR pipeline using dependency injection.

* Use `<span>IPipelineBehavior<,></span>` to register the open generic behavior.
* Ensure the behavior is included in the application's MediatR configuration.

## 5. Handle Validation Exceptions

Extend the shared `<span>GlobalExceptionHandler</span>` in `<span>Common.ErrorHandler</span>` to handle `<span>FluentValidation.ValidationException</span>`.

* Return HTTP 400 Bad Request.
* Use `<span>ProblemDetails</span>` as the standard error response format.
* Include the `<span>VALIDATION_ERROR</span>` error code.
* Group validation messages by property name and include them in the `<span>errors</span>` extension.
* Keep service-specific exception mappings in each service API.

## 6. Validate the Implementation

Test the validation pipeline through the Catalog API.

* Submit a command with valid data and verify that the handler executes.
* Submit a command with invalid data and verify that the handler does not execute.
* Verify that validation failures return HTTP 400 with the expected ProblemDetails structure.
* Verify that unexpected exceptions continue to return HTTP 500.

## Out of Scope

* Business rule validation that belongs to the domain model.
* Authentication and authorization.
* Service-specific exception mapping, already covered by the Centralized Exception Handling phase.

## Result

Catalog commands are validated automatically through the MediatR pipeline. Validation failures return standardized HTTP 400 ProblemDetails responses, while shared exception handling remains centralized in `<span>Common.ErrorHandler</span>`.
