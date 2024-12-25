using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EmployeeManagement.API;

public static class ConfigurationServices
{
    public static void AddAPIServices(this IServiceCollection services, string secretKey, string issuer, string audience)
    {
        services.AddIdentity<AppUser, IdentityRole>
            (options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(cfg => {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x => {

            x.TokenValidationParameters = new TokenValidationParameters
            {

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8
                    .GetBytes(secretKey)
                ),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = audience,
                ValidIssuer = issuer
            };
        });
    }
}
