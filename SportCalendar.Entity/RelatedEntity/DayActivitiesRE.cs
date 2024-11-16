namespace SportCalendar.Entity.RelatedEntity
{
    public class DayActivitiesRE
    {
        public int CalendarId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Unit { get; set; }
        public int UnitCount { get; set; }
        public DateOnly Date { get; set; }
    }
}
