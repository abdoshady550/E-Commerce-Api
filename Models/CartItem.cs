using ECommerce_Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ECommerce_Api.Model.Entities;
using static Azure.Core.HttpHeader;

namespace ECommerce_Api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
