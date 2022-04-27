using Felix.WebService.Common.Constants;
using System.Net;

namespace Felix.WebService.Common.Exceptions.Auth
{
    public class PasswordChangingFailedException : ApiException
    {
        private const string _errorMessage = ExceptionMessageConstants.WrongUserNameOrPassword;
        public PasswordChangingFailedException() : base(_errorMessage, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
