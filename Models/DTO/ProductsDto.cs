namespace CodeFirst.Models.DTO
{
    public class CreateProductsDto
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryId { get; set; }
    }
    public class UpdateProductsDto
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryId { get; set; }
    }

}
