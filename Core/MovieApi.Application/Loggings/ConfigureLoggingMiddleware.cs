using Microsoft.AspNetCore.Builder;

namespace MovieApi.Application.Loggings;

public static class ConfigureLoggingMiddleware
{
    public static void ConfigureLoggingHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<LoggingMiddleware>();
    }
}