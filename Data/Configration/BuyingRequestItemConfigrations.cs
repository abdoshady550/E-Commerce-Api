
using ECommerce_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce_Api.Data.Configration
{
    public class BuyingRequestItemConfigrations : IEntityTypeConfiguration<BuyingRequestItem>
    {
        public void Configure(EntityTypeBuilder<BuyingRequestItem> builder)
        {
            builder.HasOne(bri => bri.BuyingRequest)
                   .WithMany(br => br.Items)
                   .HasForeignKey(bri => bri.BuyingRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bri => bri.Product)
                   .WithMany(p => p.BuyingRequestItems)
                   .HasForeignKey(bri => bri.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
