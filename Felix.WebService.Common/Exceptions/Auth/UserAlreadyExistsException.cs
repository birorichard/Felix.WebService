using System.Net;

namespace Felix.WebService.Common.Exceptions.Auth
{
    public class UserAlreadyExistsException : ApiException
    {
        private const string _errorMessage = "Sorry, this username already exists. Please choose a different one.";
        public UserAlreadyExistsException() : base(_errorMessage, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
