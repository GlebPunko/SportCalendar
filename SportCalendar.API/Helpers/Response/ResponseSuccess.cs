using SportCalendar.Domain.Enums;

namespace SportCalendar.API.Helpers.Response
{
    public sealed class ResponseSuccess : ResponseBase
    {
        public ResponseSuccess(object data) : base(true, ResponseStatus.Success, data)
        {
            Data = data;
        }
    }
}
