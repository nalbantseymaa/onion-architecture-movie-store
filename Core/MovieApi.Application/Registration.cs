using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Mapper;

namespace MovieApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddAutoMapper(typeof(MapperConfig));
    }
}