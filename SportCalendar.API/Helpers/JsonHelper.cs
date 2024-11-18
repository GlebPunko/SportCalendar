using System.Text.Json;

namespace SportCalendar.API.Helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerOptions Options { get; }

        static JsonHelper()
        {
            Options = new()
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReadCommentHandling = JsonCommentHandling.Skip,
            };
        }
    }
}
