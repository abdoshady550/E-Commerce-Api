using ECommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestAPIJWT.Model.Entities;
using static Azure.Core.HttpHeader;

namespace ECommerce_Api.Models
{
    public class CartItem
    {

        public int Id { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; } = 1;
    }
}
