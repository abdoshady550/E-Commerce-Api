using ECommerce_Api.Model.Entities;

namespace ECommerce_Api.Models
{
    public class BuyingRequestItem
    {
        public int Id { get; set; }

        public int BuyingRequestId { get; set; }
        public BuyingRequest BuyingRequest { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}