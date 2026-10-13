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

        foreach (var mapper in _mappers)
        {
            if (mapper.TryMap(exception, out problemDetails))
                break;
        }

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
