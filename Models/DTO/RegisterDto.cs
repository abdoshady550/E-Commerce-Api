namespace ECommerce_Api.Model.Dtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; }

    }
}
