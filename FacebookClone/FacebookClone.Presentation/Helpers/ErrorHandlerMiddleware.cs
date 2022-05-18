namespace FacebookClone.Presentation.Helpers
{
    using FacebookClone.BLL.Exceptions;
    using System.Net;
    using System.Text.Json;

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
            catch (BusinessException error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)error.StatusCode;

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}