using EmployeeManagement.Core.Entities;
using Enums = EmployeeManagement.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeManagement.DAL.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region User Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7",
                Name = Enums.UserRoles.Admin.ToString(),
                NormalizedName = Enums.UserRoles.Admin.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Id = "18768c8f-f7cf-45c2-b875-1f543935a1f3",
                Name = Enums.UserRoles.User.ToString(),
                NormalizedName = Enums.UserRoles.User.ToString().ToUpper(),
            }
        );
        #endregion

        #region Admin
        AppUser admin = new()
        {
            Id = "fde24d99-47df-421a-8cd2-ad8febdbf096",
            FirstName = "Admin",
            LastName = "Admin",
            PhoneNumber = "+994 70 123 45 67",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true
        };
        admin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(admin, "admin123");
        builder.Entity<AppUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7",
                UserId = admin.Id
            }
        );
        #endregion
        
        base.OnModelCreating(builder);
    }
}
