using auth_backend.DTO.Contants;
using auth_backend.Exceptions;
using System.Net;
using System.Text.Json;

namespace auth_backend.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            context.Response.ContentType = "application/json";
            ApiResponse<string> response;

            // Log completo del error para debugging
            _logger.LogError(exception, "Exception caught by middleware: {ExceptionType} - {Message}\nStackTrace: {StackTrace}", 
                exception.GetType().Name, exception.Message, exception.StackTrace);

            switch (exception)
            {
                case BusinessException businessException:
                    // Excepciones de negocio
                    _logger.LogWarning(businessException, "Business exception: {Message}", businessException.Message);
                    context.Response.StatusCode = businessException.StatusCode;
                    response = ApiResponse<string>.Fail(
                        message: businessException.Message,
                        status: businessException.StatusCode
                    );
                    break;

                case UnauthorizedAccessException unauthorizedException:
                    // Acceso no autorizado
                    _logger.LogWarning(unauthorizedException, "Unauthorized access: {Message}", unauthorizedException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = ApiResponse<string>.Fail(
                        message: "No autorizado",
                        status: (int)HttpStatusCode.Unauthorized
                    );
                    break;

                case ArgumentNullException argumentNullException:
                    // Argumentos nulos
                    _logger.LogWarning(argumentNullException, "Argument null exception: {Message}", argumentNullException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = ApiResponse<string>.Fail(
                        message: $"Parámetro requerido faltante: {argumentNullException.ParamName}",
                        status: (int)HttpStatusCode.BadRequest
                    );
                    break;

                case ArgumentException argumentException:
                    // Argumentos inválidos
                    _logger.LogWarning(argumentException, "Argument exception: {Message}", argumentException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = ApiResponse<string>.Fail(
                        message: argumentException.Message,
                        status: (int)HttpStatusCode.BadRequest
                    );
                    break;

                case KeyNotFoundException keyNotFoundException:
                    // Recurso no encontrado
                    _logger.LogWarning(keyNotFoundException, "Resource not found: {Message}", keyNotFoundException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = ApiResponse<string>.Fail(
                        message: "Recurso no encontrado",
                        status: (int)HttpStatusCode.NotFound
                    );
                    break;

                default:
                    // Errores no controlados
                    _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = ApiResponse<string>.Fail(
                        message: "Ha ocurrido un error interno en el servidor",
                        status: (int)HttpStatusCode.InternalServerError
                    );
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
