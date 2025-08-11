using ECommerce_Api.Model.Entities;

namespace ECommerce_Api.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
