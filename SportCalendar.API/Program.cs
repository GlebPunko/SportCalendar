using SportCalendar.API.Helpers;
using SportCalendar.API.Middlaware;
using SportCalendar.Application.DI;
using SportCalendar.DataAccess.DI;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers().AddJsonOptions(conf =>
{
    conf.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddScoped<RequestContext>();

builder.Services.AddCors(options => 
    options.AddDefaultPolicy(
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials()
    ));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ContextMiddleware>();

app.UseCors();

app.Run();