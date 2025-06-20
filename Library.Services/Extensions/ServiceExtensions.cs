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
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<ILibraryService, LibraryService>();

            services.AddScoped<IAuthorBookService, AuthorBookService>();

            services.AddScoped<IBookGenreService, BookGenreService>();

            services.AddScoped<IInstanceService, InstanceService>();

            services.AddScoped<IBookLendingService, BookLendingService>();

            services.AddScoped<IReaderService, ReaderService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
