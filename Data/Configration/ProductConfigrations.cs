namespace ECommerce_Api.Data.Configration
{
    using System.Reflection.Emit;
    using ECommerce.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            // Products
            var product1 = new Product
            {
                Id = 1,
                Name = "Smartphone",
                Description = "High-end smartphone with amazing features",
                Price = 699.99m,
                CategoryId = 1
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Laptop",
                Description = "Powerful laptop for work and gaming",
                Price = 1200.00m,
                CategoryId = 1
            };

            var product3 = new Product
            {
                Id = 3,
                Name = "Headphones",
                Description = "Noise-cancelling wireless headphones",
                Price = 150.00m,
                CategoryId = 1
            };

            var product4 = new Product
            {
                Id = 4,
                Name = "T-Shirt",
                Description = "Comfortable cotton t-shirt",
                Price = 20.00m,
                CategoryId = 2
            };

            var product5 = new Product
            {
                Id = 5,
                Name = "Jeans",
                Description = "Stylish blue denim jeans",
                Price = 40.00m,
                CategoryId = 2
            };

            var product6 = new Product
            {
                Id = 6,
                Name = "Jacket",
                Description = "Warm winter jacket",
                Price = 80.00m,
                CategoryId = 2
            };
            builder.HasData(product1, product2, product3, product4, product5, product6);
        }
    }
}
