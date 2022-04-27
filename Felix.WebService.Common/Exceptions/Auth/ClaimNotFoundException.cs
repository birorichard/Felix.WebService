using System.Net;

namespace Felix.WebService.Common.Exceptions.Auth
{
    public class ClaimNotFoundException : ApiException
    {
        private const string _defaultMessage = "Login failed!";
        public ClaimNotFoundException() : base(_defaultMessage, (int)HttpStatusCode.InternalServerError)
        {

        }
    }
}
