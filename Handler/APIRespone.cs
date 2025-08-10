namespace Movie_Api.Handler
{
    public class APIResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; }
        public T Data { get; init; }
        public object Error { get; init; }

        private APIResponse(T data, string message, bool success, object error = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Error = error;
        }

        public static APIResponse<T> CreateSuccess(T data, string message = "Completed Successfully")
        {
            return new APIResponse<T>(data, message, true);
        }

        public static APIResponse<T> CreateError(string message = "Operation Failed", object error = null, T data = default)
        {
            return new APIResponse<T>(data, message, false, error);
        }
    }
}
