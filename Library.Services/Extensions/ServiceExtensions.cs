using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Services;
using Microsoft.Extensions.DependencyInjection;
using Library.Infastructure.Repository;
using Library.Services.Jwt;

namespace Library.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblyOf<IAuthorService>()
                .AddClasses(classes => classes.Where(classes => classes.Name.EndsWith("Service")))
                .AsImplementedInterfaces().WithScopedLifetime();
            }
            );

            services.AddScoped<LoadService>();

            return services;
        }
    }
}
