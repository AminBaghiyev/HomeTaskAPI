using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Contexts;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.API;

public static class ConfigurationServices
{
    public static void AddAPIServices(this IServiceCollection services)
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
    }
}
