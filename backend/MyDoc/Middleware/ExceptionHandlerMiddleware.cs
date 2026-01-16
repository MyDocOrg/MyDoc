using MyDoc.Application.BO.Contants;
using System.Net;
using System.Text.Json;

namespace MyDoc.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, 
                "An unhandled exception occurred. Path: {Path}", 
                context.Request.Path);

            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                ArgumentNullException => ApiResponse<object>.Fail(
                    message: "A required parameter was not provided",
                    status: StatusCodes.Status400BadRequest
                ),
                ArgumentException => ApiResponse<object>.Fail(
                    message: exception.Message,
                    status: StatusCodes.Status400BadRequest
                ),
                UnauthorizedAccessException => ApiResponse<object>.Fail(
                    message: "You are not authorized to access this resource",
                    status: StatusCodes.Status401Unauthorized
                ),
                KeyNotFoundException => ApiResponse<object>.Fail(
                    message: "The requested resource was not found",
                    status: StatusCodes.Status404NotFound
                ),
                _ => ApiResponse<object>.Fail(
                    message: "An unexpected error occurred. Please try again later",
                    status: StatusCodes.Status500InternalServerError
                )
            };

            context.Response.StatusCode = response.Status;

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
