using Library.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddLibraryMap(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
