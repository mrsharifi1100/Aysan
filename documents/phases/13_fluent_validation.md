# Phase 13 — Request Validation

## Goal

Implement centralized request validation using FluentValidation and MediatR pipeline behaviors. Convert validation failures into standardized HTTP 400 ProblemDetails responses through the shared error-handling infrastructure.

## Tip

Remember Packages :

* FluentValidation
* Microsoft.Extensions.Options.ConfigurationExtensions

## 1 - Register FluentValidation Service

Register validators from the `Catalog.Application` assembly using `AddValidatorsFromAssembly`.

* Use `ApplicationAssemblyMarker` to identify the assembly.
* Avoid registering each validator manually.

## 2 - Implement ValidationBehavior

Create `ValidationBehavior<TRequest, TResponse>` in `Catalog.Application.Behaviors`.

* Implement `IPipelineBehavior<TRequest, TResponse>`.
* Execute the validators associated with the incoming request.
* Throw `FluentValidation.ValidationException` when validation fails.
* Prevent the request handler from executing when validation fails.

## 3 - Register ValidationBehavior

Register `ValidationBehavior<,>` in the MediatR pipeline using dependency injection.

* Use `IPipelineBehavior<,>` to register the open generic behavior.
* Ensure the behavior is included in the application's MediatR configuration.

## 4 - Create Command Validators

Add FluentValidation validators in `Catalog.Application` for validating incoming commands.

* Create `CreateCatalogCommandValidator`.
* Define validation rules for command properties.
* Keep validation rules close to their corresponding features.

## Result

Catalog commands are validated automatically through the MediatR pipeline. Validation failures return standardized HTTP 400 ProblemDetails responses, while shared exception handling remains centralized in `Common.ErrorHandler`.

## Related Files

[DependencyInjection.cs](../../src/Services/Catalog/Catalog.Application/DependencyInjection.cs)
