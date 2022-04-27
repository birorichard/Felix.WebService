using Felix.WebService.Enums;
using Felix.WebService.Enums.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Felix.WebService.Common.Response
{
    public class ApiError
    {
        public string ErrorMessage { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; set; }

        public ApiError()
        {

        }
        public ApiError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ApiError(ApiErrorMessageEnum messageEnum)
        {
            ErrorMessage = messageEnum.GetDescription();
        }

        public ApiError(ModelStateDictionary modelState)
        {
            if (modelState != null && modelState.Any(x => x.Value.Errors.Count > 0))
            {
                ErrorMessage = "";
                ValidationErrors = modelState.Keys.SelectMany(x => modelState[x].Errors.Select(y => new ValidationError(x, y.ErrorMessage)))
                                                  .ToList();
            }
        }
    }
}
