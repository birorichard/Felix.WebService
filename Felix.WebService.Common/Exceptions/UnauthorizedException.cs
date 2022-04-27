using Felix.WebService.Common.Constants;
using System.Net;

namespace Felix.WebService.Common.Exceptions.Api
{
    public class UnauthorizedException : ApiException
    {
        private const string _message = ExceptionMessageConstants.WrongUserNameOrPassword;
        public UnauthorizedException() : base(_message, (int)HttpStatusCode.Unauthorized)
        {
        }

        public UnauthorizedException(string message) : base(message, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}
