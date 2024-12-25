using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesAndSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34", null, "Admin", "ADMIN" },
                    { "489f3e32-ac06-42ef-9a1a-7d378fd1340a", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f28ba55-e727-42a9-88ac-d640a402ea34", 0, "f327a16f-3cda-48b9-b0df-33437bd34dfc", "admin@admin.az", true, "Admin", "Admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAECjSOGNnyml5txBmI7wF1eVn0k3Dlh5wCDj5/vLXjCw78UIzrT1omU5EDki0JXhTDw==", "+994 70 123 45 67", false, "6684be43-1b38-4739-b489-6a54230a02a1", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34", "7f28ba55-e727-42a9-88ac-d640a402ea34" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489f3e32-ac06-42ef-9a1a-7d378fd1340a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34", "7f28ba55-e727-42a9-88ac-d640a402ea34" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2352ab6e-8b4a-498a-b26e-b04d9b1fcb34");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f28ba55-e727-42a9-88ac-d640a402ea34");
        }
    }
}
