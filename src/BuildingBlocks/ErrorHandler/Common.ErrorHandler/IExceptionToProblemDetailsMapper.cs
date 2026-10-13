namespace Common.ErrorHandler;
public interface IExceptionToProblemDetailsMapper
{
    bool TryMap(
        Exception exception,
        out ProblemDetails? problemDetails);
}