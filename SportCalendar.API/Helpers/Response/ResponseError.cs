using SportCalendar.Domain.Enums;

namespace SportCalendar.API.Helpers.Response
{
    public sealed class ResponseError : ResponseBase
    {
        public object Error { get; set; }

        public ResponseError(ResponseStatus status, object data, object error) : base(false, status, data)
        {
            Status = status;
            Error = error;
        }
    }
}
