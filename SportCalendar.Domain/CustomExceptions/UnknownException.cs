using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions
{
    public class UnknownException : ResponseBaseException
    {
        public UnknownException() : base(ResponseStatus.Error_Unknown)
        {

        }
    }
}
