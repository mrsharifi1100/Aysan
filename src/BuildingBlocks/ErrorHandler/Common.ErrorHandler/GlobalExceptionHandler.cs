using System.ComponentModel.DataAnnotations;
using Common.ErrorHandler;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Common.ErrorHandler;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IEnumerable<IExceptionToProblemDetailsMapper> _mappers;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        IEnumerable<IExceptionToProblemDetailsMapper> mappers,
        ILogger<GlobalExceptionHandler> logger)
    {
        _mappers = mappers;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails? problemDetails = null;

        // 1. Handle FluentValidation errors
        if (exception is FluentValidation.ValidationException validationException)
        {
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation failed",
                Detail = "One or more validation errors occurred."
            };

            problemDetails.Extensions["code"] = "VALIDATION_ERROR";

            problemDetails.Extensions["errors"] =
                validationException.Errors
                    .GroupBy(error => error.PropertyName)
                    .ToDictionary(
                        group => group.Key,
                        group => group
                            .Select(error => error.ErrorMessage)
                            .ToArray());

            _logger.LogWarning(
                "Validation failed. ErrorCount: {ErrorCount}",
                validationException.Errors.Count());
        }
        else
        {
            // 2. Handle service-specific exceptions
            foreach (var mapper in _mappers)
            {
                if (mapper.TryMap(exception, out problemDetails))
                    break;
            }
        }

        // 3. Handle unknown exceptions
        if (problemDetails is null)
        {
            _logger.LogError(
                exception,
                "An unexpected error occurred.");

            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unexpected error occurred.",
                Detail = "An unexpected error occurred."
            };

            problemDetails.Extensions["code"] = "INTERNAL_ERROR";
        }

        problemDetails.Instance = httpContext.Request.Path;

        var statusCode = problemDetails.Status
            ?? StatusCodes.Status500InternalServerError;

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            cancellationToken);

        return true;
    }
}
