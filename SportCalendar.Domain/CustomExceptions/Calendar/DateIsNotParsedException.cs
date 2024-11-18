using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions.Calendar
{
    public class DateIsNotParsedException : ResponseBaseException
    {
        public DateIsNotParsedException() : base(ResponseStatus.Error_DateIsNotParsed)
        {
            
        }
    }
}
