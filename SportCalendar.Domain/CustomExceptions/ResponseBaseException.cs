using SportCalendar.Domain.Enums;
using System.Net;

namespace SportCalendar.Domain.CustomExceptions
{
    public class ResponseBaseException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public ResponseStatus ResponseStatus { get; }
        public object ErrorData { get; protected set; }

        public ResponseBaseException(ResponseStatus responseStatus, object errorData = null)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ResponseStatus = responseStatus;
            ErrorData = errorData;
        }
    }
}
