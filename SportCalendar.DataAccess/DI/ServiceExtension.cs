using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.DataAccess.Repositories;

namespace SportCalendar.DataAccess.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();

            return services;
        }
    }
}
