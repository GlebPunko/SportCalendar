using Microsoft.Extensions.DependencyInjection;
using SportCalendar.Application.Interfaces;
using SportCalendar.Application.Services;
using SportCalendar.DataAccess.Interfaces;
using System.Reflection;

namespace SportCalendar.Application.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICalendarService, CalendarService>();

            return services;
        }
    }
}
