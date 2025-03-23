using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using ValidationException = FluentValidation.ValidationException;

namespace CategoryProductOrderApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(context, e);

            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = CreateErrorResponse(exception);
            response.StatusCode = errorResponse.StatusCode;

            await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        private static ErrorResponse CreateErrorResponse(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => HandleValidationException(validationException),

                ArgumentException => new ErrorResponse(HttpStatusCode.BadRequest, exception.Message),

                KeyNotFoundException => new ErrorResponse(HttpStatusCode.NotFound, exception.Message),

                UnauthorizedAccessException => new ErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized access"),

                DbUpdateException => new ErrorResponse(HttpStatusCode.InternalServerError, "Database update error"),

                TimeoutException => new ErrorResponse(HttpStatusCode.GatewayTimeout, "Request timeout"),

                _
                 => new ErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred")
            };
        }

        private static ErrorResponse HandleValidationException(ValidationException exception)
        {
            var errors = exception.Errors.Select(err => err.ErrorMessage).ToList();
            return new ErrorResponse(HttpStatusCode.BadRequest, "Validation failed", errors);
        }


    }

}
