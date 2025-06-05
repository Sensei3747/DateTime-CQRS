using DateTime.Application.Abstractions.Auth;
using DateTime.Application.Abstractions.Behaviors;
using DateTime.Domain.Abstractions;
using DateTime.Application.Users;
using DateTime.Application.Program;
using DateTime.Domain.ProgramRegistrations;
using DateTime.Infrastructure.Repositories;
using DateTime.Infrastructure.Data;
using DateTime.Infrastructure.Auth;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MediatR;
using System.Reflection;
using DateTime.Domain.Users;
using DateTime.Domain.Program;
using DateTime.Application.Abstractions.Clock;
using DateTime.Infrastructure.Clock;
using DateTime.Application.Abstractions.Timezone;
using DateTime.Infrastructure.Timezone;

namespace DateTime;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();

        AddPersistence(services, configuration);
        

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProgramRepository, ProgramRepository>();
        services.AddScoped<IProgramRegistrationRepository, ProgramRegistrationRepository>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<ITimezoneHelper, TimezoneHelper>();

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        // SQLServer
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
    }
}
