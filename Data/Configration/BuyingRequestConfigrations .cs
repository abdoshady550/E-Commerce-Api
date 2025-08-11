namespace ECommerce_Api.Data.Configration
{
    using System.Reflection.Emit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ECommerce_Api.Model.Entities;

    public class BuyingRequestConfigrations : IEntityTypeConfiguration<BuyingRequest>
    {
        public void Configure(EntityTypeBuilder<BuyingRequest> builder)
        {
            builder.HasOne(br => br.User)
                   .WithMany(u => u.BuyingRequests)
                   .HasForeignKey(br => br.UserId)
                   .OnDelete(DeleteBehavior.Cascade);



            DateTime fixedCreatedAt = new DateTime(2025, 8, 10, 0, 0, 0, DateTimeKind.Utc);
            var buyingRequest = new BuyingRequest
            {
                Id = 1,
                UserId = "2",
                Status = "Pending",
                CreatedAt = fixedCreatedAt
            };
            builder.HasData(buyingRequest);
        }
    }
}
