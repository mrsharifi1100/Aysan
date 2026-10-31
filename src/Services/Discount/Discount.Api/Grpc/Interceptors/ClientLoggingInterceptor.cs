namespace Discount.Api.Grpc.Interceptors;

public class ClientLoggingInterceptor : Interceptor
{
    private readonly ILogger<ClientLoggingInterceptor> _logger;

    public ClientLoggingInterceptor(
        ILogger<ClientLoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        _logger.LogInformation(
            "Calling gRPC method: {Method}",
            context.Method.FullName);

        var call = continuation(request, context);

        return new AsyncUnaryCall<TResponse>(
            LogResponseAsync(call.ResponseAsync, context.Method.FullName),
            call.ResponseHeadersAsync,
            call.GetStatus,
            call.GetTrailers,
            call.Dispose);
    }

    private async Task<TResponse> LogResponseAsync<TResponse>(
        Task<TResponse> responseTask,
        string methodName)
    {
        try
        {
            var response = await responseTask;

            _logger.LogInformation(
                "gRPC method completed: {Method}",
                methodName);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "gRPC method failed: {Method}",
                methodName);

            throw;
        }
    }
}