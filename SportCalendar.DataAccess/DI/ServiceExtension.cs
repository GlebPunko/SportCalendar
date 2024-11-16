using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportCalendar.DataAccess.Interfaces;
using SportCalendar.DataAccess.Repositories;

namespace SportCalendar.DataAccess.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configurations)
        {
            var connectionString = configurations.GetConnectionString("ConnectionString");

            services.AddScoped<IActivityRepository>(_ => new ActivityRepository(connectionString));
            services.AddScoped<ICalendarRepository>(_ => new CalendarRepository(connectionString));

            return services;
        }
    }
}
