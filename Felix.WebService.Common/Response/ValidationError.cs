namespace Felix.WebService.Common.Response
{
    public class ValidationError
    {
        public string Field { get; }
        public string Message { get; }
        public ValidationError(string field, string message)
        {
            Field = field == string.Empty ? null : field;
            Message = message;
        }
    }
}
