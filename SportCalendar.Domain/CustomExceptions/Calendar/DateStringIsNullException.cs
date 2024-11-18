using SportCalendar.Domain.Enums;

namespace SportCalendar.Domain.CustomExceptions.Calendar
{
    public class DateStringIsNullException : ResponseBaseException
    {
        public DateStringIsNullException() : base(ResponseStatus.Error_DateStringIsNull)
        {
            
        }
    }
}
