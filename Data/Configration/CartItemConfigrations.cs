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
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
        new CartItem
        {
            Id = 1,
            CartId = 1,
            ProductId = 1,
            Quantity = 2
        },
        new CartItem
        {
            Id = 2,
            CartId = 1,
            ProductId = 2,
            Quantity = 1
        },
        new CartItem
        {
            Id = 3,
            CartId = 2,
            ProductId = 1,
            Quantity = 3
        }
    );
        }
    }
}
