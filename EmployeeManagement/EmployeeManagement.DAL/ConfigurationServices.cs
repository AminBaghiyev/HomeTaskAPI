using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Contexts;
using EmployeeManagement.DAL.Repositories.Abstractions;
using EmployeeManagement.DAL.Repositories.Implementations;
using EmployeeManagement.DAL.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.DAL;

public static class ConfigurationServices
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(
            options =>
            {
                options.UseSqlServer(Connection.GetConnectionString());
            }
        );

        services.AddScoped<IRepository<Department>, Repository<Department>>();
        services.AddScoped<IRepository<Employee>, Repository<Employee>>();
    }
}
