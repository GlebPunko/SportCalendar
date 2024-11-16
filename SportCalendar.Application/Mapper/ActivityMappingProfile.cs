using AutoMapper;
using SportCalendar.Application.Models.Activity;
using SportCalendar.Entity;

namespace SportCalendar.Application.Mapper
{
    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            CreateMap<CreateActivityModel, Activity>().ReverseMap();
            CreateMap<ActivityModel, Activity>().ReverseMap();
        }
    }
}
