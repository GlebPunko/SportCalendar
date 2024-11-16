using AutoMapper;
using SportCalendar.Application.Models.Calendar;
using SportCalendar.Entity.RelatedEntity;

namespace SportCalendar.Application.Mapper
{
    public class CalendarMapperProfile : Profile
    {
        public CalendarMapperProfile()
        {
            CreateMap<AddCalendarActivityRE, CreateCalendarActivityModel>().ReverseMap();
            CreateMap<DayActivitiesModel, DayActivitiesRE>().ReverseMap();
        }
    }
}
