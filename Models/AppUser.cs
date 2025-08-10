using ECommerce_Api.Models;
using Microsoft.AspNetCore.Identity;
using TestAPIJWT.Helpers;

namespace TestAPIJWT.Model.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; }

        public string Role { get; set; } = "Client";
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<BuyingRequest> BuyingRequests { get; set; } = new List<BuyingRequest>();








    }
}
