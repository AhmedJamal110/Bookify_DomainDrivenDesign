using Bookify.Application.Abstractions.Behavior;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);

            config.AddBehavior(typeof(LoggingBehavior<,>)); // Logging behavior

        });



        return services;
    }
}
