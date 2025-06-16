using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<ILibraryService, LibraryService>();

            services.AddScoped<IAuthorBookService, AuthorBookService>();

            return services;
        }
    }
}
