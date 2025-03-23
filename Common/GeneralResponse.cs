namespace CategoryProductOrderApi.Common
{
    public class GeneralResponse
    {
        public class Result<T>
        {
            public bool Success { get; }
            public T? Data { get; }
            public string? Message { get; }

            private Result(bool success, T? data, string? message)
            {
                Success = success;
                Data = data;
                Message = message;
            }

            public static Result<T> SuccessResult(T data) => new(true, data, null);
            public static Result<T> FailureResult(string message) => new(false, default, message);
        }

    }
}
