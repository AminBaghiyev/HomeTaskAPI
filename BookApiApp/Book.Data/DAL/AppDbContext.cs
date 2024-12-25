using Book.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Entities = Book.Core.Entities;
using Enums = Book.Core.Enums;

namespace Book.Data.DAL;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Entities.Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User Roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34",
                Name = Enums.UserRoles.Admin.ToString(),
                NormalizedName = Enums.UserRoles.Admin.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Id = "489f3e32-ac06-42ef-9a1a-7d378fd1340a",
                Name = Enums.UserRoles.User.ToString(),
                NormalizedName = Enums.UserRoles.User.ToString().ToUpper(),
            }
        );
        #endregion

        #region Admin
        AppUser admin = new()
        {
            Id = "7f28ba55-e727-42a9-88ac-d640a402ea34",
            FirstName = "Admin",
            LastName = "Admin",
            PhoneNumber = "+994 70 123 45 67",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.az",
            EmailConfirmed = true
        };
        admin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(admin, "admin123");
        modelBuilder.Entity<AppUser>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34",
                UserId = admin.Id
            }
        );
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
