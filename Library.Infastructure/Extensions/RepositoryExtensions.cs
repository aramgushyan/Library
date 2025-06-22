
using Microsoft.Extensions.DependencyInjection;
using Library.Domain.Interfaces;
using Library.Infastructure.Repository;
using Library.Infastructure;

namespace Library.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddLibraryRepository(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblyOf<LibraryDbContext>()
                .AddClasses(classes => classes.Where(classes => classes.Name.EndsWith("Repository")))
                .AsImplementedInterfaces().WithScopedLifetime();
            }
            );

            return services;
        }
    }
}
