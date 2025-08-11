namespace ECommerce_Api.Models.DTO
{
    public class CreateProductsDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public IFormFile Image { get; set; }


        public int? CategoryId { get; set; }
    }
    public class UpdateProductsDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }

        public int? CategoryId { get; set; }
    }

}
