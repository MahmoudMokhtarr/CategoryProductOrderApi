using System.Net;

namespace CategoryProductOrderApi.Middlewares
{
    public class ErrorResponse
    {
        public int StatusCode { get; }
        public string Message { get; }
        public List<string>? Errors { get; }

        public ErrorResponse(HttpStatusCode statusCode, string message, List<string>? errors = null)
        {
            StatusCode = (int)statusCode;
            Message = message;
            Errors = errors;
        }

    }

}
