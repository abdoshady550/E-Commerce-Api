namespace ECommerce_Api.Handler
{
    public class APIResponse<T>
    {
        public bool Success { get; init; }
        public string Massage { get; init; }
        public T Data { get; init; }
        public object Error { get; init; }

        private APIResponse(T data, string massage, bool success, object error = null)
        {
            Success = success;
            Massage = massage;
            Data = data;
            Error = error;
        }

        public static APIResponse<T> CreateSuccess(T data, string massage = "Completed Successfully")
        {
            return new APIResponse<T>(data, massage, true);
        }

        public static APIResponse<T> CreateError(string massage = "Operation Failed", object error = null, T data = default)
        {
            return new APIResponse<T>(data, massage, false, error);
        }
    }
}
