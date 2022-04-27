using System.ComponentModel;

namespace Felix.WebService.Enums
{
    public enum ApiErrorMessageEnum
    {
        [Description("Please login to use this application!")]
        UnAuthorized,

        [Description("")]
        ValidationError,

        [Description("Unexpected error!")]
        Exception,

        [Description("API key not found!")]
        MissingApiKey
    }
}
