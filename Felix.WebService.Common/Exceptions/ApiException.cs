using Felix.WebService.Common.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Felix.WebService.Common.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ValidationError> Errors { get; set; }
        public ApiException(string errorMessage, int statusCode, IEnumerable<ValidationError> errors = null) : base(errorMessage)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
