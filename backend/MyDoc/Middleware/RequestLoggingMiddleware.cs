using System.Diagnostics;

namespace MyDoc.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation(
                "Incoming Request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path
            );

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var logLevel = context.Response.StatusCode >= 500 
                    ? LogLevel.Error 
                    : context.Response.StatusCode >= 400 
                        ? LogLevel.Warning 
                        : LogLevel.Information;

                _logger.Log(
                    logLevel,
                    "Completed Request: {Method} {Path} | Status: {StatusCode} | Duration: {ElapsedMs}ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds
                );
            }
        }
    }
}
