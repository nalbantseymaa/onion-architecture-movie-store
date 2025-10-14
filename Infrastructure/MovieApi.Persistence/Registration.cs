using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Interfaces.Repositories;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities.Identity;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Repositories;
using MovieApi.Persistence.UnitOfWorks;

namespace MovieApi.Persistence;

public static class Registration
{
    //This method adds the relevant services (DbContext, repository, etc.) to the DI (Dependency Injection) container.
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentityCore<AppUser>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequireDigit = false;
            options.User.RequireUniqueEmail = true;
        })
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}