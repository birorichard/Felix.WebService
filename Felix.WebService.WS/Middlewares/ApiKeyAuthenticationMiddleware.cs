using Felix.WebService.Common.Constants;
using Felix.WebService.Common.Exceptions.Api;
using Felix.WebService.Enums;
using Felix.WebService.Enums.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Middlewares
{
    /// <summary>
    /// Checks for the API key in a HTTP request
    /// </summary>
    public class ApiKeyAuthenticationMiddleware
    {
        private const string apiKeyHeaderName = "FelixApiKey";
        private readonly RequestDelegate _next;

        public ApiKeyAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            if (!httpContext.Request.Headers.ContainsKey(apiKeyHeaderName))
                throw new UnauthorizedException(ApiErrorMessageEnum.MissingApiKey.GetDescription());

            Guid keyFromRequest = new(httpContext.Request.Headers[apiKeyHeaderName]);
            Guid secret = new(configuration[ConfigKeyConstants.FelixApiKeyConfigKeyName]);

            if (!keyFromRequest.Equals(secret))
                throw new UnauthorizedException(ApiErrorMessageEnum.MissingApiKey.GetDescription());

            await _next.Invoke(httpContext);
            
        }
    }
}
