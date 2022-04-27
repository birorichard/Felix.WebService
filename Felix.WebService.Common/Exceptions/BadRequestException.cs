using System.Net;

namespace Felix.WebService.Common.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
