using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vertical_Slice_Architecture.Data;
using Vertical_Slice_Architecture.Shared.Behaviors;
using Vertical_Slice_Architecture.Shared.Infrastructure;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;

namespace Vertical_Slice_Architecture.Dependencies;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDatabaseProvider(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey)
            ?? throw new ArgumentNullException(ConnectionString.SettingsKey);

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<ApplicationDbContext>(op =>
        {
            op.UseSqlServer(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        return services;
    }

    public static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()], includeInternalTypes: true);
        return services;
    }
}