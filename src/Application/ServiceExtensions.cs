namespace Herbarius.Application;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceExtensions
{
public static IServiceCollection AddApplication(this IServiceCollection services)
{
    var assembly = Assembly.GetExecutingAssembly();
    services.AddMediatR(cfg =>
        {          cfg.RegisterServicesFromAssembly(assembly);
        });

    return services;
}

}

