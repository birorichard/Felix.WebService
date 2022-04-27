using System.Net;

namespace Felix.WebService.Common.Exceptions.Auth
{
    public class UnauthorizedToDeleteCommentException : ApiException
    {
        private const string _errorMessage = "You can delete only your own comment!";
        public UnauthorizedToDeleteCommentException() : base(_errorMessage, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
