using Newtonsoft.Json;
using System.Net;

namespace Felix.WebService.Common.Response
{
    public class ApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ApiError Error { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

        public bool Success { get; set; }

        public ApiResponse(int statusCode, object result = null, ApiError error = null)
        {
            Error = error;
            Result = result;
            Success = error == null && statusCode == (int)HttpStatusCode.OK;
        }
    }
}
