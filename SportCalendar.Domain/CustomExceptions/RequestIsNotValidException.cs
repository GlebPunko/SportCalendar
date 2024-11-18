using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions
{
    public class RequestIsNotValidException : ResponseBaseException
    {
        public RequestIsNotValidException() : base(ResponseStatus.Error_RequestIsNotValid)
        {
            
        }
    }
}
