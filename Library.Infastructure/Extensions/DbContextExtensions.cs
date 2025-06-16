using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            services.AddDbContext<LibraryDbContext>((sp, o) => {
                var factory  = sp.GetService<ILoggerFactory>();
                o.UseNpgsql(configuration.GetConnectionString("DefaultString"), o => o.EnableRetryOnFailure(3,TimeSpan.FromSeconds(10),null)).UseLoggerFactory(factory);
            });
            return services;
        }
    }
}
