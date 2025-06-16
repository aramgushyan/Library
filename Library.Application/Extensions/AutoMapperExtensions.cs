using Library.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddLibraryMap(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
