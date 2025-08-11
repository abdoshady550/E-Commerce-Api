namespace ECommerce_Api.Utilities
{
    public static class MassageResponse
    {
        public static string NoDataFound { get; set; } = "No Data Found";
        public static string FailedRequest { get; set; } = "Failed Request";
        public static string Unauthorized { get; set; } = "Invalid username or password";
        public static string BadRequest { get; set; } = "Bad Request From The Body";
        public static string Success { get; set; } = "Completed Successfully";
        public static string ImageExtention { get; set; } = "only .png or .jpg Extention";


    }
}
