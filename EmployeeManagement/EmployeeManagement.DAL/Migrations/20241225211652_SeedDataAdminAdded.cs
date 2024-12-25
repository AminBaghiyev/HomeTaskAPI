using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18768c8f-f7cf-45c2-b875-1f543935a1f3", null, "User", "USER" },
                    { "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fde24d99-47df-421a-8cd2-ad8febdbf096", 0, "70395b89-855d-4c71-8ff1-fdeb7ec9cccb", null, true, "Admin", "Admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEAQA/hZjlD+9E+8bGaHZ5F8m0y8y9U4t/pCwsBKAGJKSKAX+IqONWrJsPGPafJfTng==", "+994 70 123 45 67", false, "6b0923ff-ef22-4553-bea9-812a6d4e2ef0", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7", "fde24d99-47df-421a-8cd2-ad8febdbf096" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18768c8f-f7cf-45c2-b875-1f543935a1f3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7", "fde24d99-47df-421a-8cd2-ad8febdbf096" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9ad24d3-e4fe-46bb-b8f1-578eb33d8ad7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fde24d99-47df-421a-8cd2-ad8febdbf096");
        }
    }
}
