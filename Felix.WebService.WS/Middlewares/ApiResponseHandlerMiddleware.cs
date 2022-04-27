using Felix.WebService.Common.Exceptions;
using Felix.WebService.Common.Extensions;
using Felix.WebService.Common.Response;
using Felix.WebService.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Middlewares
{
    /// <summary>
    /// Middleware for formatting the HTTP responses
    /// </summary>
    public class ApiResponseHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private const string _jsonContentType = "application/json";

        public ApiResponseHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Stream originalBody = httpContext.Response.Body;

            using MemoryStream responseBody = new();
            httpContext.Response.Body = responseBody;
            
            try
            {
                await _next.Invoke(httpContext);

                if (httpContext.Response.StatusCode == (int)HttpStatusCode.OK)
                {
                    string body;
                    httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                    body = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
                    httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

                    await HandleSuccessAsync(httpContext, body);
                }
                else
                {
                    await HandleUnSuccessAsync(httpContext);
                }

            }
            catch (Exception exception)
            {
                await HandleException(httpContext, exception);
            }
            
            finally
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBody);
            }
        }

        private static async Task HandleSuccessAsync(HttpContext httpContext, object body)
        {
            ApiResponse apiResponse;
            string jsonContent;
            int statusCode = httpContext.Response.StatusCode;

            object responseBody = !body.ToString().IsValidJson().HasValue ? null : body.ToString().IsValidJson().Value ? 
                JsonConvert.DeserializeObject(body.ToString()) : body.ToString();
            apiResponse = new ApiResponse(statusCode, responseBody, null);
            
            jsonContent = JsonConvert.SerializeObject(apiResponse);
            httpContext.Response.Clear();
            httpContext.Response.ContentType = _jsonContentType;
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(jsonContent);
        }

        private static async Task HandleUnSuccessAsync(HttpContext httpContext)
        {
            ApiResponse apiResponse;
            string jsonContent;
            int statusCode = httpContext.Response.StatusCode;

            switch (statusCode)
            {
                default:
                    apiResponse = new ApiResponse(httpContext.Response.StatusCode);
                    break;
            }

            jsonContent = JsonConvert.SerializeObject(apiResponse);

            httpContext.Response.Clear();
            httpContext.Response.ContentType = _jsonContentType;
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(jsonContent);
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            string errorMessage;
            ApiError error;
            ApiResponse response;
            int statusCode;

            if (exception is ApiException)
            {
                ApiException ex = exception as ApiException;
                errorMessage = exception.Message;

                error = new ApiError(errorMessage)
                {
                    ValidationErrors = ex.Errors
                };

                statusCode = ex.StatusCode;
                httpContext.Response.StatusCode = statusCode;
            }
            else if (_env.IsDevelopment())
            {
                error = new ApiError(exception.Message)
                {
                    StackTrace = exception.StackTrace
                };
                statusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                error = new ApiError(ApiErrorMessageEnum.Exception);
                statusCode = (int)HttpStatusCode.InternalServerError;

                httpContext.Response.StatusCode = statusCode;
            }

            response = new ApiResponse(statusCode: statusCode, result: null, error: error);

            var serializedJson = JsonConvert.SerializeObject(response);
            
            httpContext.Response.Clear();
            httpContext.Response.ContentType = _jsonContentType;
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(serializedJson);
        }
    }
}
