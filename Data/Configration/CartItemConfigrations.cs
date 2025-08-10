using System.Reflection.Emit;
using ECommerce_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce_Api.Model.Entities;

namespace ECommerce_Api.Data.Configration
{
    public class CartItemConfigrations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(ci => ci.User)
                   .WithMany(u => u.CartItems)
                   .HasForeignKey(ci => ci.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
