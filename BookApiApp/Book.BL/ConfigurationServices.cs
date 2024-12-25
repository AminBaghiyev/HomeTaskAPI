using Book.BL.ExternalServices.Implentations;
using Book.BL.ExternalServices.Interfaces;
using Book.BL.Services.Abstractions;
using Book.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
