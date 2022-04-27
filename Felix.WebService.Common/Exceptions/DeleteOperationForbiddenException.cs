using System.Net;

namespace Felix.WebService.Common.Exceptions
{
    public class DeleteOperationForbiddenException : ApiException
    {
        private const string _defaultMessage = "You can not delete your own account!";

        public DeleteOperationForbiddenException() : base(_defaultMessage, (int)HttpStatusCode.BadRequest)
        {
        }

        public DeleteOperationForbiddenException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
