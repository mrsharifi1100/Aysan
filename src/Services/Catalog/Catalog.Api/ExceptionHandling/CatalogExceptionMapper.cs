namespace Catalog.Api.ExceptionHandling;
public sealed class CatalogExceptionMapper
    : IExceptionToProblemDetailsMapper
{
    public bool TryMap(
        Exception exception,
        out ProblemDetails? problemDetails)
    {
        problemDetails = exception switch
        {
            CatalogNotFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Catalog item not found",
                Extensions = { ["code"] = "CATALOG_NOT_FOUND" }
            },

            CatalogItemAlreadyExistsException => new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Catalog item already exists",
                Extensions = { ["code"] = "CATALOG_ALREADY_EXISTS" }
            },

            _ => null
        };

        return problemDetails is not null;
    }
}