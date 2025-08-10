using ECommerce.Models;
using ECommerce_Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAPIJWT.Model.Entities;

namespace TestAPIJWT.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<BuyingRequest> BuyingRequests { get; set; }
        public DbSet<BuyingRequestItem> BuyingRequestItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }


    }
}
