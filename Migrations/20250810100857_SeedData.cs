using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, null, null, "22222222-2222-2222-2222-222222222222", "admin@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEB3FvbKX1fueCgcJr42EwEJHQU+M0Q+U/UCLGZpVkO7a6L8IVBvPz7J8ZVwLQGHnvg==", "01000000000", false, "Admin", "11111111-1111-1111-1111-111111111111", false, "admin" },
                    { "2", 0, null, null, "44444444-4444-4444-4444-444444444444", "client@example.com", false, false, null, "CLIENT@EXAMPLE.COM", "CLIENT", "AQAAAAIAAYagAAAAEOy28LdYfX4uX4wMqfYTbH4J4J9O3E+2HguP1fOxZVv6L4vh6E05oK6ZV5Zo4ZKvzQ==", "01011111111", false, "Client", "33333333-3333-3333-3333-333333333333", false, "client" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "BuyingRequests",
                columns: new[] { "Id", "CreatedAt", "Status", "UserId" },
                values: new object[] { 1, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Pending", "2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "High-end smartphone with amazing features", null, "Smartphone", 699.99m },
                    { 2, 1, "Powerful laptop for work and gaming", null, "Laptop", 1200.00m },
                    { 3, 1, "Noise-cancelling wireless headphones", null, "Headphones", 150.00m },
                    { 4, 2, "Comfortable cotton t-shirt", null, "T-Shirt", 20.00m },
                    { 5, 2, "Stylish blue denim jeans", null, "Jeans", 40.00m },
                    { 6, 2, "Warm winter jacket", null, "Jacket", 80.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "BuyingRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
