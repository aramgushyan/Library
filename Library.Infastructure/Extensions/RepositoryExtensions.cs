﻿
using Microsoft.Extensions.DependencyInjection;
using Library.Domain.Interfaces;
using Library.Infastructure.Repository;

namespace Library.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddLibraryRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<ILibraryRepository, LibraryRepository>();

            services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();

            services.AddScoped<IBookGenreRepository, BookGenreRepository>();

            services.AddScoped<IInstanceRepository, InstanceRepository>();

            services.AddScoped<IBookLendingRepository, BookLendingRepository>();

            services.AddScoped<IReaderRepository, ReaderRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
