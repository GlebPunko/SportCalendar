namespace SportCalendar.Domain.Enums
{
    public enum ResponseStatus
    {
        Unknown,
        Success,
        Error_Unknown,
        Error_ActivitiesInDayNotAdded,
        Error_ActivityDoneIsNotUpdated,
        Error_ActivityIsNotAdded,
        Error_RequestIsNotValid,
        Error_DateIsNotParsed,
        Error_DateStringIsNull
    }
}
