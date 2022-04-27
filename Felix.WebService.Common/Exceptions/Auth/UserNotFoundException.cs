using System.Net;

namespace Felix.WebService.Common.Exceptions.Auth
{
    public class UserNotFoundException : ApiException
    {
        private const string _message = "User not found!";
        public UserNotFoundException() : base(_message, (int)HttpStatusCode.BadRequest)
        {

        }
    }
}
