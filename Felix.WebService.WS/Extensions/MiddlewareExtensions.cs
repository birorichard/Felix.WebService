using Felix.WebService.WS.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Felix.WebService.WS.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiResponseHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiResponseHandlerMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseApiKeyAuthentication(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiKeyAuthenticationMiddleware>();

            return app;
        }
    }
}
