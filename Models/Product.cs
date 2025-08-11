using System;
using System.Collections.Generic;
using ECommerce_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Api.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }


    public byte[]? Image { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<BuyingRequestItem> BuyingRequestItems { get; set; } = new List<BuyingRequestItem>();
}
