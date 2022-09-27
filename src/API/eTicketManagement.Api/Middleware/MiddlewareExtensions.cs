using Microsoft.AspNetCore.Builder;

namespace eTicketManagement.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
