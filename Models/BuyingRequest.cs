using ECommerce_Api.Models;

namespace ECommerce_Api.Model.Entities
{
    public class BuyingRequest
    {
        public int Id { get; set; }

        public string UserId { get; set; }


        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public AppUser User { get; set; } = null!;
        public ICollection<BuyingRequestItem> Items { get; set; } = new List<BuyingRequestItem>();
    }
}