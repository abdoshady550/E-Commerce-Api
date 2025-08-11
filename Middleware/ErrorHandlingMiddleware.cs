using ECommerce_Api.Handler;

namespace ECommerce_Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());

                var response = context.Response;
                response.ContentType = "application/json";

                var errorResponse = error switch
                {
                    ApiException e =>
                        (e.StatusCode, APIResponse<object>.CreateError(e.Message)),
                    KeyNotFoundException e =>
                        (StatusCodes.Status404NotFound, APIResponse<object>.CreateError("Not found")),
                    _ => (StatusCodes.Status500InternalServerError,
                         APIResponse<object>.CreateError("An internal server error occurred."))
                };

                response.StatusCode = errorResponse.Item1;
                await response.WriteAsJsonAsync(errorResponse.Item2);
            }
        }
    }
}