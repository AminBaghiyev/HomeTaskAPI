using EmployeeManagement.BL.Services.Abstractions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.BL.Utilities;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeManagement.BL;

public static class ConfigurationServices
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            }
            );

        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<EmailService, EmailService>();
    }
}
