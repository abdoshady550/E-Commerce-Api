using ECommerce.Models;

namespace TestAPIJWT.Model.Entities
{
    public class BuyingRequest
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public ICollection<BuyingRequestItem> Items { get; set; } = new List<BuyingRequestItem>();
    }
}