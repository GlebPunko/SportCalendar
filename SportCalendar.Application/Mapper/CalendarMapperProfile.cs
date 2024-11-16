using AutoMapper;
using SportCalendar.Application.Models.Calendar;
using SportCalendar.Entity;

namespace SportCalendar.Application.Mapper
{
    public class CalendarMapperProfile : Profile
    {
        public CalendarMapperProfile()
        {
            CreateMap<AddCalendarActivity, CreateCalendarActivityModel>().ReverseMap();
            CreateMap<DayActivitiesModel, DayActivities>().ReverseMap();
        }
    }
}
