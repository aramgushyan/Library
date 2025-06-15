using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Extensions
{
    public static class DbContextExtensions
    {

        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<LibraryDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultString")));
            return services;
        }
    }
}
