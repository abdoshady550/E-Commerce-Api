using ECommerce_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce_Api.Data.Configration
{
    public class CategoryConfigrations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Name)
            .IsUnique();

            // Categories
            var electronics = new Category { Id = 1, Name = "Electronics" };
            var clothes = new Category { Id = 2, Name = "Clothes" };
            //
            builder.HasData(electronics, clothes);
        }
    }
}
