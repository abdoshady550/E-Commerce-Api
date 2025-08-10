using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPIJWT.Model.Entities;

namespace TestAPIJWT.Data.Configration
{
    public class UserConfigration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(u => u.UserName)
            .IsUnique();

            builder.HasIndex(u => u.Email)
            .IsUnique();



            string HashPassword(string password)
            {
                using var sha256 = SHA256.Create();
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
            var adminUser = new AppUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = false,
                PhoneNumber = "01000000000",
                PhoneNumberConfirmed = false,
                Role = "Admin",
                SecurityStamp = "11111111-1111-1111-1111-111111111111",
                ConcurrencyStamp = "22222222-2222-2222-2222-222222222222",
                PasswordHash = "AQAAAAIAAYagAAAAEB3FvbKX1fueCgcJr42EwEJHQU+M0Q+U/UCLGZpVkO7a6L8IVBvPz7J8ZVwLQGHnvg==", // ثابت
                AccessFailedCount = 0,
                LockoutEnabled = false,
                TwoFactorEnabled = false
            };
            var clientUser = new AppUser
            {
                Id = "2",
                UserName = "client",
                NormalizedUserName = "CLIENT",
                Email = "client@example.com",
                NormalizedEmail = "CLIENT@EXAMPLE.COM",
                EmailConfirmed = false,
                PhoneNumber = "01011111111",
                PhoneNumberConfirmed = false,
                Role = "Client",
                SecurityStamp = "33333333-3333-3333-3333-333333333333",
                ConcurrencyStamp = "44444444-4444-4444-4444-444444444444",
                PasswordHash = "AQAAAAIAAYagAAAAEOy28LdYfX4uX4wMqfYTbH4J4J9O3E+2HguP1fOxZVv6L4vh6E05oK6ZV5Zo4ZKvzQ==", // ثابت
                AccessFailedCount = 0,
                LockoutEnabled = false,
                TwoFactorEnabled = false
            };

            builder.HasData(adminUser, clientUser);

        }
    }

}
