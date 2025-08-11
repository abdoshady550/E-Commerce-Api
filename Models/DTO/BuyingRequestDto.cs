namespace ECommerce_Api.Models.DTO
{

    public class CreateBuyingRequestDto
    {
        public List<int> CartItemIds { get; set; }
    }

    public class UpdateRequestStatusDto
    {
        public string Status { get; set; } // Pending, Confirmed, Delivered
    }
}
